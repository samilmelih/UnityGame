using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreController : MonoBehaviour {


    public GameObject storeGO;

    public GameObject MainMenuGO;


    GameObject itemHolderPrefab;

	// Use this for initialization
	void Start () {
		
        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        World world = WorldController.Instance.world;
       
        foreach (Weapon item in world.weaponPrototypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);
            itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate {BuyItem(item.name);});
            itemHolderGO.name = item.name;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void BuyItem(string weaponName)
    {
        Debug.Log(string.Format("{0} adlı silahı satın almaya çalışıyorsun ismi ile proto dan erişmek mümkün",weaponName));
    }

    public void CloseStore()
    {
        storeGO.SetActive(false);
        MainMenuGO.SetActive(true);
    }

}
