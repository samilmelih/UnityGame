using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{
	// FIXME: We need to make this general because we forget how we typed.
	// Maybe a string literal class, it will only contain const strings.
	const string purchasedItemString  = "PurchasedItem";
	const string equippedItemString   = "EquippedItem";
	const string equippedWeaponString = "EquippedWeapon";
	const string countSuffixString    = "_count";
	const string bulletSuffixString   = "_Bullet";
	const string moneyString 		  = "Money"; 

    /// <summary>
    /// Sets or gets the money to PlayerPrefs as an int
    /// </summary>
    static public int Money
    {
        set
   		{
			PlayerPrefs.SetInt(moneyString, value);
        }
        get
		{
			return PlayerPrefs.GetInt(moneyString);
        }
    }

	static public bool IsGameFirstStarted
	{
		get
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
	}

	static public void DebugSaveStrings()
	{
		Debug.Log(purchasedItemString + ": " + PlayerPrefs.GetString(purchasedItemString));
		Debug.Log(equippedItemString  + ": " + PlayerPrefs.GetString(equippedItemString));
		Debug.Log(equippedWeaponString  + ": " + PlayerPrefs.GetString(equippedWeaponString));

		string[] purchasedItems = PlayerPrefs.GetString(purchasedItemString).Split(',');
		if(purchasedItems[0] == "")
			return;
		
		for(int i = 0; i < purchasedItems.Length; i++)
			Debug.Log(purchasedItems[i] + countSuffixString + ": " + GetItemCount(purchasedItems[i]));
	}

    static public int GetItemCount(string itemName)
    {
		return PlayerPrefs.GetInt(itemName + countSuffixString);
    }

    static public List<Item> GetPurchasedItemList(World world)
    {
		if(PlayerPrefs.HasKey(purchasedItemString) == false)
			return null;

		List<Item> items = new List<Item>();
		string[] purchasedItems = PlayerPrefs.GetString(purchasedItemString).Split(',');

		for (int i = 0; i < purchasedItems.Length; i++)
        {
			Item item = world.itemProtoTypes[purchasedItems[i]].Clone();
			item.count = GetItemCount(item.name);

			if(item is Weapon && (item as Weapon).isReloadable == true)
			{
				Weapon weapon = item as Weapon;
				weapon.bullet.count = GetItemCount(item.name + bulletSuffixString);
			}

            items.Add(item);
        }

        return items;
    }

	static public List<string> GetEquippedWeaponList(World world)
	{
		if(PlayerPrefs.HasKey(equippedWeaponString) == false)
			return new List<string>();

		string[] equippedWeapons = PlayerPrefs.GetString(equippedWeaponString).Split(',');

		return new List<string>(equippedWeapons);
	}

    static public List<string> GetEquippedItemList(World world)
    {
		if(PlayerPrefs.HasKey(equippedItemString) == false)
			return new List<string>();
		
		string[] equippedItems = PlayerPrefs.GetString(equippedItemString).Split(',');

		return new List<string>(equippedItems);
    }

	static public void OnItemPurchased(Item item)
	{
		int itemCount = 0;

		if(PlayerPrefs.HasKey(item.name + countSuffixString) == true)
		{
			itemCount = PlayerPrefs.GetInt(item.name + countSuffixString);
		}
		else
		{
			itemCount = PlayerPrefs.GetInt(item.name + countSuffixString);

			string saveString = PlayerPrefs.GetString(purchasedItemString);

			if (saveString == "")
				saveString += item.name;
			else
				saveString += "," + item.name;

			PlayerPrefs.SetString(purchasedItemString, saveString);
		}

		PlayerPrefs.SetInt(item.name + countSuffixString, itemCount + item.purchaseAmount);
    }

	static public void OnItemEquipped(Item item)
	{
		string saveString;
		string playerPrefsKey;

		if(item is Weapon)
		{
			playerPrefsKey = equippedWeaponString;
		}
		else
		{
			playerPrefsKey = equippedItemString;
		}

		saveString = PlayerPrefs.GetString(playerPrefsKey);

		if (saveString == "")
			saveString = item.name;
		else
			saveString += "," + item.name;

		PlayerPrefs.SetString(playerPrefsKey, saveString);
    }

	static public void OnItemDropped(Item item, Inventory inventory)
	{
		string saveString = null;
		string playerPrefsKey;
		List<string> items;

		if(item is Weapon)
		{
			playerPrefsKey = equippedWeaponString;
			items = inventory.equippedWeapons;
		}
		else
		{
			playerPrefsKey = equippedItemString;
			items = inventory.equippedItems;
		}

		foreach(string itemName in items)
		{
			if(saveString == null)
				saveString = itemName;
			else
				saveString += "," + itemName;
		}

		PlayerPrefs.SetString(playerPrefsKey, saveString);
	}

    static public void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    static public void DeleteSavedKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }    
}
