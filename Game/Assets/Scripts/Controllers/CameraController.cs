using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	void Update()
	{
		GameObject go_mainCharacter = CharacterController.Instance.go_mainCharacter;

        if (go_mainCharacter != null)
        {
        	Vector3 new_position = new Vector3(
         		go_mainCharacter.transform.position.x,

				// FIXME: If character is at the center, in mobile, it won't be look good so
				// fixed camera position would be good for now. But we need to talk about
				// camera positions later.
				Camera.main.transform.position.y,
                Camera.main.transform.position.z
			);

			Camera.main.transform.position = new_position;
		}
	}
}
