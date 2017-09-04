using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public delegate void InventoryEventHandler();
    public event InventoryEventHandler OnItemPurchased;
    public event InventoryEventHandler OnItemEquipped;



    //    public List<Weapon> purchasedWeapons;
    //    public List<Bullet> purchasedBullets;

    Dictionary<Item, int> itemToIntMap;

    Dictionary<Item, int> equippedItemtoIntMap;

    //whole items will be in the list

    const int numberOfWeapon = 3;
    public Weapon[] equippedWeapons;

    public Inventory()
    {
        equippedWeapons = new Weapon[numberOfWeapon];
        //        purchasedBullets = new List<Bullet>();
        //        purchasedWeapons = new List<Weapon>();

        itemToIntMap = new Dictionary<Item, int>();

        equippedItemtoIntMap = new Dictionary<Item, int>();

    }

    public int FindItemCount(Item item)
    {
        if (itemToIntMap.ContainsKey(item) == false)
        {
            Debug.LogError("Couldn't find the item with name : " + item.name);
            return -1;
        }

        return itemToIntMap[item];
    }



    // If a weapon equipped, add it our inventory.
    public void EquipItem(Item item, int stackSize = -1)
    {
        //diğer itemleri de equip edildiğinde nerede tutulacak ise oraya yönlendirebiliriz
        if (item is Weapon)
        {
            equippedWeapons[(int)(item as Weapon).type] = item as Weapon;
        }
        else
        {
            if (equippedItemtoIntMap.ContainsKey(item) == false)
            {
                equippedItemtoIntMap.Add(item, stackSize);
            }
            else
            {
                equippedItemtoIntMap[item] += stackSize;
            }
        }
        if (OnItemEquipped != null)
            OnItemEquipped();

        if (OnItemPurchased != null)
            OnItemPurchased();
    }

    // If a weapon dropped, remove it from our inventory.
    public void DropItem(Item item)
    {
        if (item is Weapon)
        {
            equippedWeapons[(int)(item as Weapon).type] = null;
        }

        if (OnItemEquipped != null)
            OnItemEquipped();

        if (OnItemPurchased != null)
            OnItemPurchased();
    }




    public void AddItem(Item item, int itemCount = -1)
    {
        if (itemCount != -1)
        {
            if (itemToIntMap.ContainsKey(item) == true)
            {
                itemToIntMap[item] += itemCount;
            }
            else
            {
                itemToIntMap.Add(item, itemCount);
            }
        }
        else
        {
            if (itemToIntMap.ContainsKey(item) == true)
            {
                Debug.LogError("You can not add this item more than one somthing gone wrong ???" + item.name);
            }
            else
            {
                itemToIntMap.Add(item, itemCount);
            }
        }


        if (OnItemPurchased != null)
            OnItemPurchased();
        //TODO   else if (item is (whatever))
        //          purchasedWhatever.Add(item as whatever);
        // make sure the item you wanna add in the list is inherited from Item class
    }


    //Tüm equip ettiğimiz itemleri bir listede tutarsak o listeyi burada eklememiz lazım
    public List<string> GetEquippedItemsNameList()
    {
        List<string> list = new List<string>();

        for (int i = 0; i < equippedWeapons.Length; i++)
        {
            if (equippedWeapons[i] != null)
                list.Add(equippedWeapons[i].name);
        }
        return list;
    }

    //Inventorydeki her bir itemin ismini bu listeye ekle
    public List<string> GetAllItemsNameList()
    {
        List<string> list = new List<string>();

        //        for (int i = 0; i < purchasedWeapons.Count; i++)
        //        {
        //            list.Add(purchasedWeapons[i].name);
        //        }
        //        for (int i = 0; i < purchasedBullets.Count; i++)
        //        {
        //            list.Add(purchasedBullets[i].name);
        //        }

        foreach (var item in itemToIntMap.Keys)
        {
            if (!(item is Bullet))
                list.Add(item.name);
        }


        return list;
    }
    public void RemoveItem(Item item)
    {
        //        if (item is Weapon)
        //            purchasedWeapons.Remove(item as Weapon);
        //
        //
        //        else if (item is Bullet)
        //            purchasedBullets.Remove(item as Bullet);

        if (itemToIntMap.ContainsKey(item) == false)
        {
            Debug.LogError(string.Format("Item {0} doesn't exist in the current invnetory", item.name));
            return;

        }

        itemToIntMap.Remove(item);

    }

    public Weapon ChangeWeapon(Character character, WeaponType weaponType)
    {
        int type = (int)weaponType;

        // If requested weapon is already on character then just return.
        if (equippedWeapons[type] == null)
            return character.currentWeapon;

        equippedWeapons[(int)character.currentWeapon.type] = character.currentWeapon;

        // Keep weapon that will be changed
        Weapon changed = equippedWeapons[type];

        equippedWeapons[type] = null;

        return changed;
    }

}
