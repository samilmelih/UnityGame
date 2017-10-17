using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAnimationController : MonoBehaviour
{
	public static ItemAnimationController Instance;

	World world;
	Character character;

	public enum DefaultGOType { Weapon, Item }	// FIXME: Where this is used?

    //First five objects are Items. Last  one is Default one we are gonna shot on it what we choose as default
    //--default object is the item that we used lately--
    [SerializeField]
	List<GameObject> itemList;

    List<string> equippedWeapons;

    Dictionary<GameObject, Item> GOToItemMap;

	[SerializeField]
	List<Button> weaponPackButtonList;

	[SerializeField]
	List<Button> itemPackButtonList;

	[SerializeField]
	Button btnWeaponUpDownArrow;

	[SerializeField]
	Button btnItemUpDownArrow;

	[SerializeField]
	GameObject defaultWeaponPickerGO;

	[SerializeField]
	GameObject defaultItemPickerGO;

	// we need this info when we click on DefaultItemGO
	Item DefaultItem;



	bool openWeapon;
	bool openItem;
	bool itemVertical = true;
	bool weaponVertical = true;

    // Use this for initialization
    void Start()
    {
		Instance = this;
        world = WorldController.Instance.world;
		character = world.character;
		equippedWeapons = character.inventory.equippedWeapons;



	

		btnWeaponUpDownArrow.onClick.AddListener(delegate
		{
			btnUpDownArrow_Click(DefaultGOType.Weapon);
		});

		btnItemUpDownArrow.onClick.AddListener(delegate
		{
			btnUpDownArrow_Click(DefaultGOType.Item);
		});


		for (int i = 0; i < weaponPackButtonList.Count; i++)
		{
			weaponPackButtonList[i].gameObject.name = equippedWeapons[i];
			weaponPackButtonList[i].onClick.AddListener(delegate
			{
				onGunSelection(i + 1);
			});
		}
//
//		for (int i = 0; i < itemPackButtonList.Count; i++)
//		{
//			GameObject selected = itemPackButtonList[i].gameObject;
//			itemPackButtonList[i].onClick.AddListener(delegate
//			{
//				OnItemSelection(selected);
//			});
//		}


//        List<string> equippedItemsNameList = world.character.inventory.equippedItems;
//        equippedItems = new List<Item>();
//
//        GOToItemMap = new Dictionary<GameObject, Item>();
//
//        foreach (string itemName in equippedItemsNameList)
//        {
//            equippedItems.Add(world.itemProtoTypes[itemName]);
//        }
//
//        for (int i = 0; i < itemList.Count - 1; i++)
//        {
//            if (i >= equippedItems.Count) break;
//            GOToItemMap[itemList[i]] = equippedItems[i];
//
//            itemList[i].GetComponentInChildren<Image>().sprite =
//                ItemSpriteController.Instance.GetSpriteForItem(equippedItems[i]);
//        }

        //FIXME:  Item for non-selected Default Item picker we need a Sprite for this

    }

	/// <summary>
	/// handels click event of arrow Button
	/// </summary>
	/// <param name="openMenu">if this is not triggerd by button then I called this as method I want to do things </param>
	/// <param name="triggeredByButton">this is a control if we triggered by button or nah</param>
	public void btnUpDownArrow_Click(DefaultGOType defGOType)
	{
		if (defGOType == DefaultGOType.Weapon)
		{
			openWeapon = !openWeapon;
			defaultWeaponPickerGO.SetActive(!openWeapon);

			ItemAnimatorCont animator = ItemAnimatorCont.Instance;
			animator.PlayWeaponAnimations(openWeapon, weaponVertical);
		}
		else
		{
			openItem = !openItem;
			defaultItemPickerGO.SetActive(!openItem);

			ItemAnimatorCont animator = ItemAnimatorCont.Instance;
			animator.PlayItemAnimations(openItem, itemVertical);
		}
	}

	public void onGunSelection(int index)//TODO: find an useful parameter to detect what I've choosed
	{
		//Close Anims
		//btnUpDownArrow_Click(DefaultGOType.Weapon, false, false);


		//Pick the Gun
		ChangeWeapon(index);


		//show on The default Item 

	}

	public void ChangeWeapon(int slot)
	{
		character.ChangeWeapon(slot);
	}

	public void OnItemSelection(GameObject selectedGO)
	{
		Item item = ItemAnimationController.Instance.GetItemByGO(selectedGO);
		ItemAnimationController.Instance.DefaultItemSprite(item);
		DefaultItem = item;
	}
		








    public void DefaultItemSprite(Item defaultItem)
    {
        if (defaultItem == null) return;

        itemList[itemList.Count - 1].GetComponentInChildren<Image>().sprite =
           ItemSpriteController.Instance.GetSpriteForItem(defaultItem);
    }

    public Item GetItemByGO(GameObject go)
    {
        if (go == null) return null;
        if (GOToItemMap.ContainsKey(go) == false) return null;

        return GOToItemMap[go];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
