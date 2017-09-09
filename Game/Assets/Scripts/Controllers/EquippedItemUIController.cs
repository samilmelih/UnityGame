﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquippedItemUIController : MonoBehaviour
{    
	Dictionary<string, Sprite> stringToSpriteMap;

	List<string> equippedWeapons;

	World world;
	Inventory inventory;

	bool loaded;

	void OnEnable()
	{
		if(loaded == false)
		{
			world = WorldController.Instance.world;
			inventory = world.character.inventory;

			LoadItemSprites();

			inventory.RegisterOnItemEquippedCallback(OnItemEquipped);
			inventory.RegisterOnItemDroppedCallback(OnItemDropped);

			loaded = true;
		}

		LoadItems();
	}

    void LoadItemSprites()
    {
		stringToSpriteMap = new Dictionary<string, Sprite>();

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
		int i;

		equippedWeapons = inventory.GetEquippedWeaponList();
		for (i = 0; i < equippedWeapons.Count; i++)
		{
			GameObject equippedItem_go = this.transform.Find("Slot_" + (i + 1)).GetChild(0).gameObject;

			equippedItem_go.name = equippedWeapons[i];

			Image image = equippedItem_go.GetComponentInChildren<Image>();
			image.sprite = stringToSpriteMap[equippedWeapons[i]];

			equippedItem_go.SetActive(true);
		}

		while(i < inventory.maxNumberOfWeapon)
		{
			GameObject equippedItem_go = this.transform.Find("Slot_" + (i + 1)).GetChild(0).gameObject;
			equippedItem_go.SetActive(false);

			i++;
		}
	}

	// sadece boş olan slot a eklenmesi yeterli yani bir item equip edildiğinde
	// bize o item listede olacak şekilde gelecektir. Bizde listedeki son elemanın
	// indisine göre güncellememizi yapabiliriz
	void OnItemEquipped(Item item)
	{
		equippedWeapons = inventory.GetEquippedWeaponList();

		GameObject equippedItem_go =
			this.transform.Find("Slot_" + (equippedWeapons.Count)).GetChild(0).gameObject;

		equippedItem_go.name = item.name;

		Image image = equippedItem_go.GetComponentInChildren<Image>();
		image.sprite = stringToSpriteMap[item.name];

		equippedItem_go.SetActive(true);
	}

	// equipped weapons tekrardan çekilip yüklenmeli.
	// zaten slotlar dolu olacağında sadece güncellenmesi yeterli
	void OnItemDropped(Item item, Inventory inventory)
	{
		LoadItems();
	}

	public void OnItemDropped_Click(int slot)
	{
		Transform slot_go = this.transform.Find("Slot_" + slot);

		// We only have one GameObject so just get child at index 0.
		Transform equippedItem = slot_go.GetChild(0);

		string itemName = equippedItem.name;

		inventory.DropItem(itemName);
	}
}
