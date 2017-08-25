using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class StoreController : MonoBehaviour {

    public Text moneytext;
     
    public GameObject storeGO;

    public GameObject MainMenuGO;

    int currentMoney;

    Text[] gunInfotexts;

    Dictionary<string,GameObject> stringToGameObjectMap;

    World world;

    GameObject itemHolderPrefab;

    string inventoryString="";

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

        PlayerPrefs.DeleteKey("inventory");

        List<string> inv = PlayerPrefs.GetString("inventory").Split(',').ToList();

        inventoryString = PlayerPrefs.GetString("inventory");
        currentMoney = PlayerPrefs.GetInt("money");

        Debug.Log(inventoryString);

        stringToGameObjectMap = new Dictionary<string, GameObject>();

        LoadAllGunPrefabs();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        world = WorldController.Instance.world;
       
        foreach (Weapon weapon in world.weaponPrototypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            Transform itemPlaceOfThisObject = itemHolderGO.transform.Find("ItemPlace");

            gunInfotexts = itemHolderGO.GetComponentsInChildren<Text>();

            if (inv.Contains(weapon.name) == false)
                itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    {
                        BuyItem(weapon.name, itemHolderGO);
                    });
            else
            {
                itemHolderGO.GetComponentInChildren<Button>().enabled = false;
                gunInfotexts[2].text = "Alindi";

            }


            itemHolderGO.name = weapon.name;

            gunInfotexts[0].text = weapon.type.ToString();
            gunInfotexts[1].text ="Cost : " + weapon.cost.ToString();

            Instantiate(stringToGameObjectMap[weapon.name], itemPlaceOfThisObject);


           
        }

	}
	
	// Update is called once per frame
	void Update () {
        moneytext.text = "Gold : " + PlayerPrefs.GetInt("money");
	}

    public void BuyItem(string weaponName,object sender)
    {

        if (world.weaponPrototypes.ContainsKey(weaponName) == false)
        {
            Debug.LogError(string.Format("{0} adlı silahı satın almaya çalışıyorsun ismi ile proto dan erişmek mümkün değil yanlış birşey var?", weaponName));
            return;
        }

        if (world.weaponPrototypes[weaponName].cost <= currentMoney)
        {
            currentMoney -= world.weaponPrototypes[weaponName].cost;
            PlayerPrefs.SetInt("money", currentMoney);

            inventoryString += weaponName + ",";
            PlayerPrefs.SetString("inventory",inventoryString);

            (sender as GameObject).GetComponentInChildren<Button>().enabled = false;

            gunInfotexts = (sender as GameObject).GetComponentsInChildren<Text>();

            gunInfotexts[2].text="Alindi";

        }
        else
        {
            Debug.LogError(string.Format("{0} adlı silahı satın almaya çalışıyorsun paran yok???", weaponName));

        }
       
    }

    public void CloseStore()
    {
        storeGO.SetActive(false);
        MainMenuGO.SetActive(true);
    }

}
