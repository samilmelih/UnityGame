using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimatedWeaponMenuController : MonoBehaviour
{
    #region Singelton
    public static AnimatedWeaponMenuController Instance;
    #endregion

    [SerializeField]
    List<GameObject> ItemsList;

    List<Item> equippedWeapons;

    Dictionary<GameObject, Item> GOToItemMap;

    World world;
    // Use this for initialization
    void Start()
    {
        Instance = this;

        world = WorldController.Instance.world;

        List<string> equippedWeaponsNameList = world.character.inventory.equippedWeapons;
        equippedWeapons = new List<Item>();

        GOToItemMap = new Dictionary<GameObject, Item>();

        foreach (string itemName in equippedWeaponsNameList)
        {
            equippedWeapons.Add(world.itemProtoTypes[itemName]);
        }

        for (int i = 0; i < ItemsList.Count - 1; i++)
        {

            GOToItemMap[ItemsList[i]] = equippedWeapons[i];

            ItemsList[i].GetComponentInChildren<Image>().sprite =
                ItemSpriteController.Instance.GetSpriteForItem(equippedWeapons[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DefaultWeaponSprite(Item defaultItem)
    {
        if (defaultItem == null) return;

        ItemsList[ItemsList.Count - 1].GetComponentInChildren<Image>().sprite =
           ItemSpriteController.Instance.GetSpriteForItem(defaultItem);
    }

    public Item GetWeaponAsItemByGO(GameObject go)
    {
        if (go == null) return null;
        if (GOToItemMap.ContainsKey(go) == false) return null;

        return GOToItemMap[go];

    }
}
