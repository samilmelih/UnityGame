using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;



public class PurchasedItemController : MonoBehaviour
{
    GameObject itemHolderPrefab;
    string[] currentInventoryItems;

    List<string> equippedItems;

    public int inventoryItemSize = 20;

    Dictionary<string, Sprite> stringToSpriteMap;

    //TODO
    ///burada callBack Kullanmamzı gerekebilir 
    /// biz bir item seçtiğimizde ve equip dediğimzde equipped içinde bir nesne oluşturulacak ve içine bu item koyulacak 
    /// drop denildiği zaman sahip olann itemlere düzenlenip Equip butonu aktif edilecek texti değişecek

	// Use this for initialization
	void Start () {
        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/PurchasedItemHolder");


        currentInventoryItems = PlayerPrefs.GetString("inventory").Split(',');


        equippedItems = PlayerPrefs.GetString("equippedInventory").Split(',').ToList();

        Debug.Log("Equipped " +PlayerPrefs.GetString("equippedInventory"));

        stringToSpriteMap = new Dictionary<string, Sprite>();


        LoadItemSprites();

        for (int i = 0; i < inventoryItemSize; i++)
        {
            GameObject holderGO = Instantiate(itemHolderPrefab, this.transform);

            if (currentInventoryItems.Length > i)
            {
                string itemName = currentInventoryItems[i];
                holderGO.transform.Find("ItemNameText").GetComponent<Text>().text = itemName;
                holderGO.transform.Find("ItemImage").GetComponent<Image>().sprite = stringToSpriteMap[itemName];
                //holderGo dan itemin ismini al
                if (equippedItems.Contains(itemName) == true)
                {
                    //
                    holderGO.GetComponentInChildren<Button>().enabled = false;
                    holderGO.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Equipped";
                }
                else
                {
                    holderGO.GetComponentInChildren<Button>().onClick.AddListener(
                        delegate
                        {
                            OnEquipItem_Click(itemName, holderGO);
                        }
            
                    );
                }
            }
        }
	}


    //TODO item yazdım çünkü sadece silah yüklenmeyecek diğer eşyalarda gelecek
    void LoadItemSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/GunSprites");

        foreach (var item in sprites)
        {
            if (stringToSpriteMap.ContainsKey(item.name))
                Debug.LogError("PurchasedItemController -- LoadItemSprites we have same sprite name???");


            stringToSpriteMap.Add(item.name,item);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnEquipItem_Click(string itemName, Object sender)
    {
        GameObject holderGO = sender as GameObject;

        equippedItems.Add(itemName);



        string equippedItemsString = "";


        foreach (var item in equippedItems)
        {
            equippedItemsString += item + ",";
        }

        PlayerPrefs.SetString("equippedInventory",equippedItemsString);


        holderGO.GetComponentInChildren<Button>().enabled = false;
        holderGO.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = "Equipped";
    }
}
