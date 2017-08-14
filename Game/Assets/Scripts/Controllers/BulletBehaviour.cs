using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour {

	Rigidbody2D rgbd2D;

	public GameObject go_shooter;
	public Character character;
	public Bullet bullet;

    Vector2 direction;

	World world;

	// Use this for initialization

	// WeaponActionda atanan değerlerin start dan sonra atanması ihtimaline karşı
	// Awake yapıyorum. Eğer çalışırsa böyle bırakacağım. Şuan bu sadece bir test
	void Start()		
	{
		world = WorldController.Instance.world;

        rgbd2D = GetComponent< Rigidbody2D >();


		// ***FIXME***: Kurşunların atış yönü düzgün değil. Şuanki gözlemlerime göre
		// hep sağa atıyor.

		// ***FIXME***: Kurşunu sağa attıktan sonra sola döndüğümde kurşun y eksenin de tersine
		// geçiyor. Bunun sebebi sanırım scale ile alakalı olabilir. Çünkü kurşunlar child i character in
		// Character > Gun > Bullet şeklinde.

		// FIXME: Test amaçlı enemy üretimini durdurdum. Yani hata değil haberin olsun :D



        if (character.direction == Direction.Left)
            direction = Vector2.left;
		else
            direction = Vector2.right;

		

        rgbd2D.velocity = direction * 30;
		// For now, we need to clear bullets that are not contact 
		// by other objects. In fact, we need a better aprroach on this too.
		Destroy(this.gameObject, 2);
	}
	
	// Update is called once per frame
	void Update()
	{
        
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        //check if you hit something hittable
        //which means has an enemyController

		if(other.gameObject.tag == "Player" && go_shooter.tag != "Player")
		{
			world.character.health -= bullet.damage;
            Destroy(this.gameObject);
			
		}
		else if(other.gameObject.tag == "Enemy" && go_shooter.tag != "Enemy")
		{
            EnemyController.Instance.GOenemyMap[other.gameObject].health -= bullet.damage;
            Destroy(this.gameObject);
		}


        //burada  gameObject yardımı ile hangi Enemy vurulduğunu bilebiliriz???
        //bize GO to Enemy map i lazım değil mi??
    }
}
