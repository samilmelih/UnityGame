using System.Collections.Generic;
using UnityEngine;

public class ItemSpriteController : MonoBehaviour
{
    #region Singelton
    public static ItemSpriteController Instance;
    #endregion

    Dictionary<string, Sprite> itemToSpriteMap;

	World world;

	void Start()
    {
        Instance = this;
        world = WorldController.Instance.world;

        itemToSpriteMap = new Dictionary<string, Sprite>();

		LoadSpritesForItems();
    }

    private void LoadSpritesForItems()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("Sprites");

        foreach (Sprite sprite in sprites)
        {
            itemToSpriteMap[sprite.name] = sprite;
        }
    }

    public Sprite GetSpriteForItem(string itemName)
    {
        if (itemToSpriteMap == null)
		{
			Debug.LogError("GetSpriteForItem() -- Map is null. Did we assign null to this map somewhere?");
			return null;
		}

		if (itemToSpriteMap.ContainsKey(itemName) == false)
		{
			Debug.LogError("GetSpriteForItem() -- Item is not found in the itemToSpriteMap.");
			return null;
		}

        return itemToSpriteMap[itemName];
    }
}
