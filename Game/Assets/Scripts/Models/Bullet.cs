using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet : Item
{
	Action<Bullet> cbBulletActions;

	// Owner of this bullet.
    Character character;

	// Damage caused by shooter.
	public float damage;

	// How fast this bullet moves
	public float speed;

    public Bullet(string bulletType, float damage, float speed)
	{
        this.name        = bulletType;
        this.damage      = damage;
		this.speed       = speed;
		this.isStackable = true;
	}

    protected Bullet(Bullet other)
    {
        this.name        = other.name;
        this.damage      = other.damage;
		this.speed       = other.speed;
		this.isStackable = other.isStackable;
    }

    public override Item Clone()
    {
        return new Bullet(this);
    }

	public void RegisterBulletActionsCallback(Action<Bullet> cb)
	{
		cbBulletActions += cb;
	}
}
