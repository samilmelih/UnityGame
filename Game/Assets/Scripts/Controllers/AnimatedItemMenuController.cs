using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedItemMenuController : MonoBehaviour
{


    //First five objects are Items. Last  one is Default one we are gonna shot on it what we choose as default
    //--default object is the item that we used lately--
    [SerializeField]
    List<GameObject> ItemsList;

    List<Item> equippedItems;

    Dictionary<GameObject, Item> GOToItemMap;

    World world;
    // Use this for initialization
    void Start()
    {



        world = WorldController.Instance.world;

        List<string> equippedItemsNameList = world.character.inventory.equippedItems;
        equippedItems = new List<Item>();

        GOToItemMap = new Dictionary<GameObject, Item>();

        foreach (string itemName in equippedItemsNameList)
        {
            equippedItems.Add(world.itemProtoTypes[itemName]);
        }

        for (int i = 0; i < ItemsList.Count - 1; i++)
        {
            if (i >= equippedItems.Count) break;
            GOToItemMap[ItemsList[i]] = equippedItems[i];

            ItemsList[i].GetComponentInChildren<Image>().sprite =
                ItemSpriteController.Instance.GetSpriteForItem(equippedItems[i]);
        }

        //FIXME:  Item for non-selected Default Item picker we need a Sprite for this

    }

    public void DefaultItemSprite(Item defaultItem)
    {
        if (defaultItem == null) return;

        ItemsList[ItemsList.Count - 1].GetComponentInChildren<Image>().sprite =
           ItemSpriteController.Instance.GetSpriteForItem(defaultItem);
    }

    public Item GetItemByGO(GameObject go)
    {
        if (go == null) return null;
        if (GOToItemMap.ContainsKey(go) == false) return null;

        return GOToItemMap[go];

    }

    // Update is called once per frame
    void Update()
    {

    }
}
