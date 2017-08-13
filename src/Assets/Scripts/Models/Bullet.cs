using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet
{
	Action<Bullet> cbBulletActions;

	// Vurduğu düşmana verdiği hasar.

    Character character;

	public float damage;

	string bulletType;

    //THINK : Bunun üzeirne düşünelim
    //uygunsa ingilizce açıklama yapalım
    bool canPassTheWall;

	public Bullet(string bulletType, float damage)
	{
        this.bulletType = bulletType;
        this.damage = damage;
	}

    protected Bullet(Bullet other)
    {
        this.bulletType =other.bulletType;
        this.damage = other.damage;
    }

    public Bullet Clone()
    {
        return new Bullet(this);
    }

	public void RegisterBulletActionsCallback(Action<Bullet> cb)
	{
		cbBulletActions += cb;
	}
}
