﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class StoreController : MonoBehaviour
{
	public Text moneytext;

	public GameObject storeGO;

	public GameObject MainMenuGO;

	Dictionary<string,GameObject> stringToGameObjectMap;

	World world;

	GameObject itemHolderPrefab;

	string inventoryString="";

	Text itemName;
	Text itemDescription;
	Text buyButtonText;

	void LoadAllGunPrefabs()
	{
		GameObject[] gunPrefabs = Resources.LoadAll<GameObject>("Prefabs/GunSpritePrefabs/");

		foreach (GameObject go in gunPrefabs)
		{
			stringToGameObjectMap.Add( go.name , go );
		}
	}

	bool IsGameFirstStarted()
	{
		if(PlayerPrefs.HasKey("firstStarted") == false)
		{
			PlayerPrefs.SetInt("firstStarted", 0);
			return true;
		}
		else
		{
			return false;
		}
	}

	// Use this for testing. Maybe it can be a feature in game later.
	void CleanPlayerPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	// Use this for initialization
	void Start ()
	{

        //CleanPlayerPrefs();return;
		

        stringToGameObjectMap = new Dictionary<string, GameObject>();
		LoadAllGunPrefabs();

		world = WorldController.Instance.world;

		// FIXME: We need to know when game is first started. If first started we have a start money.
		// If not first started, we need to get from PlayerPrefs.

		if(IsGameFirstStarted() == true)
		{
			world.character.money = 200;
			PlayerPrefs.SetInt("money", world.character.money);
		}
		else
		{
			world.character.money = PlayerPrefs.GetInt("money"); 
		}

        inventoryString = PlayerPrefs.GetString("inventory");

        CreateStoreWithUI();
		
	}


    void CreateStoreWithUI()
    {
        List<string> inv = PlayerPrefs.GetString("inventory").Split(',').ToList();


        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Store/ItemHolder");

        foreach (Weapon weapon in world.weaponPrototypes.Values)
        {
            GameObject itemHolderGO = Instantiate(itemHolderPrefab, this.transform);

            Transform itemPlaceOfThisObject = itemHolderGO.transform.Find("ItemPlace");

            itemName         = itemHolderGO.transform.Find("Item Name - Text").GetComponent<Text>();
            itemDescription  = itemHolderGO.transform.Find("Description - Text").GetComponent<Text>();
            buyButtonText    = itemHolderGO.transform.Find("Buy - Button").GetComponentInChildren<Text>();

            if (inv.Contains(weapon.name) == false)
            {
                itemHolderGO.GetComponentInChildren<Button>().onClick.AddListener(delegate
                    {
                        BuyItem(weapon.name, itemHolderGO);
                    });
            }
            else
            {
                itemHolderGO.GetComponentInChildren<Button>().enabled = false;
                buyButtonText.text = "purchased";
            }

            itemHolderGO.name = weapon.name;

            itemName.text = weapon.type.ToString();
            itemDescription.text = "Cost : " + weapon.cost.ToString();

            Instantiate(stringToGameObjectMap[weapon.name], itemPlaceOfThisObject);
        }

    }
	// Update is called once per frame
	void Update ()
	{    
		moneytext.text = "Gold : " + PlayerPrefs.GetInt("money");
	}

	public void BuyItem(string weaponName,object sender)
	{
		if (world.weaponPrototypes.ContainsKey(weaponName) == false)
		{
			Debug.LogError(string.Format("{0} adlı silahı satın almaya çalışıyorsun ismi ile proto dan erişmek mümkün değil yanlış birşey var?", weaponName));
			return;
		}

		if (world.weaponPrototypes[weaponName].cost <= world.character.money)
		{
			world.character.money -= world.weaponPrototypes[weaponName].cost;
			PlayerPrefs.SetInt("money", world.character.money);

			inventoryString += weaponName + ",";
			PlayerPrefs.SetString("inventory", inventoryString);

			(sender as GameObject).GetComponentInChildren<Button>().enabled = false;
			buyButtonText = (sender as GameObject).transform.Find("Buy - Button").GetComponentInChildren<Text>();
            buyButtonText.text="purchased";
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
