using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteController : MonoBehaviour
{

    #region Singelton
    public static ItemSpriteController Instance;
    #endregion

    Dictionary<Item, Sprite> itemToSpriteMap;

    World world;

    // Use this for initialization
	void Start()	// changed to Start(), because world created in Awake() so we don't know the order.
    {

        Instance = this;

        world = WorldController.Instance.world;

        itemToSpriteMap = new Dictionary<Item, Sprite>();

        Dictionary<string, Sprite> loadedSprites = LoadSpritesForItems();

        foreach (Item item in world.itemProtoTypes.Values)
        {
            itemToSpriteMap[item] = loadedSprites[item.name];
        }

    }

    private Dictionary<string, Sprite> LoadSpritesForItems()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");

        Dictionary<string, Sprite> stringToSpritesMap = new Dictionary<string, Sprite>();

        foreach (Sprite s in sprites)
        {
            stringToSpritesMap[s.name] = s;
        }

        return stringToSpritesMap;


    }

    public Sprite GetSpriteForItem(Item item)
    {
        if (item == null) return null;
        if (itemToSpriteMap == null) return null;
        if (itemToSpriteMap.ContainsKey(item) == false) return null;

        return itemToSpriteMap[item];
    }


    // Update is called once per frame
    void Update()
    {

    }
}
