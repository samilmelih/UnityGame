using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterController : MonoBehaviour
{
	// We only have one character. I guess, we'll need this GameObject info
	// in a lot of place. If we want allias, it won't effect them. We can
	// still create AlliesController like EnemyController and control them to
	// serve our main character.
	public static GameObject go_mainCharacter;

	World world;

    void Start()
    {		
		world = WorldController.Instance.world;

		CreateCharacter();
	}

	void CreateCharacter()
	{
		// Create our characters into scene. For now,
		// we only have one character.

		GameObject chr_prefab = (GameObject) Resources.Load("Prefabs/Character");	// FIXME: This need to be change in the future.

		go_mainCharacter = Instantiate(chr_prefab, chr_prefab.transform);

		go_mainCharacter.name = "Main Character";
		go_mainCharacter.tag = "Player";
		go_mainCharacter.transform.position = transform.position;
		go_mainCharacter.transform.SetParent(this.transform, true);

		world.character.RegisterOnAttackCallback(OnCharacterAttack);
		world.character.RegisterOnCrouchCallback(OnCharacterCrouch);
		world.character.RegisterOnJumpCallback(OnCharacterJump);
		world.character.RegisterOnWalkCallback(OnCharacterWalk);
	}

    // Update is called once per frame
    void Update()
    {
        if (world.character.isAlive && world.character.health <= 0)
        {
            
            Destroy(go_mainCharacter);
            world.character.isAlive = false;

            Debug.Log("Main Character is Dead Finish or restart the level");
        }
	}

	void OnCharacterAttack(Character ch)
	{
		ch.currentWeapon.cbAttack(ch, ch.currentWeapon);
	}

	void OnCharacterCrouch(Character ch)
	{
	}

	void OnCharacterJump(Character ch)
	{
		// 01111111, ilk 7 layer dahil, 8 ve sonrası yok. Bunu karakter
		// özelliği olarak yapmak istersek sanırım <Character, LayerMask>
		// şekline tutmamız gerekecek bu sınıfta.
		LayerMask whatIsGround = 127;

		Transform groundCheck = go_mainCharacter.transform.Find("GroundCheck");

		float groundRadius = 0.2f;

		bool grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

		Rigidbody2D rgbd2D = go_mainCharacter.GetComponent<Rigidbody2D>();

		if (grounded == true)
		{
			rgbd2D.AddForce(new Vector2(0, ch.jumpCoefficient));
		}
	}

	void OnCharacterWalk(Character ch)
	{
		float velocity = ch.axis;
        Transform chr_transform=null;
        if(go_mainCharacter!=null)
		     chr_transform = go_mainCharacter.GetComponent<Transform>();

		if (velocity < 0/* && character.direction != Direction.Left*/)
		{
			chr_transform.localScale = new Vector3(-1f, 1f, 0f);
			ch.direction = Direction.Left;
		}

		if (velocity > 0 /*&& character.direction != Direction.Right*/)
		{
			ch.direction = Direction.Right;
			chr_transform.localScale = new Vector3(1f, 1f, 0f);
		}

		//hangi şarta göre karakterin yönü değişecek(bunu değiştirdiğin zaman karakterin yönünü unutma) 
		//        transform.localScale = new Vector3(transform.localScale.x * -1f,1,0);
        if (go_mainCharacter != null)
        {
            Rigidbody2D rgbd2D = go_mainCharacter.GetComponent<Rigidbody2D>();

            rgbd2D.velocity = new Vector2(ch.speed * velocity, rgbd2D.velocity.y);
        }
	}
}
