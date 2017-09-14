using UnityEngine;

public class WorldController : MonoBehaviour
{
    public static WorldController Instance;

    public World world;

    // Use this for initialization
    void Awake()
    {
        // PlayerPrefsController.DebugSaveStrings();

        if (Instance == null)
        {
            world = new World();
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }
}
