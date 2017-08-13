using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : MonoBehaviour
{
	// KeyboardController sadece karakter üzerinde işler yaptığı
	// için direk karakteri referansı almayı daha uygun gördüm.
	Character character;

	// Use this for initialization
	void Start ()
	{
		character = WorldController.Instance.world.character;	
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Tuşa basılı tuttukça zıplaması istersek GetKey kullanmalıyız.
		// Şimdilik bu şekilde yapıyorum.
        if (character.isAlive)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) == true)
            {
                character.Jump();
            }

            if (Input.GetKey(KeyCode.DownArrow) == true)
            {
                character.Crouch();
            }

            if (Input.GetKeyDown(KeyCode.Space) == true)
            {
                character.Attack();
            }
        }
	}

	void FixedUpdate()
	{
		// Eğer ikiside farklıysa bir tarafa gidilecek demektir.
		// Eğer ikisi aynıysa ya hiç basılmadı yada iki tuşa birden basıldı.
		// Bu durumlarda karakter hareketsiz. Axis in 0 olduğunu bildir.

        if (character.isAlive)
        {
            if (Input.GetKey(KeyCode.LeftArrow) ^ Input.GetKey(KeyCode.RightArrow))
            {
            
                character.Walk(Input.GetAxis("Horizontal"));
            }
            else
            {
                character.Walk(0f);
            }
        }
	}
}
