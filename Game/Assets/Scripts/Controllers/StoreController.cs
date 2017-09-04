using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreController : MonoBehaviour
{
    public Text moneytext;

    public GameObject storeGO;

    public GameObject MainMenuGO;

    Dictionary<string, Sprite> stringToSpriteMap;

    World world;

    GameObject itemHolderPrefab;



    Text itemNameText;
    Text itemDescriptionText;
    Text buyButtonText;

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


    void LoadAllSprites()
    {
        LoadAllGunSprites();
        LoadAllBulletSprites();

    }
    // Use this for testing. Maybe it can be a feature in game later.


    // Use this for initialization
    void Start()
    {

        //PlayerPrefsController.CleanPlayerPrefs(); return;

        world = WorldController.Instance.world;
        stringToSpriteMap = new Dictionary<string, Sprite>();

        LoadAllSprites();



        // FIXME: We need to know when game is first started. If first started we have a start money.
        // If not first started, we need to get from PlayerPrefs.

        if (PlayerPrefsController.IsGameFirstStarted == true)
        {
            world.character.money = 200;
            PlayerPrefsController.Money = world.character.money;
        }
        else
        {
            world.character.money = PlayerPrefsController.Money;
        }



        CreateStoreWithUI();

    }


    void CreateStoreWithUI()
    {
        List<Item> inv = PlayerPrefsController.GetSavedInventoryItemList(world);

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        foreach (Item itemProto in world.itemProtoTypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            Transform itemPlaceOfThisObject = itemHolderGO.transform.Find("ItemPlace");

            itemNameText = itemHolderGO.transform.Find("ItemNameText").GetComponent<Text>();
            // itemDescription  = itemHolderGO.transform.Find("Description - Text").GetComponent<Text>();
            buyButtonText = itemHolderGO.transform.Find("PurchaseButton").GetComponentInChildren<Text>();

            itemHolderGO.transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = stringToSpriteMap[itemProto.name];
            if (inv.Contains(itemProto) == false || itemProto.isStackable == true)
            {
                itemHolderGO.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    {
                        BuyItem(itemProto.name, itemHolderGO);
                    });
            }
            else
            {
                itemHolderGO.GetComponentInChildren<Button>().enabled = false;
                buyButtonText.text = "purchased";
            }

            itemHolderGO.name = itemProto.name;
            itemNameText.text = itemProto.name;
            //          itemDescription.text = "Cost : " + weapon.cost.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // FIXME: We don't want to update every frame.
        moneytext.text = "Gold : " + PlayerPrefsController.Money;
    }

    public void BuyItem(string itemName, object sender)
    {
        if (world.itemProtoTypes.ContainsKey(itemName) == false)
        {
            Debug.LogError(string.Format("{0} adlı silahı satın almaya çalışıyorsun ismi ile itemProto dan erişmek mümkün değil yanlış birşey var?", itemName));
            return;
        }

        if (world.itemProtoTypes[itemName].cost <= world.character.money)
        {
            world.character.money -= world.itemProtoTypes[itemName].cost;
            PlayerPrefsController.Money = world.character.money;


            //Is this Item stackable?

            if (world.itemProtoTypes[itemName].isStackable == false)
            {
                //Save the item that you bought to the PlayerPrefs
                PlayerPrefsController.SaveInventoryItem(itemName);


                //Add this item to your inventory
                world.character.inventory.AddItem(world.itemProtoTypes[itemName]);

                //if this object is no stackable then dont allow it to "Buy" again and set the enabled property as false
                (sender as GameObject).GetComponentInChildren<Button>().enabled = false;

                //Then set the ButtonText as purchased item so we can now we wont be able to buy this again
                buyButtonText = (sender as GameObject).transform.Find("PurchaseButton").GetComponentInChildren<Text>();
                buyButtonText.text = "purchased";
            }
            else
            {
                int purchasedStack = 0;

                //check the type of item for knowing how to calculate things
                Item countableItem = world.itemProtoTypes[itemName];
                if (countableItem is Bullet)
                    purchasedStack = (countableItem as Bullet).count;

                //Save it
                PlayerPrefsController.SetItemCount(itemName, purchasedStack);


                world.character.inventory.AddItem(world.itemProtoTypes[itemName], purchasedStack);
            }
        }
        else
        {
            Debug.LogError(string.Format("{0} adlı silahı satın almaya çalışıyorsun paran yok???", itemName));
        }
    }

    public void CloseStore()
    {
        storeGO.SetActive(false);
        MainMenuGO.SetActive(true);
    }

}
