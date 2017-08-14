using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullet
{
	Action<Bullet> cbBulletActions;

	// Owner of this bullet.
    Character character;

	// Damage caused by shooter.
	public float damage;

	// How fast this bullet moves
	public float speed;

	// We can use this to distinguish sprites.
	string bulletType;

    // THINK : Bunun üzerine düşünelim.
    bool canPassTheWall;

	public Bullet(string bulletType, float damage, float speed)
	{
        this.bulletType = bulletType;
        this.damage = damage;
		this.speed = speed;
	}

    protected Bullet(Bullet other)
    {
        this.bulletType =other.bulletType;
        this.damage = other.damage;
		this.speed = other.speed;
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
