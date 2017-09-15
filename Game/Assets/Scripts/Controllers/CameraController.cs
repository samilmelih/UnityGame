using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	// TODO: We will have gameobjects on main camera's borders. They will interact with the
	// checkpoint triggers. If we do this way, character doesn't need to interact with the
	// checkpoint triggers. We just need to limit our character in main camera. That'll be enough.
	// Why we do this way? If main character was interact with the cp trigs, we would not limit camera
	// properly. Because our character is at center of the camera.

	// How we gonna to this? We need to know where is our camera's borders. Top border is easy.
	// We just need look at camera.orthographicSize but left and right is a little bit tricky.
	// Because they change up to aspect ratio. We need to calculate it depend on aspect ratio.
	// As a summary, we need to know how far left or right, we are gonna place our detector gameobjects.
	// After calculated, we will give them to camera as a child and look if they triggered or not.

	void Update()
	{
		GameObject go_mainCharacter = CharacterCont.Instance.go_mainCharacter;

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
