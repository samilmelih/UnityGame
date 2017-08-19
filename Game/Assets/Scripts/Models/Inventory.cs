using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
	// Close Weapons (e.g. knife, sword)
	// Guns
	// Rifles
	// Arrows
	const int numberOfWeapon = 3;
	public Weapon[] weapons;

	public Inventory()
	{
		weapons = new Weapon[numberOfWeapon];
	}
		
	public Weapon ChangeWeapon(Character character, int weapon_index)
	{
		weapon_index--;

		// If requested weapon is already on character then just return.
		if(weapons[weapon_index] == null)
			return character.currentWeapon;

		// Find the empty weapon and change with the character's current weapon
		// FIXME: For now, I couldn't find a better way. We may need to change this later.
		for(int i = 0; i < numberOfWeapon; i++)
		{
			if(weapons[i] == null)
			{
				weapons[i] = character.currentWeapon;
			}
		}

		// Keep weapon that will be changed
		Weapon changed = weapons[weapon_index];

		weapons[weapon_index] = null;

		return changed;
	}

}
