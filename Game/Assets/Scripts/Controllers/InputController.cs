using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
	// KeyboardController sadece karakter üzerinde işler yaptığı
	// için direk karakteri referansı almayı daha uygun gördüm.
	Character character;
    public GameObject GunTypesGO;
    bool UIShowed=false;
     Animator gunChooseAnim;

	#if UNITY_ANDROID || UNITY_IOS
		
	// We need these variables because we are updating walk state
	// in FixedUpdate so use these variables to check in FixedUpdate
	
	bool leftDown;
	bool rightDown;

	#endif

	// Use this for initialization
	void Start ()
	{
		character = WorldController.Instance.world.character;

       // GunTypesGO.SetActive(UIShowed);
   
        gunChooseAnim = GunTypesGO.GetComponent<Animator>();
      //  gunChooseAnim.SetBool("open",UIShowed);

		#if UNITY_STANDALONE_WIN

		// If platform is not mobile, we won't need buttons on the screen so Destroy them.

		GameObject canvas = GameObject.Find("Canvas");
		Destroy(canvas.transform.Find("MobileInputs").gameObject);

		#endif
	}
	
	// Update is called once per frame
	void Update ()
	{
		#if UNITY_STANDALONE_WIN

		// Tuşa basılı tuttukça zıplaması istersek GetKey kullanmalıyız.
		// Şimdilik bu şekilde yapıyorum.
        if (character.isAlive)
        {
            if (Input.GetKey(KeyCode.UpArrow) == true)
			{
				Jump();
            }

            if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                character.Crouch();
            }

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                character.Attack();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                InventoryController.Instance.gameObject.SetActive(true);
            }

			if (Input.GetKeyDown(KeyCode.Alpha1) == true)
			{
                character.ChangeWeapon(WeaponType.Close);
			}

			if (Input.GetKeyDown(KeyCode.Alpha2) == true)
			{
                character.ChangeWeapon(WeaponType.Gun);
			}

			if (Input.GetKeyDown(KeyCode.Alpha3) == true)
			{
                character.ChangeWeapon(WeaponType.Rifle);
			}
		}

		#endif
	}
    public void ChangeWeapon()
    {
        UIShowed = !UIShowed;


       gunChooseAnim.SetBool("open",UIShowed);

  

   
    }
   
    public void ChangeWeapon(int type)
    {
        UIShowed = false;
        gunChooseAnim.SetBool("open",false);
        character.ChangeWeapon((WeaponType)type);

       
       


    }
    	void FixedUpdate()
	{
		// Eğer ikiside farklıysa bir tarafa gidilecek demektir.
		// Eğer ikisi aynıysa ya hiç basılmadı yada iki tuşa birden basıldı.
		// Bu durumlarda karakter hareketsiz. Axis in 0 olduğunu bildir.

		if (character.isAlive)
		{
			#if UNITY_ANDROID || UNITY_IOS
				
			// This should look like as a comment but it's not. When we switch
			// build settings to android or ios, it won't be comment.

			if(leftDown ^ rightDown)
			{
				if(leftDown)
					character.Walk(-1f);
				else
					character.Walk(1f);
			}
			else
			{
				character.Walk(0f);
			}	

			#endif

			#if UNITY_STANDALONE_WIN
				
			if (Input.GetKey(KeyCode.LeftArrow) ^ Input.GetKey(KeyCode.RightArrow))
			{
				character.Walk(Input.GetAxis("Horizontal"));
			}
			else
			{
				character.Walk(0f);
			}

			#endif
		}
	}

	public void Jump()
	{
		character.Jump();
	}

	public void Crouch()
	{
		character.Crouch();
	}

	public void Attack()
	{
		character.Attack();
	}

	#if UNITY_ANDROID || UNITY_IOS

	public void Mobile_Button_Up(int direction)
	{
		if(direction == 0)
		{
			leftDown = false;
		}
		else
		{
			rightDown = false;
		}
	}

	public void Mobile_Button_Down(int direction)
	{
		if (direction == 0)
		{
			leftDown = true;
		}
		else
			rightDown = true;
	}

	#endif

}
