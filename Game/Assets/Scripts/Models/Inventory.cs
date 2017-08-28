using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{

    public List<Weapon> purchasedWeapons;
    public List<Bullet> purchasedBullets;
    //whole items will be in the list

	const int numberOfWeapon = 3;
	public Weapon[] equippedWeapons;

	public Inventory()
	{
		equippedWeapons = new Weapon[numberOfWeapon];
       
	}



	// If a weapon equipped, add it our inventory.
    public void EquipItem(Item item)
    {
        //diğer itemleri de equip edildiğinde nerede tutulacak ise oraya yönlendirebiliriz
        if (item is Weapon)
        {
            equippedWeapons[(int)(item as Weapon).type] = item as Weapon;
        }
    }

    // If a weapon dropped, remove it from our inventory.
    public void DropItem(Item item)
    {
        if (item is Weapon)
        {
            equippedWeapons[(int)(item as Weapon).type] = null;
        }
    }

    public void AddItem(Item item)
	{
        if (item is Weapon)
            purchasedWeapons.Add(item as Weapon);
        else if (item is Bullet)
            purchasedBullets.Add(item as Bullet);

        //TODO   else if (item is (whatever))
        //          purchasedWhatever.Add(item as whatever);
        // make sure the item you wanna add in the list is inherited from Item class
	}

    public void RemoveItem(Item item)
	{
        if (item is Weapon)
            purchasedWeapons.Remove(item as Weapon);
        else if (item is Bullet)
            purchasedBullets.Remove(item as Bullet);
	}
		
	public Weapon ChangeWeapon(Character character, WeaponType weaponType)
	{
		int type = (int) weaponType;
		Debug.Log(type);
		// If requested weapon is already on character then just return.
		if(equippedWeapons[type] == null)
			return character.currentWeapon;

		equippedWeapons[(int) character.currentWeapon.type] = character.currentWeapon;

		// Keep weapon that will be changed
		Weapon changed = equippedWeapons[type];

		equippedWeapons[type] = null;

		return changed;
	}

}
