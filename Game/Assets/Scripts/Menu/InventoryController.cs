using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
	World world;

	// Use this for initialization
	void Start ()
	{
		world = WorldController.Instance.world;	
        DontDestroyOnLoad(this.transform.root.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public  void CloseInventoryUI()
    {
        this.gameObject.SetActive(false);
    }
}
