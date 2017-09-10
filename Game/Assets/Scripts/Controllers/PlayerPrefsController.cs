using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{
    // FIXME: We need to make this general because we forget how we typed.
    // Maybe a string literal class, it will only contain const strings.


    /// <summary>
    /// Sets or gets the money to PlayerPrefs as an int
    /// </summary>
    static public int Money
    {
        set
        {
            PlayerPrefs.SetInt(StringLiterals.MoneyString, value);
        }
        get
        {
            return PlayerPrefs.GetInt(StringLiterals.MoneyString);
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
        //Debug.Log(purchasedItemString + ": " + PlayerPrefs.GetString(purchasedItemString));
        //Debug.Log(equippedItemString  + ": " + PlayerPrefs.GetString(equippedItemString));
        //Debug.Log(equippedWeaponString  + ": " + PlayerPrefs.GetString(equippedWeaponString));

        string[] purchasedItems = PlayerPrefs.GetString(StringLiterals.PurchasedItemString).Split(',');
        if (purchasedItems[0] == "")
            return;

        /*for(int i = 0; i < purchasedItems.Length; i++)
			Debug.Log(purchasedItems[i] + StringLiterals.CountSuffixString + ": " + GetItemCount(purchasedItems[i]));*/
    }

    static public int GetItemCount(string itemName)
    {
        return PlayerPrefs.GetInt(StringLiterals.GetItemCountString(itemName));
    }

    static public List<Item> GetPurchasedItemList(World world)
    {
        if (PlayerPrefs.HasKey(StringLiterals.PurchasedItemString) == false)
            return null;

        List<Item> items = new List<Item>();
        string[] purchasedItems = PlayerPrefs.GetString(StringLiterals.PurchasedItemString).Split(',');

        for (int i = 0; i < purchasedItems.Length; i++)
        {
            Item item = world.itemProtoTypes[purchasedItems[i]].Clone();
            item.count = GetItemCount(item.name);

            if (item is Weapon && (item as Weapon).isReloadable == true)
            {
                Weapon weapon = item as Weapon;
                weapon.bullet.count = GetItemCount(StringLiterals.GetItemCountString(item.name));
            }

            items.Add(item);
        }

        return items;
    }

    static public List<string> GetEquippedWeaponList(World world)
    {
        if (PlayerPrefs.HasKey(StringLiterals.EquippedWeaponString) == false)
            return new List<string>();

        string[] equippedWeapons = PlayerPrefs.GetString(StringLiterals.EquippedWeaponString).Split(',');

        return new List<string>(equippedWeapons);
    }

    static public List<string> GetEquippedItemList(World world)
    {
        if (PlayerPrefs.HasKey(StringLiterals.EquippedItemString) == false)
            return new List<string>();

        string[] equippedItems = PlayerPrefs.GetString(StringLiterals.EquippedItemString).Split(',');

        return new List<string>(equippedItems);
    }

    static public void OnItemPurchased(Item item)
    {
        int itemCount = 0;

        if (PlayerPrefs.HasKey(StringLiterals.GetItemCountString(item.name)) == true)
        {
            itemCount = PlayerPrefs.GetInt(StringLiterals.GetItemCountString(item.name));
        }
        else
        {
            itemCount = PlayerPrefs.GetInt(StringLiterals.GetItemCountString(item.name));

            string saveString = PlayerPrefs.GetString(StringLiterals.PurchasedItemString);

            if (saveString == "")
                saveString += item.name;
            else
                saveString += "," + item.name;

            PlayerPrefs.SetString(StringLiterals.PurchasedItemString, saveString);
        }

        PlayerPrefs.SetInt(StringLiterals.GetItemCountString(item.name), itemCount + item.purchaseAmount);
    }

    static public void OnItemEquipped(Item item)
    {
        string saveString;
        string playerPrefsKey;

        if (item is Weapon)
        {
            playerPrefsKey = StringLiterals.EquippedWeaponString;
        }
        else
        {
            playerPrefsKey = StringLiterals.EquippedItemString;
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

        if (item is Weapon)
        {
            playerPrefsKey = StringLiterals.EquippedWeaponString;
            items = inventory.equippedWeapons;
        }
        else
        {
            playerPrefsKey = StringLiterals.EquippedItemString;
            items = inventory.equippedItems;
        }

        foreach (string itemName in items)
        {
            if (saveString == null)
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
