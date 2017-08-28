using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class EquippedItemController : MonoBehaviour {


    GameObject itemHolderPrefab;
    Dictionary<string, Sprite> stringToSpriteMap;

    List<string> equippedItems;

    public int maxEquippedItemSize = 10;
    Inventory inventory;
    World world;
	// Use this for initialization
	void Start () {
        world = WorldController.Instance.world;
        inventory = world.character.inventory;
        stringToSpriteMap = new Dictionary<string, Sprite>();
        LoadItemSprites();
        LoadItemHolderPrefab();
	}

    void LoadItemSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites/GunSprites");

        foreach (var item in sprites)
        {
            if (stringToSpriteMap.ContainsKey(item.name))
                Debug.LogError("PurchasedItemController -- LoadItemSprites we have same sprite name???");


            stringToSpriteMap.Add(item.name,item);
        }


    }

	
	// Update is called once per frame
	void Update () {
		
	}

    void LoadItemHolderPrefab()
    {
        equippedItems = inventory.GetEquippedItemsNameList();

        itemHolderPrefab = Resources.Load<GameObject>("Prefabs/Inventory/EquippedItemHolder");

        for (int i = 0; i < maxEquippedItemSize; i++)
        {
            GameObject holder_GO = (GameObject)Instantiate(itemHolderPrefab, this.transform);



            if (i < equippedItems.Count)
            {

                //TODO : item ile ilgili sprite resourcestan çekilsin
                // item bilgileri yazdırılacak ise world referansı tutulsun
                // itemler sadece silah olmayacak world içinde tüm itemlerin bulunduğu bir liste falan mı olacak

                //oyuncu hangi silahında kaç mermisi var bilmek ister yada hangisi daha çok vuruyordu gibi bilgiler 

                holder_GO.transform.Find("ItemImage").GetComponent<Image>().sprite=stringToSpriteMap[equippedItems[i]];

                holder_GO.GetComponentInChildren<Button>().onClick.AddListener(
                    delegate
                    {
                        OnDropButton_Click(equippedItems[i], holder_GO);
                    }

                );





            }
        }
    }
    void OnDropButton_Click(string itemName, object sender  )
    {
        Debug.Log(string.Format("{0} isimli silah {1} isimli yerden alınmaya çalışılıyor",itemName,((GameObject)sender).name));
        //TODO bu itemi listeden çıkart sonra playerprefs i güncelle
    }
}
