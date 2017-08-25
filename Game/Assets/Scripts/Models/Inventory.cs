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
		
	public Weapon ChangeWeapon(Character character, WeaponType weaponType)
	{
		int type = (int) weaponType;

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
