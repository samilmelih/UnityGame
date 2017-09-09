using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PurchasedItemUIController : MonoBehaviour
{
	Dictionary<string, Sprite> stringToSpriteMap;

	// FIXME: LinkedList would be more appropriate for this job.
	List<Item> purchasedItems;

    World world;
    Inventory inventory;

	int currentItemIndex;

	bool loaded;
	bool UILoaded;

	void OnEnable()
	{
		if(loaded == false)
		{
			world = WorldController.Instance.world;
			inventory = world.character.inventory;

			// FIXME: We can load sprites in a separate static class maybe.
			LoadItemSprites();

			inventory.RegisterOnItemEquippedCallback(OnItemEquipped);
			inventory.RegisterOnItemDroppedCallback(OnItemDropped);

			loaded = true;
		}

		LoadPurchasedItems();

		if(purchasedItems.Count != 0)
		{
			if(UILoaded == false)
			{
				LoadPurchasedItemUI();
				UILoaded = true;
			}

			currentItemIndex = 0;
			UpdateCurrentItem();
		}
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

		sprites = Resources.LoadAll<Sprite>("Sprites/BulletSprites");
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

	void LoadPurchasedItems()
	{
		purchasedItems = inventory.GetPurchasedItemList();

		// FIXME: We have some problems here. We don't wanna load bullets. We can just ignore
		// bullets but maybe we can have a variable named "can be equipped" in class Item.

		for(int i = 0; i < purchasedItems.Count; i++)
		{
			if(purchasedItems[i] is Bullet)
				purchasedItems.RemoveAt(i--);
		}
	}

	void LoadPurchasedItemUI()
	{
		GameObject purchasedItem_go = this.transform.GetChild(0).gameObject;
		purchasedItem_go.SetActive(true);
	}

	void OnItemEquipped(Item item)
	{
		Transform purchasedItem_go = this.transform.GetChild(0);
		Transform itemEquippedText = purchasedItem_go.transform.Find("ItemEquippedText");

		itemEquippedText.gameObject.SetActive(true);
	}

	void OnItemDropped(Item item, Inventory inventory)
	{
		Transform purchasedItem_go = this.transform.GetChild(0);

		if(purchasedItem_go.name == item.name)
		{
			Transform itemEquippedText = purchasedItem_go.transform.Find("ItemEquippedText");
			itemEquippedText.gameObject.SetActive(false);
		}
	}

	void UpdateCurrentItem()
	{
		Transform purchasedItem_go = this.transform.GetChild(0);

		purchasedItem_go.name = purchasedItems[currentItemIndex].name;

		Image itemImage            = purchasedItem_go.transform.Find("ItemImage").GetComponent<Image>();
		Text itemNameText          = purchasedItem_go.transform.Find("ItemNameText").GetComponent<Text>();
		Transform itemEquippedText = purchasedItem_go.transform.Find("ItemEquippedText");

		itemImage.sprite  = stringToSpriteMap[purchasedItems[currentItemIndex].name];
		itemNameText.text = purchasedItems[currentItemIndex].name;

		// FIXME: This feature is not saved to PlayerPrefs so we can't see whether an item
		// is equipped or not at start.
		itemEquippedText.gameObject.SetActive(purchasedItems[currentItemIndex].equipped);
	}

	public void NextItem()
	{
		if(purchasedItems.Count == 0 || purchasedItems.Count - 1 == currentItemIndex)
			return;

		currentItemIndex++;

		UpdateCurrentItem();
	}

	public void PreviousItem()
	{
		if(purchasedItems.Count == 0 || currentItemIndex == 0)
			return;

		currentItemIndex--;

		UpdateCurrentItem();
	}

	public void OnEquipItem_Click()
	{
		if(purchasedItems.Count != 0)
		{
			Transform purchasedItem_go = this.transform.GetChild(0);
			inventory.EquipItem(purchasedItem_go.name);
		}
	}

	public void OnCloseButton_Click()
	{
		this.transform.parent.gameObject.SetActive(false);
	}
}
