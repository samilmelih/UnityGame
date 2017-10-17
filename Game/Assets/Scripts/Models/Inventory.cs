using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    // If we make different UI's for weapons and items,
    // this List's would be enough. We have separate slots for weapons
    // and other items. I think we don't need to separate other items but
    // if we need to separate other items and also UI, we just need to make
    // another List for it.

    public int maxNumberOfWeapon = 3;
    public List<string> equippedWeapons;

    public int maxNumberOfItem = 3;
    public List<string> equippedItems;

    public Dictionary<string, Item> purchasedItemMap;

    Action<Item, bool> cbOnItemPurchased;
    Action<Item> cbOnItemEquipped;
    Action<Item, Inventory> cbOnItemDropped;

    World world;
    Character character;

    public Inventory(World world)
    {
        this.world = world;
        this.character = world.character;

        purchasedItemMap = new Dictionary<string, Item>();

        LoadInventory();

        // I registered them in here because since PlayerPrefsController is a static class,
        // I don't know where to register this callbacks in PlayerPrefsController.
        RegisterOnItemPurchasedCallback(PlayerPrefsController.OnItemPurchased);
        RegisterOnItemEquippedCallback(PlayerPrefsController.OnItemEquipped);
        RegisterOnItemDroppedCallback(PlayerPrefsController.OnItemDropped);
    }

    public void LoadInventory()
    {
        List<Item> purchasedItems = PlayerPrefsController.GetPurchasedItemList(world);
        if (purchasedItems != null)
        {
            foreach (Item item in purchasedItems)
            {
                purchasedItemMap.Add(item.name, item);
            }
        }

        equippedWeapons = PlayerPrefsController.GetEquippedWeaponList(world);
        equippedItems = PlayerPrefsController.GetEquippedItemList(world);

        //	ChangeWeapon(1);
    }

    // If an item is equipped, add it to it's list.
    public void EquipItem(string itemName)
    {
        if (purchasedItemMap.ContainsKey(itemName) == false)
        {
            Debug.LogError("EquipItem() -- You are trying to equip an item that it's not in the purchased item.");
            return;
        }

        Item item = purchasedItemMap[itemName];

        // Weapons
        if (item is Weapon)
        {
            if (equippedWeapons.Count >= maxNumberOfWeapon)
            {
                Debug.Log("EquipItem() -- You can't equip another weapon because all slots full.");
                return;
            }

            equippedWeapons.Add(itemName);
        }
        // Other items
        else
        {
            if (equippedItems.Count >= maxNumberOfItem)
            {
                Debug.Log("EquipItem() -- You can't equip another item because all slots full.");
                return;
            }

            equippedItems.Add(itemName);
        }

        item.equipped = true;

        ChangeWeapon(1);

        if (cbOnItemEquipped != null)
            cbOnItemEquipped(item);
    }

    // If an item is dropped just remove from it's list.
    public void DropItem(string itemName)
    {
        Item item = purchasedItemMap[itemName];

        // Weapons
        if (item is Weapon)
        {
            if (equippedWeapons.Contains(itemName) == false)
            {
                Debug.Log("DropItem() -- Weapon that you want to drop is not in the equippedWeapon list.");
                return;
            }

            equippedWeapons.Remove(itemName);
        }
        // Other items
        else
        {
            if (equippedItems.Contains(itemName) == false)
            {
                Debug.Log("DropItem() -- Item that you want to drop is not in the equippedItems list.");
                return;
            }

            equippedItems.Remove(itemName);
        }

        item.equipped = false;

        ChangeWeapon(1);

        if (cbOnItemDropped != null)
            cbOnItemDropped(item, this);
    }

    public void AddToPurchasedItems(Item item)
    {
        if (purchasedItemMap.ContainsKey(item.name) == true)
        {
            purchasedItemMap[item.name].count += item.purchaseAmount;

            if (cbOnItemPurchased != null)
                cbOnItemPurchased(purchasedItemMap[item.name], true);
        }
        else
        {
            item.count = item.purchaseAmount;
            purchasedItemMap.Add(item.name, item);

            if (cbOnItemPurchased != null)
                cbOnItemPurchased(item, false);
        }

        // If item is a bullet we need to attach it to weapon.
        if (item is Bullet)
        {
            string weaponName = item.name.Substring(0, item.name.IndexOf('_'));
            Debug.Log(weaponName);
            if (purchasedItemMap.ContainsKey(weaponName) == false)
            {
                Debug.Log("AddToPurchasedItems() -- You purchased this bullet but there is no weapon for it. ");
                return;
            }

            (purchasedItemMap[weaponName] as Weapon).bullet = purchasedItemMap[item.name] as Bullet;
        }
    }

    // FIXME: Character can pass as parameter.
    public void ChangeWeapon(int slot)
    {
        // If requested slot is empty, just return.
        if (slot > equippedWeapons.Count)
            return;

        character.currentWeapon = purchasedItemMap[equippedWeapons[slot - 1]] as Weapon;
    }

    public List<Item> GetPurchasedItemList()
    {
        return new List<Item>(purchasedItemMap.Values);
    }

    public List<string> GetEquippedWeaponList()
    {
		Debug.Log(equippedWeapons.GetHashCode());
		Debug.Log(equippedWeapons.Count + "***");
		Debug.Log(new List<string>(equippedWeapons).Count + "***");
        return new List<string>(equippedWeapons);
    }

    public List<string> GetEquippedItemsList()
    {
        return new List<string>(equippedItems);
    }

    public void RegisterOnItemPurchasedCallback(Action<Item, bool> cb)
    {
        cbOnItemPurchased += cb;
    }

    public void RegisterOnItemEquippedCallback(Action<Item> cb)
    {
        cbOnItemEquipped += cb;
    }

    public void RegisterOnItemDroppedCallback(Action<Item, Inventory> cb)
    {
        cbOnItemDropped += cb;
    }
}
