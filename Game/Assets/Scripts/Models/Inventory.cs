using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	const int numberOfWeapon = 3;
	public Weapon[] weapons;

	public Inventory()
	{
		weapons = new Weapon[numberOfWeapon];
	}

	// If a weapon equipped, add it our inventory.
	public void AddWeapon()
	{
		
	}

	// If a weapon dropped, remove it from our inventory.
	public void RemoveWeapon()
	{
	}
		
	public Weapon ChangeWeapon(Character character, WeaponType weaponType)
	{
		int type = (int) weaponType;
		Debug.Log(type);
		// If requested weapon is already on character then just return.
		if(weapons[type] == null)
			return character.currentWeapon;

		weapons[(int) character.currentWeapon.type] = character.currentWeapon;

		// Keep weapon that will be changed
		Weapon changed = weapons[type];

		weapons[type] = null;

		return changed;
	}

}
