using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	World world;

	bool rightLocked;
	bool leftLocked;

	static float cameraWidth;

	void Start()
	{
		world = WorldController.Instance.world;

		world.character.RegisterUnlockCameraFromCheckpointCallback(UnlockCamera);
		world.checkpointManager.RegisterLockCameraToCheckpointCallback(LockCamera);
	
		float aspectRatio = (float) Screen.width / (float) Screen.height;
		cameraWidth = (Camera.main.orthographicSize * 2) * aspectRatio;
	}

	void Update()
	{
		GameObject go_mainCharacter = CharacterCont.Instance.go_mainCharacter;

		if(rightLocked || leftLocked)
			return;

        if (go_mainCharacter != null)
        {
        	Vector3 new_position = new Vector3(
         		go_mainCharacter.transform.position.x,
				Camera.main.transform.position.y,
                Camera.main.transform.position.z
			);

			Camera.main.transform.position = new_position;
		}
	}

	void LockCamera(Direction direction)
	{
		if(direction == Direction.Left)
		{
			leftLocked = true;
		
			Transform mainCharacter = CharacterCont.Instance.go_mainCharacter.transform;

			// FIXME: We don't like constants. Find a better way.
			// We move character left/right, when we locked camera to a checkpoint.
			// Why 0.2f constant? It's because we use 0.1f constant to lock camera to 
			// our character. If it's less then 0.2f, it can not escape from locking to character.
			mainCharacter.transform.Translate(-0.2f, 0f, 0f);
		}
		else
		{
			Transform mainCharacter = CharacterCont.Instance.go_mainCharacter.transform;
			mainCharacter.transform.Translate(0.2f, 0f, 0f);

			rightLocked = true;
		}
	}

	void UnlockCamera()
	{
		CheckpointManager cpm = world.checkpointManager;
		Vector3 new_position;

		if(leftLocked == true)
		{
			leftLocked = false;

			new_position = new Vector3(
				// FIXME: We don't like constants. Find a better way.
				cpm.left.x + 0.1f,	
				Camera.main.transform.position.y,
				Camera.main.transform.position.z
			);
		}
		else
		{
			rightLocked = false;

			new_position = new Vector3(
				cpm.right.x - 0.1f,
				Camera.main.transform.position.y,
				Camera.main.transform.position.z
			);
		}

		Camera.main.transform.position = new_position;
	}

	public static Vector3 GetCameraPosition()
	{
		return Camera.main.transform.position;
	}

	public static Vector3 GetRightEdgePosition()
	{
		return new Vector3(
			Camera.main.transform.position.x + (cameraWidth / 2),
			Camera.main.transform.position.y
		);
	}

	public static Vector3 GetLeftEdgePosition()
	{
		return new Vector3(
			Camera.main.transform.position.x - (cameraWidth / 2),
			Camera.main.transform.position.y
		);
	}
}
