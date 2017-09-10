using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    Dictionary<string, Sprite> stringToSpriteMap;

    public GameObject storeUI;

    public Text moneytext;

    Text itemNameText;
    Text buyButtonText;

    World world;
    Inventory inventory;

    // Use this for initialization
    void Start()
    {


        world = WorldController.Instance.world;
        inventory = world.character.inventory;

        stringToSpriteMap = new Dictionary<string, Sprite>();

        LoadAllSprites();

        // FIXME: This may be in character constructer.
        if (PlayerPrefsController.IsGameFirstStarted == true)
        {
            world.character.money = 200;
            PlayerPrefsController.Money = world.character.money;
        }
        else
        {
            world.character.money = PlayerPrefsController.Money;
        }

        LoadAllItems();
    }

    void LoadAllSprites()
    {
        LoadAllGunSprites();
        LoadAllBulletSprites();
    }

    void LoadAllGunSprites()
    {
        Sprite[] gunSprites = Resources.LoadAll<Sprite>("Sprites/GunSpritesBlack");

        foreach (Sprite sprite in gunSprites)
        {
            stringToSpriteMap.Add(sprite.name, sprite);
        }
    }

    void LoadAllBulletSprites()
    {
        Sprite[] bulletSprites = Resources.LoadAll<Sprite>("Sprites/BulletSpritesBlack");

        foreach (Sprite sprite in bulletSprites)
        {
            stringToSpriteMap.Add(sprite.name, sprite);
        }
    }

    void LoadAllItems()
    {
        GameObject itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        foreach (Item itemProto in world.itemProtoTypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            itemNameText = itemHolderGO.transform.Find("ItemNameText").GetComponent<Text>();
            buyButtonText = itemHolderGO.transform.Find("PurchaseButton").GetComponentInChildren<Text>();
            itemHolderGO.transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = stringToSpriteMap[itemProto.name];

            if (inventory.purchasedItemMap.Count == 0 || inventory.purchasedItemMap.ContainsKey(itemProto.name) == false ||
                itemProto.isStackable == true)
            {
                itemHolderGO.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    {
                        PurchaseItem(itemProto.name, itemHolderGO);
                    });

                buyButtonText.text = itemProto.cost + " G";
            }
            else
            {
                itemHolderGO.GetComponentInChildren<Button>().enabled = false;
                buyButtonText.text = "Purchased";
            }

            itemHolderGO.name = itemProto.name;
            itemNameText.text = itemProto.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = "Gold : " + PlayerPrefsController.Money;
    }

    public void PurchaseItem(string itemName, object sender)
    {
        Inventory inventory = world.character.inventory;

        if (world.itemProtoTypes.ContainsKey(itemName) == false)
        {
            Debug.LogError("PurchaseItem() -- Item that you are trying to purchase is not in the item prototypes.");
            return;
        }

        Item item = world.itemProtoTypes[itemName].Clone();

        if (item.cost > world.character.money)
        {
            Debug.Log("PurchaseItem() -- You don't have enough money to purchase this item.");
            return;
        }

        if (item.isStackable == false)
        {
            // if this object is no stackable then dont allow it to "Buy" again and set the enabled property as false
            (sender as GameObject).GetComponentInChildren<Button>().enabled = false;

            //Then set the ButtonText as purchased item so we can now we wont be able to buy this again
            buyButtonText = (sender as GameObject).transform.Find("PurchaseButton").GetComponentInChildren<Text>();
            buyButtonText.text = "Purchased";
        }

        // FIXME: Maybe a callback would be nice. A callback in character can update
        // PlayerPrefs and also UI.
        world.character.money -= world.itemProtoTypes[itemName].cost;
        PlayerPrefsController.Money = world.character.money;

        // Add this item to your inventory
        inventory.AddToPurchasedItems(item);
    }

    public void CloseStore()
    {
        storeUI.SetActive(false);
    }
}
