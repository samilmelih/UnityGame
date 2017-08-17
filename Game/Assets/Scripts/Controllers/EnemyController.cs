using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Dictionary<Character, GameObject> enemyGOMap;
    public Dictionary<GameObject,Character > GOenemyMap;

    World world;

    public Transform[] spawnPos;

    public static EnemyController Instance;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        world = WorldController.Instance.world;
        enemyGOMap = new Dictionary<Character, GameObject>();
        GOenemyMap = new Dictionary<GameObject, Character>();

        // Creates enemies with GO
        CreateEnemies();
    }

    // FIXME: If we want to spawn enemies into scene at any time, we need a new approach.
    void CreateEnemies()
    {
        int numberOfEnemy = 0;
        foreach (Character enemy in world.enemies)
        {
            GameObject enemy_prefab = (GameObject)Resources.Load("Prefabs/Enemy");		// FIXME: This need to be change in the future.
           
            //TODO : burada bir transform list içince spawn positions belirlenecek
            //bu posizsyonlar ne olursa olsun bu şekilde yapılabilir
            GameObject enemy_go = (GameObject)Instantiate(enemy_prefab, spawnPos[numberOfEnemy], false);
      
            enemy_go.name = "Enemy_" + (++numberOfEnemy);
            enemy_go.tag = "Enemy";

            // FIXME: We need to randomize positions later. We can't instantiate
            // enemies at the same position.

            enemy_go.transform.SetParent(this.transform);

            enemyGOMap.Add(enemy, enemy_go);
            GOenemyMap.Add(enemy_go, enemy);
        }

    }

    // Update is called once per frame
    void Update()
    {
        // Not sure that we need to check these states in here,
        // for now I couldn't find a better place.
				
        // Just check enemy states on every frame
		List<Character> keys = new List<Character>(enemyGOMap.Keys);
		foreach (Character enemy in keys)
        {   
            // If enemy's health is 0 or under 0 just Destroy it
            // and remove from enemyGameObjectMap, and also from
            // the world enemy list.
			if (enemy.health <= 0)
            {
				enemyGOMap[enemy].SetActive(false);
                enemy.isAlive = false;

                // remove from the maps
				GOenemyMap.Remove(enemyGOMap[enemy]);
            	enemyGOMap.Remove(enemy);

                //Düşman öldürdüğümü bilmem lazım ki paramı artırabileyim burayı düşün
                //FIXME buraya daha iyi bir şey düşün

                world.character.money += 50;

                // remove from the world
                world.enemies.Remove(enemy);
            }
        }
    }

    void FixedUpdate()
    {
        // Update physical things
        foreach (KeyValuePair<Character, GameObject> enemy in enemyGOMap)
        {
            Walk(enemy);
        }
    }

    void Walk(KeyValuePair<Character, GameObject> enemyGOPair)
    {
		
        // TODO: burayı çok genel yapabiliriz

        // Eğer karakteri görmüyorsa ona yeni gidecek pozisyon tanımlamaları yaparız kısa aralıklarda destPos şeklinde veirriz oraya yürür
        // Karakteri görüyorsa destPos karakterin konumu olur
        // karakter görüşünden çıktığı anda yeni bir destPos oluştururuz

        Character enemy = enemyGOPair.Key;
        GameObject enemy_go = enemyGOPair.Value;
		                
		// Eğer karakter görüş açımızda ise ona doğru yürü
        EnemyImpact impact = Watch(enemyGOPair);
      
		bool turnBack = false;

		switch (impact)
        {
            case EnemyImpact.Enemy:
				turnBack = true;
                break;
            case EnemyImpact.Player:
				enemy.currentWeapon.cbAttack(enemy);
                break;
            case EnemyImpact.Wall:
				turnBack = true;
                break;
            case EnemyImpact.None:

				// FIXME: We need to fix this variable.
                LayerMask whatIsGround = 255;	// 1111 1111

                Transform groundCheck = enemy_go.transform.Find("GroundCheck");

                float groundRadius = 0.2f;

                Collider2D grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

				// FIXME: Düşman spawn edildiğinde havada olduğu için bu kod yüzünden saçmalıyor.
				// Çok büyük bir hata olmadığı için şimdilik not olarak buraya bırakıyorum.
                if (grounded == null)
                {
					turnBack = true;
                }

				break;
        }

		if(turnBack == true)
		{
			enemy.velocity.x *= -1f;
			enemy.scale.x *= -1f;

			if(enemy.direction == Direction.Left)
				enemy.direction = Direction.Right;
			else
				enemy.direction = Direction.Left;
		}
		else
		{
			if(enemy.direction == Direction.Left)
			{
				enemy.velocity.x = -enemy.speed.x;
				enemy.scale.x = -1f;
			}
			else
			{
				enemy.velocity.x = enemy.speed.x;
				enemy.scale.x = 1f;
			}
		}

		Transform enemy_transform = enemy_go.GetComponent<Transform>();
		Rigidbody2D enemy_rgbd2D  = enemy_go.GetComponent<Rigidbody2D>();

		enemy_transform.localScale = new Vector3(enemy.scale.x, enemy.scale.y, 0f);
		enemy_rgbd2D.velocity = new Vector2(enemy.velocity.x, enemy_rgbd2D.velocity.y);   
    }

    EnemyImpact Watch(KeyValuePair<Character, GameObject> enemyGOPair)
    {
        Character enemy = enemyGOPair.Key;
        GameObject go = enemyGOPair.Value;

        Vector2 direction;

        if (enemy.direction == Direction.Left)
            direction = Vector2.left;
        else
            direction = Vector2.right;

        Transform gunPosition = go.transform.Find("Gun");

        RaycastHit2D hit = Physics2D.Raycast(gunPosition.position, direction, 10);

		// Debug.DrawRay(gunPosition.position, new Vector3(direction.x, direction.y, 0) * 10, Color.red);

		// Baktığın yönde doğrusal olarak bir raycast yap ve gördüğün nesne Player ise ateş et

        // Player dışında menzili düşürmemiz lazım küçük bir hesap yap

        // duvar ile yada enemy ile arasında 10 birim mesafe olmasın 1 2 olsa yeter o yüzden tekrar bi pozisyon farkı al

        if (hit.collider != null && hit.collider.tag == "Player")
        {       
            return EnemyImpact.Player;
        }

        if (hit.collider != null && hit.collider.tag == "Enemy" && hit.distance < 1f)
        {
            return EnemyImpact.Enemy;
        }

		if (hit.collider != null && hit.collider.tag == "Wall"  && hit.distance < 1f)
		{
            return EnemyImpact.Wall;
        }
       
        return EnemyImpact.None;
    }
}
