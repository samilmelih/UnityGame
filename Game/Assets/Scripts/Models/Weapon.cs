using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon
{
    public string name;

	public WeaponType type;

    public Bullet bullet;


    //FIXME : her silahın bir range i olsa o mesafede mermi atabilse nasıl olur
    public float Range = 0;

	// Buradaki action larıda olay olay bölmemiz gerekli,
	// tek bir action yetersiz olacaktır.
	// Fire ı daha genel olarak attack ile değiştirdim.
	public Action<Character> cbAttack;
    public Func<Character,bool> cbOnReload;

    //şimdilik buna ihtiyaç var mı bilmiyorum olursa diye yazdım
    public bool isReloadable = false;

    public Dictionary<string, float> weaponParameters;

	// For now, we just have "type" for prototype parameters.
    public Weapon(string name, Bullet bullet = null)
	{
        // if there is no bullet then it is a sword.
        if (bullet != null)
        {   
            isReloadable = true;
            this.bullet = bullet;
        }
        else
            isReloadable = false;
         
        this.name = name;
        weaponParameters = new Dictionary<string, float>();
	}

	protected Weapon(Weapon weapon)
	{
        if (weapon.bullet != null)
        {
            this.bullet = weapon.bullet;
        }

		this.name = weapon.name;
		this.type = weapon.type;
		this.isReloadable = weapon.isReloadable;
		this.cbAttack = weapon.cbAttack;
        this.weaponParameters =new Dictionary<string, float>( weapon.weaponParameters);
	}

	public Weapon Clone()
	{
		return new Weapon(this);
	}

	public void RegisterWeaponActionsCallback(Action<Character> cb)
	{
		cbAttack += cb;
	}
   
}
