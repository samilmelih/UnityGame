using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : Item
{
	public Dictionary<string, float> weaponParameters;

    public Bullet bullet;

	//şimdilik buna ihtiyaç var mı bilmiyorum olursa diye yazdım
	public bool isReloadable = false;

	// FIXME : her silahın bir range i olsa o mesafede mermi atabilse nasıl olur
	// FIXME : If we use this feature, don't forget to add to our constructor
	// parameters and also Clone method.
	public float range = 0;

	public Action<Character> cbAttack;

	// FIXME: If we use it, don't forget to copy in Clone method.
    public Func<Character, bool> cbOnReload;

	public Weapon(string name, int cost, int count, int purchaseAmount, bool isStackable, bool equipped,
		Bullet bullet) : base(name, cost, count, purchaseAmount, isStackable, equipped)
	{
        // if there is no bullet then it is a sword.
        if (bullet != null)
        {   
			this.bullet = bullet;
			isReloadable = true;
        }
        else
            isReloadable = false;
		
        weaponParameters = new Dictionary<string, float>();
	}

	protected Weapon(Weapon other) : base(other)
	{
        this.bullet           = other.bullet;
		this.isReloadable     = other.isReloadable;
		this.cbAttack         = other.cbAttack;
        this.weaponParameters = new Dictionary<string, float>(other.weaponParameters);
	}

    public override Item Clone()
	{
		return new Weapon(this);
	}

	public void RegisterWeaponActionsCallback(Action<Character> cb)
	{
		cbAttack += cb;
	}
}
