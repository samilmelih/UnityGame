using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputController : MonoBehaviour
{
	
#if UNITY_ANDROID || UNITY_IOS

	// We need these variables because we are updating walk state
	// in FixedUpdate so use these variables to check in FixedUpdate

	bool leftDown;
	bool rightDown;

#endif

	// We need to know when an item selected and we can change the default item picker sprite in
	// animatedItemMenuController

    

    #region Singleton
    public static InputController Instance;
    #endregion

    Character character;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        character = WorldController.Instance.world.character;

        // GunTypesGO.SetActive(UIShowed);	FIXME: Do we need them?
        //gunChooseAnim.SetBool("open",UIShowed);


	#if UNITY_STANDALONE_WIN
        // If platform is not mobile, we won't need buttons on the screen so Destroy them.

        GameObject canvas = GameObject.Find("Canvas");
        Destroy(canvas.transform.Find("MobileInputs").gameObject);
	#endif

    }
				
    // Update is called once per frame
    void Update()
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

            if (Input.GetKeyDown(KeyCode.Q))
            {
                //FIXME:
                ///
                /// DUMMY CODE FOR TESTING
                ///


                Heal();


                ////
                ////
                ////
            }
				
            if (Input.GetKeyDown(KeyCode.Alpha1) == true)
            {
                character.ChangeWeapon(1);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2) == true)
            {
                character.ChangeWeapon(2);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3) == true)
            {
                character.ChangeWeapon(3);
            }
		}
	#endif
    
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

            if (leftDown ^ rightDown)
            {
                if (leftDown)
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

    #region Character Moves
    public void Jump()
    {
        character.Jump();
    }

    public void Crouch()
    {
        character.Crouch();
	}

    public void Heal()
    {
        HealPot h = new HealPot("", 0, 0, 0, false, false, 25, 6);
        h.RegisterHealPotAction(ItemActions.HealPotAct);
        h.Use();
    }

    public void Attack()
    {
        character.Attack();
    }
    #endregion

#if UNITY_ANDROID || UNITY_IOS
    public void Mobile_Button_Up(int direction)
    {
        if (direction == 0)
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
        {
            rightDown = true;
        }
    }
#endif

}
