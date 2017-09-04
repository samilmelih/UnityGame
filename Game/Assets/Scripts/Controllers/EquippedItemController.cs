using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedItemController : MonoBehaviour
{



    GameObject itemHolderPrefab;
    Dictionary<string, Sprite> stringToSpriteMap;

    List<GameObject> itemHolders;

    List<string> equippedItems;

    public int maxEquippedItemSize = 10;
    Inventory inventory;
    World world;
    // Use this for initialization
    void Start()
    {
        world = WorldController.Instance.world;

        inventory = world.character.inventory;

        stringToSpriteMap = new Dictionary<string, Sprite>();
        itemHolders = new List<GameObject>();

        LoadItemSprites();
        LoadItemHolderPrefab();

        inventory.OnItemEquipped += UpdateUI;


    }

    void LoadItemSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/GunSprites");

        foreach (var item in sprites)
        {
            if (stringToSpriteMap.ContainsKey(item.name))
                Debug.LogError("PurchasedItemController -- LoadItemSprites we have same sprite name???");


            stringToSpriteMap.Add(item.name, item);
        }


    }

    void UpdateUIForOneGO(GameObject holder_GO)
    {
        holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite = null;
        holder_GO.transform.Find("ItemNameText").GetComponent<Text>().text = "No Item";
        holder_GO.GetComponentInChildren<Button>().enabled = false;

    }
    void UpdateUI()
    {
        equippedItems = inventory.GetEquippedItemsNameList();
        for (int i = 0; i < maxEquippedItemSize; i++)
        {
            GameObject holder_GO = itemHolders[i];

            if (i < equippedItems.Count)
            {
                holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite = stringToSpriteMap[equippedItems[i]];
                holder_GO.transform.Find("ItemNameText").GetComponent<Text>().text = equippedItems[i];
                holder_GO.GetComponentInChildren<Button>().enabled = true;

                string itemName = equippedItems[i];
                //removing all listeners because its acting like an array and running every single one
                holder_GO.GetComponentInChildren<Button>().onClick.RemoveAllListeners();

                holder_GO.GetComponentInChildren<Button>().onClick.AddListener(
                    delegate
                    {
                        OnDropButton_Click(itemName, holder_GO);
                    }

                );
            }
            else
            {

                holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite = null;
                holder_GO.transform.Find("ItemNameText").GetComponent<Text>().text = "No Item";
                holder_GO.GetComponentInChildren<Button>().enabled = false;


            }

        }
    }

    void LoadItemHolderPrefab()
    {
        equippedItems = inventory.GetEquippedItemsNameList();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/EquippedItemHolder");

        for (int i = 0; i < maxEquippedItemSize; i++)
        {
            GameObject holder_GO = (GameObject)Instantiate(itemHolderPrefab, this.transform);

            itemHolders.Add(holder_GO);

            if (i <= equippedItems.Count - 1)
            {

                //TODO : item ile ilgili sprite resourcestan çekilsin
                // item bilgileri yazdırılacak ise world referansı tutulsun
                // itemler sadece silah olmayacak world içinde tüm itemlerin bulunduğu bir liste falan mı olacak

                //oyuncu hangi silahında kaç mermisi var bilmek ister yada hangisi daha çok vuruyordu gibi bilgiler 

                holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite = stringToSpriteMap[equippedItems[i]];
                holder_GO.transform.Find("ItemNameText").GetComponent<Text>().text = equippedItems[i];
                string itemName = equippedItems[i];

                //removing all listeners because its acting like an array and running every single one
                holder_GO.GetComponentInChildren<Button>().onClick.RemoveAllListeners();
                holder_GO.GetComponentInChildren<Button>().onClick.AddListener(
                    delegate
                    {
                        OnDropButton_Click(itemName, holder_GO);
                    }

                );





            }
        }
    }
    void OnDropButton_Click(string itemName, object sender)
    {
        if (world.itemProtoTypes.ContainsKey(itemName))
            inventory.DropItem(world.itemProtoTypes[itemName]);

        else
            Debug.LogError("No item with name:" + itemName);


        PlayerPrefsController.SaveEquippedInventoryItem(equippedItems);
    }
}
