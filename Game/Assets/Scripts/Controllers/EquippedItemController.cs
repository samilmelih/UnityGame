using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedItemController : MonoBehaviour
{
    GameObject itemHolderPrefab;
    
	Dictionary<string, Sprite> stringToSpriteMap;

	List<string> equippedItems;

	public int maxEquippedItemSize = 3;

	Inventory inventory;
	World world;



	List<GameObject> itemHolders;

    // Use this for initialization
    void Start()
    {
        world = WorldController.Instance.world;

        inventory = world.character.inventory;

        stringToSpriteMap = new Dictionary<string, Sprite>();
        itemHolders = new List<GameObject>();

        LoadItemSprites();
        // LoadItemHolderPrefab();	// ***OLD***
		LoadItems();

		inventory.OnItemEquipped += OnItemEquipped;
    }

    void LoadItemSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/GunSprites");

        foreach (var item in sprites)
        {
            if (stringToSpriteMap.ContainsKey(item.name))
			{
                Debug.LogError("PurchasedItemController -- LoadItemSprites we have same sprite name???");
				return;
			}

            stringToSpriteMap.Add(item.name, item);
        }
    }

	// FIXME: It looks like this method is not used.
    void UpdateUIForOneGO(GameObject holder_GO)
    {
        holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite = null;
        holder_GO.transform.Find("ItemNameText").GetComponent<Text>().text = "No Item";
        holder_GO.GetComponentInChildren<Button>().enabled = false;
    }

	// ***NEW***
	void OnItemEquipped()
	{
		// FIXME: For now we update all equipped items but we don't need this.
		// We can send which item will be update. itemHolders would be a dictionary.

		equippedItems = inventory.GetEquippedItemsNameList();
		for (int i = 0; i < maxEquippedItemSize; i++)
		{
			GameObject item_go = itemHolders[i];

			item_go.name = equippedItems[i];

			Image image = item_go.transform.GetComponentInChildren<Image>();
			image.sprite = stringToSpriteMap[equippedItems[i]];

			item_go.SetActive(true);
		}
	}


	// ***OLD***
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


	// ***NEW***
	void LoadItems()
	{
		equippedItems = inventory.GetEquippedItemsNameList();

		itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/_EquippedItemHolder");

		for (int i = 0; i < maxEquippedItemSize; i++)
		{
			Transform slot = this.transform.Find("Slot_" + (i + 1));
			GameObject item_go = Instantiate(itemHolderPrefab, slot);

			item_go.name = equippedItems[i];

			Image image = item_go.transform.GetComponentInChildren<Image>();
			image.sprite = stringToSpriteMap[equippedItems[i]];

			itemHolders.Add(item_go);
		}
	}

	// ***OLD***
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





	// ***NEW***
	public void OnItemDropped_Click(int slot)
	{
		Transform slot_go = this.transform.Find("Slot_" + slot);

		// We only have one GameObject so just get child at index 0.
		Transform equippedItem = slot_go.GetChild(0);

		string itemName = equippedItem.name;

		if (world.itemProtoTypes.ContainsKey(itemName))
		{
			inventory.DropItem(world.itemProtoTypes[itemName]);
		}
		else
		{
			Debug.LogError("OnItemDroppedButton_Click() -- item that will be dropped is not in the prototypes.");
			return;
		}

		equippedItem.gameObject.SetActive(false);

		PlayerPrefsController.SaveEquippedInventoryItem(equippedItems);
	}


	// ***OLD***
    void OnDropButton_Click(string itemName, object sender)
    {
        if (world.itemProtoTypes.ContainsKey(itemName))
            inventory.DropItem(world.itemProtoTypes[itemName]);

        else
            Debug.LogError("No item with name:" + itemName);


        PlayerPrefsController.SaveEquippedInventoryItem(equippedItems);
    }
}
