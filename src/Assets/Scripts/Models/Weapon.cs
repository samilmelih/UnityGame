using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon
{
    public string type;

	// FIXME: Prototipleri oluşturabilmek için şimdilik
	// public yaptım. Sonra karar veririz ne olacağına.
    Character character;

    public Bullet bullet;

	// Buradaki action larıda olay olay bölmemiz gerekli,
	// tek bir action yetersiz olacaktır.
	// Fire ı daha genel olarak attack ile değiştirdim.
	public Action<Character, Weapon> cbAttack;

	// Not sure about parameter type.
   
    public Dictionary<string, float> weaponParameters;

	// For now, we just have "type" for prototype parameters.
    //HACK
    public Weapon(string type,Bullet bullet=null)
	{

        //if there is no bullet then it is a sword.
        if (bullet != null)
            this.bullet = bullet;
		this.type = type;
        weaponParameters = new Dictionary<string, float>();
	}

	protected Weapon(Weapon weapon)
	{
        if (weapon.bullet != null)
        {
            this.bullet = weapon.bullet;
        }

		this.type = weapon.type;
		this.cbAttack = weapon.cbAttack;
		this.weaponParameters = weapon.weaponParameters;
	}

	public Weapon Clone()
	{
		return new Weapon(this);
	}

	public void RegisterWeaponActionsCallback(Action<Character, Weapon> cb)
	{
		cbAttack += cb;
	}
}
