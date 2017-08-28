using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EquippedItemController : MonoBehaviour {


    GameObject itemHolderPrefab;

    List<string> equippedItems;

    public int maxEquippedItemSize = 10;
	// Use this for initialization
	void Start () {
		
        LoadItemHolderPrefab();
	}

   
	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadItemHolderPrefab()
    {
        equippedItems = PlayerPrefs.GetString("equippedItems").Split(',').ToList();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/EquippedItemHolder");

        for (int i = 0; i < maxEquippedItemSize; i++)
        {
            GameObject holder_GO = (GameObject)Instantiate(itemHolderPrefab, this.transform);



            holder_GO.GetComponentInChildren<Button>().onClick.AddListener(
                delegate
                {
                    OnDropButton_Click("itemName", holder_GO);
                }

            );

            if (i < equippedItems.Count && equippedItems[i] != "")
            {

                //TODO : item ile ilgili sprite resourcestan çekilsin
                // item bilgileri yazdırılacak ise world referansı tutulsun
                // itemler sadece silah olmayacak world içinde tüm itemlerin bulunduğu bir liste falan mı olacak

                //oyuncu hangi silahında kaç mermisi var bilmek ister yada hangisi daha çok vuruyordu gibi bilgiler 

            }
        }
    }
    void OnDropButton_Click(string itemName, object sender  )
    {
        Debug.Log(string.Format("{0} isimli silah {1} isimli yerden alınmaya çalışılıyor",itemName,((GameObject)sender).name));
        //TODO bu itemi listeden çıkart sonra playerprefs i güncelle
    }
}
