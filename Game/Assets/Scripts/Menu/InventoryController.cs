using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public static InventoryController Instance;
	World world;

	// Use this for initialization
	void Start ()
	{
		world = WorldController.Instance.world;	
        if (Instance == null)
            Instance = this;


        DontDestroyOnLoad(Instance.transform.root.gameObject);


        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public  void CloseInventoryUI()
    {
        this.gameObject.SetActive(false);
    }
}
