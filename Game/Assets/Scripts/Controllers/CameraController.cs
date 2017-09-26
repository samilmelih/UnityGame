using UnityEngine;

public class CameraController : MonoBehaviour
{
    World world;

    Direction lockedSide;

    static float halfCameraWidth;
    GameObject go_mainCharacter;

    void Start()
    {
        world = WorldController.Instance.world;

        world.character.RegisterUnlockCameraFromCheckpointCallback(UnlockCamera);
        world.checkpointManager.RegisterLockCameraToCheckpointCallback(LockCamera);

        lockedSide = Direction.None;

        float aspectRatio = (float)Screen.width / (float)Screen.height;
        halfCameraWidth = ((Camera.main.orthographicSize * 2) * aspectRatio) / 2;


    }

    void Update()
    {
        // If camera is locked just return.
        if (lockedSide != Direction.None)
        {

            //we only wanna change the Y position after locked the camera
            Vector3 lerpBy_Y = new Vector3(
            Camera.main.transform.position.x,
           Mathf.Lerp(Camera.main.transform.position.y, go_mainCharacter.transform.position.y, Time.deltaTime),
           Camera.main.transform.position.z

       );
            Camera.main.transform.position = lerpBy_Y;
            return;
        }
        if (go_mainCharacter == null)
            go_mainCharacter = CharacterCont.Instance.go_mainCharacter;

        if (go_mainCharacter == null)
        {
            Debug.LogError("CameraController -- Update() -- Character's gameobject is null.");
            return;
        }

        Vector3 new_position = new Vector3(
             go_mainCharacter.transform.position.x,
            Mathf.Lerp(Camera.main.transform.position.y, go_mainCharacter.transform.position.y, Time.deltaTime),
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

        Vector3 newCameraPos = new Vector3(
            xPos,
            Camera.main.transform.position.y,
            Camera.main.transform.position.z
        );

        Transform chr_trans = CharacterCont.Instance.go_mainCharacter.transform;

        Vector3 newCharacterPos = new Vector3(
            xPos,
            chr_trans.position.y,
            chr_trans.position.z
        );

        Camera.main.transform.position = newCameraPos;
        CharacterCont.Instance.go_mainCharacter.transform.position = newCharacterPos;
    }

    void UnlockCamera(Direction direction)
    {
        if (lockedSide == Direction.None)
            return;

        // When we lock camera, charater is at center of the camera so it'll try
        // to unlock camera but if we look the direction, we can prevent this issue.
        // We know that if we wanna unlock camera, locked side and the direction of the 
        // character should be different.
        if (lockedSide == direction)
            return;

        float xPos = Camera.main.transform.position.x;

        Vector3 newCharacterPos = new Vector3(
            xPos,
            CharacterCont.GetCharacterPosition().y,
            CharacterCont.GetCharacterPosition().z
        );

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
