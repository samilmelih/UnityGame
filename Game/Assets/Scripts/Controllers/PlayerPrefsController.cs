using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{


    /// <summary>
    /// Sets or gets the money to PlayerPrefs as an int
    /// </summary>
    static public int Money
    {
        set
        {
            PlayerPrefs.SetInt("money", value);
        }
        get
        {

            return PlayerPrefs.GetInt("money");
        }

    }

    static public int GetItemCount(string itemName)
    {
        return PlayerPrefs.GetInt(itemName);
    }

    static public void SetItemCount(string itemName, int count)
    {

        int newStackSize = GetItemCount(itemName);

        newStackSize += count;

        PlayerPrefs.SetInt(itemName, newStackSize);

    }

    static public List<Item> GetSavedInventoryItemList(World world)
    {


        List<Item> items = new List<Item>();

        string[] inventoryString = PlayerPrefs.GetString("inventory").Split(',');

        for (int i = 0; i < inventoryString.Length; i++)
        {
            if (inventoryString[i] != "")
                items.Add(world.itemProtoTypes[inventoryString[i]]);

        }

        int length = items.Count;
        for (int i = 0; i < length; i++)
        {
            Item item = items[i];
            if ((item as Weapon).bullet != null && PlayerPrefs.GetInt((item as Weapon).bullet.name) > 0)
                items.Add((item as Weapon).bullet);
        }

        return items;

    }
    static public List<Item> GetSavedEquippedInventoryItemList(World world)
    {


        List<Item> items = new List<Item>();

        string[] equippedInventoryString = PlayerPrefs.GetString("equippedItems").Split(',');

        for (int i = 0; i < equippedInventoryString.Length; i++)
        {
            if (equippedInventoryString[i] != "")
                items.Add(world.itemProtoTypes[equippedInventoryString[i]]);
        }

        return items;

    }



    static public void SaveInventoryItem(string itemName)
    {

        string inventoryString = PlayerPrefs.GetString("inventory");

        if (inventoryString == "")
            inventoryString += itemName;
        else
            inventoryString += "," + itemName;

        PlayerPrefs.SetString("inventory", inventoryString);

    }


    static public void SaveEquippedInventoryItem(List<string> itemNameList)
    {

        string equippedInventoryString = "";

        foreach (var equippedItemName in itemNameList)
        {

            if (equippedInventoryString == "")
                equippedInventoryString += equippedItemName;
            else
                equippedInventoryString += "," + equippedItemName;
        }

        PlayerPrefs.SetString("equippedItems", equippedInventoryString);

    }

    static public void CleanPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }

    static public void DeleteSavedKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
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


}
