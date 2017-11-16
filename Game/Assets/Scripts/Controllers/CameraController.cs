using UnityEngine;

public class CameraController : MonoBehaviour
{
    World world;

    public Direction lockedSide;
    
	GameObject go_mainCharacter;

	static float halfCameraWidth;

    void Start()
    {
        world = WorldController.Instance.world;

		world.checkpointManager.RegisterUnlockCameraFromCheckpointCallback(UnlockCamera);
        world.checkpointManager.RegisterLockCameraToCheckpointCallback(LockCamera);

        lockedSide = Direction.None;

        float aspectRatio = (float)Screen.width / (float)Screen.height;
        halfCameraWidth = ((Camera.main.orthographicSize * 2) * aspectRatio) / 2;
    }

    void LateUpdate()
    {
        // If camera is locked just return.
        if (lockedSide != Direction.None)
        {
            // We only wanna change the Y position after locked the camera
            return;
        }

		go_mainCharacter = CharacterCont.Instance.go_mainCharacter;
        if (go_mainCharacter == null)
        {
            Debug.LogError("CameraController -- LateUpdate() -- Character's gameobject is null.");
            return;
        }

        Vector3 new_position = new Vector3(
             go_mainCharacter.transform.position.x,
             Camera.main.transform.position.y,
             Camera.main.transform.position.z
        );

        Camera.main.transform.position = new_position;
    }

    void LockCamera(Checkpoint checkpoint, Direction direction)
    {
        // We have already locked the camera. Don't need to change position.
        if (lockedSide != Direction.None)
            return;

        lockedSide = direction;

        float xPos;
        if (direction == Direction.Left)
            xPos = checkpoint.x + halfCameraWidth;
        else
            xPos = checkpoint.x - halfCameraWidth;

		go_mainCharacter = CharacterCont.Instance.go_mainCharacter;
		if (go_mainCharacter == null)
		{
			Debug.LogError("CameraController -- LateUpdate() -- Character's gameobject is null.");
			return;
		}

        Vector3 newCameraPos = new Vector3(
            xPos,
            Camera.main.transform.position.y,
            Camera.main.transform.position.z
        );
			
        Vector3 newCharacterPos = new Vector3(
            xPos,
			go_mainCharacter.transform.position.y,
			go_mainCharacter.transform.position.z
        );

		Camera.main.transform.position = newCameraPos;	
        go_mainCharacter.transform.position = newCharacterPos;
    }

    void UnlockCamera(Direction direction)
    {
        if (lockedSide == Direction.None)
            return;

        // When we lock camera, charater is at center of the camera so it'll try
        // to unlock camera but if we look the direction, we can prevent this issue.
        // We know that if we wanna unlock camera, locked side and the direction of the 
        // character should be different.

		// FIX: Eğer karakter ileride darbe aldığında geri tepme yaparsa
		// kamera kilitten kurtulmayabilir. Bunu karakterin baktığı yönden bağımsız yapmalıyız.
		// Karakterin lastPosition ve currPosition değerlerini kullanıp nereye 
		// doğru hareket ettiğini tespit edebiliriz.
		Character character = WorldController.Instance.world.character;
		if (lockedSide == Direction.Left && character.currPosition.x < character.lastPosition.x ||
			lockedSide == Direction.Right && character.currPosition.x > character.lastPosition.x
		){
            return;
		}

		// Unlock the camera
        lockedSide = Direction.None;
    }

    public static Vector3 GetCameraPosition()
    {
        return Camera.main.transform.position;
    }

    public static Vector3 GetRightEdgePosition()
    {
        return new Vector3(
            Camera.main.transform.position.x + halfCameraWidth,
            Camera.main.transform.position.y
        );
    }

    public static Vector3 GetLeftEdgePosition()
    {
        return new Vector3(
            Camera.main.transform.position.x - halfCameraWidth,
            Camera.main.transform.position.y
        );
    }
}
