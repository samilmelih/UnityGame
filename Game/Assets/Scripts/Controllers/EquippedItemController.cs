using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedItemController : MonoBehaviour
{
    GameObject itemHolderPrefab;
    
	Dictionary<string, Sprite> stringToSpriteMap;

	List<string> equippedWeapons;

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
		LoadItems();
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
		
	void LoadItems()
	{
		equippedWeapons = inventory.GetEquippedWeaponList();

		itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/_EquippedItemHolder");

		for (int i = 0; i < equippedWeapons.Count; i++)
		{
			Transform slot = this.transform.Find("Slot_" + (i + 1));
			GameObject item_go = Instantiate(itemHolderPrefab, slot);

			item_go.name = equippedWeapons[i];

			Image image = item_go.transform.GetComponentInChildren<Image>();
			image.sprite = stringToSpriteMap[equippedWeapons[i]];

			itemHolders.Add(item_go);
		}
	}
		
	void OnItemEquipped()
	{
		equippedWeapons = inventory.GetEquippedItemsList();
		for (int i = 0; i < maxEquippedItemSize; i++)
		{
			GameObject item_go = itemHolders[i];

			item_go.name = equippedWeapons[i];

			Image image = item_go.transform.GetComponentInChildren<Image>();
			image.sprite = stringToSpriteMap[equippedWeapons[i]];

			item_go.SetActive(true);
		}
	}

	public void OnItemDropped_Click(int slot)
	{
		Transform slot_go = this.transform.Find("Slot_" + slot);

		// We only have one GameObject so just get child at index 0.
		Transform equippedItem = slot_go.GetChild(0);

		string itemName = equippedItem.name;

		if (world.itemProtoTypes.ContainsKey(itemName) == false)
		{
			Debug.LogError("OnItemDroppedButton_Click() -- item that will be dropped is not in the prototypes.");
			return;

		}

		inventory.DropItem(itemName);
		equippedItem.gameObject.SetActive(false);
	}
}
