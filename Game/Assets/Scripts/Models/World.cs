using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World
{
    // We only can Instantiate Character Instance in the world
    // THINK: We can have multiple characters soon maybe???(think about it)
	// Yes, maybe AI allies?



    public Character character{ get; protected set;}

    public List<Character> enemies{ get; protected set; }

    Dictionary<string,Bullet> bulletPrototypes;
    
	public Dictionary<string,Weapon> weaponPrototypes;

	public World()
	{
        SetupWorld();
	}

    void SetupWorld()
    {
        bulletPrototypes = new Dictionary<string, Bullet>();
        weaponPrototypes = new Dictionary<string, Weapon>();

        
		CreatePrototypes();
		CreateCharacters();
		CreateEnemies();
    }

	void CreateCharacters()
	{
		// We only have one character, maybe later we'll have allias?
		// If we have, We need a character list.
		character = new Character();
		character.Type = "Main Character";

		// Default move speed in x-axis is +-5f.
		// Default jump speed in y-axis is 12f.
		character.speed = new Vector2(7f, 12f);

		// At the begining our characters looks right
		character.direction = Direction.Right;
		character.scale = new Vector3(1f, 1f, 1f);

		character.currentWeapon = weaponPrototypes["MP5"].Clone();
	}

	void CreateEnemies()
	{
		enemies = new List<Character>();

		for(int i = 0; i < 9; i++)	// FIXME: Test amaçlı şuan 0 enemy üretiliyor.
		{
			Character enemy = new Character();
			enemy.Type = "Enemy";
			enemy.speed.x = 3f;
            enemy.direction = (Direction) Random.Range(1, 3);

            //FIXME şimdilik oyunun akışı açısından silah atamasını rastgele yapıyorum

            if(Random.Range(0,2)==0)
			enemy.currentWeapon = weaponPrototypes["Magnum"].Clone();
            else
                enemy.currentWeapon = weaponPrototypes["MP5"].Clone();

			enemies.Add(enemy);
		}
	}

    //Bu çok uzun bir metod olacak parçalara ayıracağız muhtemelen her bir silah için ayrı bir metod yapmak daha okunaklı olacaktır
    void CreatePrototypes()
    {
  

        //Buraya bir mermi animasyon metodu yerleştirebiliriz yada ona benzer birşey....
        //THINK bunu burada mı yapmalıyız?
        //metodlar nerede olmalı

       // bulletPrototypes["Magnum"].RegisterBulletActionsCallback();

        CreateBulletProtos();

        CreateMagnumProto();
		
        CreateMP5Proto();


    }
    /// <summary>
    /// Creates the bullet protos.
    /// </summary>
    void CreateBulletProtos()
    {
        bulletPrototypes.Add(
            "Magnum",
            //  Type, damage, speed
            new Bullet(
                "Magnum", //Name
                5, //damage
                30f //velocity
            )
            
        );

        bulletPrototypes.Add("MP5",
            new Bullet(
                "MP5",//Name
                25,//damage
                20//velocity
            )
        );

    }
    /// <summary>
    /// Creates the knife proto.
    /// </summary>
    void CreateKnifeProto()
    {
        weaponPrototypes.Add(
            "Knife",
            new Weapon("Knife")
        );

        weaponPrototypes["Knife"].type="Knife";
        weaponPrototypes["Knife"].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes["Knife"].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes["Knife"].cbAttack += WeaponActions.CloseWeapons;

    }
    /// <summary>
    /// Creates the magnum proto.
    /// </summary>
    void CreateMagnumProto()
    {
        weaponPrototypes.Add(
            "Magnum",
            new Weapon("Magnum", bulletPrototypes["Magnum"])
        );

        weaponPrototypes["Magnum"].cbAttack += WeaponActions.Magnum_One_Shot;
        weaponPrototypes["Magnum"].type="Magnum";

        weaponPrototypes["Magnum"].weaponParameters.Add(
            "fireFrequency",
            .5f // .1 saniyede bir ateş edilebilir
        );


        weaponPrototypes["Magnum"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Magnum"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Magnum"].weaponParameters.Add(
            "bulletCount",
            10
        );
        weaponPrototypes["Magnum"].weaponParameters.Add(
            "maxBulletCount",
            10
        );
    }
    /// <summary>
    /// Creates the M p5 proto.
    /// </summary>
    void CreateMP5Proto()
    {
        weaponPrototypes.Add(
            "MP5",
            new Weapon("MP5",bulletPrototypes["MP5"])
        );
        weaponPrototypes["MP5"].cbAttack += WeaponActions.Magnum_One_Shot;
        weaponPrototypes["MP5"].type="MP5";

        weaponPrototypes["MP5"].weaponParameters.Add(
            "fireFrequency",
            .2f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["MP5"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["MP5"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["MP5"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["MP5"].weaponParameters.Add(
            "maxBulletCount",
            30
        );
    }


}
