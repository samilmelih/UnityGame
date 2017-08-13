using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	void Update()
	{
        if (CharacterController.go_mainCharacter != null)
        {
            Vector3 new_position = new Vector3(
                             CharacterController.go_mainCharacter.transform.position.x,
                             CharacterController.go_mainCharacter.transform.position.y,
                             Camera.main.transform.position.z
                         );

            Camera.main.transform.position = new_position;
        }		
	}
}
