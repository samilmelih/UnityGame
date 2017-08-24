using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StoreController : MonoBehaviour {


    public GameObject storeGO;

    public GameObject MainMenuGO;

    Dictionary<string,GameObject> stringToGameObjectMap;

    GameObject itemHolderPrefab;

    void LoadAllGunPrefabs()
    {
        GameObject[] gunPrefabs= Resources.LoadAll<GameObject>("Prefabs/GunSpritePrefabs/");

        foreach (GameObject go in gunPrefabs)
        {
            stringToGameObjectMap.Add( go.name , go );
        }
    }

	// Use this for initialization
	void Start () {
		
        stringToGameObjectMap = new Dictionary<string, GameObject>();

        LoadAllGunPrefabs();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        World world = WorldController.Instance.world;
       
        foreach (Weapon weapon in world.weaponPrototypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            Transform itemPlaceOfThisObject=itemHolderGO.transform.Find("ItemPlace");

            itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate {BuyItem(weapon.name);});

            itemHolderGO.name = weapon.name;

           
            Instantiate(stringToGameObjectMap[weapon.name], itemPlaceOfThisObject);


           
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
