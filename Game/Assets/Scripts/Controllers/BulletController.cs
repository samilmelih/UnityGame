using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public GameObject go_shooter;
	public Character character;
	public Bullet bullet;

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
		Destroy(this.gameObject, 2);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // check if you hit something hittable
        // which means has an enemyController

		if(other.gameObject.tag == "Player" && go_shooter.tag != "Player")
		{
			WorldController.Instance.world.character.health -= bullet.damage;
            Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == "Enemy" && go_shooter.tag != "Enemy")
		{
            EnemyController.Instance.GOenemyMap[other.gameObject].health -= bullet.damage;
            Destroy(this.gameObject);
		}
		else if(other.gameObject.tag == "ground")
		{
			Destroy(this.gameObject);
		}
    }
}
