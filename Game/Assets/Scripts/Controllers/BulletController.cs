﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public GameObject go_shooter;
	public Character character;
	public Bullet bullet;

    //dont need to use this keyword if you dont have same named variable in this class(in methods)

	// Use this for initialization
	void Start()		
	{
		Rigidbody2D rgbd2D = GetComponent< Rigidbody2D >();

		Vector2 direction;

        if (character.direction == Direction.Left)
            direction = Vector2.left;
		else
            direction = Vector2.right;

		rgbd2D.velocity = direction * bullet.speed;

		// For now, we need to clear bullets that are not contact 
		// by other objects. In fact, we need a better aprroach on this too.
		Destroy(gameObject, 2);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if you hit something hittable
        // which means has an enemyController


        //TODO:
        //object üzerinden kontrol edince şöyle bir sorun oluşuyor biz bu objeyi destroy ettiğimzde mermi kime ait olduğunu bilmiyor
        //bunun yerine Bir ENUM yapısı kullanmak nasıl olur?? IDK

		if(other.gameObject.tag == "Player" && go_shooter.tag != "Player")
		{
			SoundController.Instance.Hit();
			WorldController.Instance.world.character.health -= bullet.damage;
            Destroy(gameObject);
		}
		else if(other.gameObject.tag == "Enemy" && go_shooter.tag != "Enemy")
		{
			SoundController.Instance.Hit();
            EnemyController.Instance.GOenemyMap[other.gameObject].health -= bullet.damage;
            Destroy(gameObject);
		}
		else if(other.gameObject.tag == "ground")
		{
			SoundController.Instance.Ground_Hit();
			Destroy(gameObject);
		}
    }
}
