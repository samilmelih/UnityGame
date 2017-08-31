using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class StoreController : MonoBehaviour
{
    public Text moneytext;

    public GameObject storeGO;

    public GameObject MainMenuGO;

    Dictionary<string,Sprite> stringToSpriteMap;

    World world;

    GameObject itemHolderPrefab;

    string inventoryString = "";

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

    bool IsGameFirstStarted()
    {
        if (PlayerPrefs.HasKey("firstStarted") == false)
        {
            PlayerPrefs.SetInt("firstStarted", 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    void LoadAllSprites()
    {
        LoadAllGunSprites();
        LoadAllBulletSprites();

    }
    // Use this for testing. Maybe it can be a feature in game later.
    void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    // Use this for initialization
    void Start()
    {

        // CleanPlayerPrefs();return;
		
        world = WorldController.Instance.world;
        stringToSpriteMap = new Dictionary<string, Sprite>();

        LoadAllSprites();

	

        // FIXME: We need to know when game is first started. If first started we have a start money.
        // If not first started, we need to get from PlayerPrefs.

        if (IsGameFirstStarted() == true)
        {
            world.character.money = 200;
            PlayerPrefs.SetInt("money", world.character.money);
        }
        else
        {
            world.character.money = PlayerPrefs.GetInt("money"); 
        }

        inventoryString = PlayerPrefs.GetString("inventory");

        CreateStoreWithUI();
		
    }


    void CreateStoreWithUI()
    {
        List<string> inv = PlayerPrefs.GetString("inventory").Split(',').ToList();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        foreach (string itemProtoName in world.itemProtoTypes.Keys)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            Transform itemPlaceOfThisObject = itemHolderGO.transform.Find("ItemPlace");

            itemNameText = itemHolderGO.transform.Find("ItemNameText").GetComponent<Text>();
            // itemDescription  = itemHolderGO.transform.Find("Description - Text").GetComponent<Text>();
            buyButtonText = itemHolderGO.transform.Find("PurchaseButton").GetComponentInChildren<Text>();

            itemHolderGO.transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = stringToSpriteMap[itemProtoName];
            if (inv.Contains(itemProtoName) == false || world.itemProtoTypes[itemProtoName].isStackable == true)
            {
                itemHolderGO.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    {
                        BuyItem(itemProtoName, itemHolderGO);
                    });
            }
            else
            {
                itemHolderGO.GetComponentInChildren<Button>().enabled = false;
                buyButtonText.text = "purchased";
            }

            itemHolderGO.name = itemProtoName;
            itemNameText.text = itemProtoName;
//          itemDescription.text = "Cost : " + weapon.cost.ToString();
        }
    }
    // Update is called once per frame
    void Update()
    {
        // FIXME: We don't want to update every frame.
        moneytext.text = "Gold : " + PlayerPrefs.GetInt("money");
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
            PlayerPrefs.SetInt("money", world.character.money);

            if (inventoryString == "")
                inventoryString += itemName;
            else
                inventoryString += "," + itemName;
			

            if (world.itemProtoTypes[itemName].isStackable == false)
            {
                PlayerPrefs.SetString("inventory", inventoryString);

                world.character.inventory.AddItem(world.itemProtoTypes[itemName]);
                (sender as GameObject).GetComponentInChildren<Button>().enabled = false;
                buyButtonText = (sender as GameObject).transform.Find("PurchaseButton").GetComponentInChildren<Text>();
                buyButtonText.text = "purchased";
            }
            else
            {
                int stackSize = PlayerPrefs.GetInt(itemName);

                Item countableItem = world.itemProtoTypes[itemName];
                if(countableItem is Bullet)
                    stackSize +=(countableItem as Bullet).count;  

                PlayerPrefs.SetInt(itemName, stackSize);
                world.character.inventory.AddItem(world.itemProtoTypes[itemName], stackSize);
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
