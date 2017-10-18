using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemAnimationController : MonoBehaviour
{
    public static ItemAnimationController Instance;

    [SerializeField]
    List<Button> weaponPackButtonList;

    [SerializeField]
    List<Button> itemPackButtonList;

    [SerializeField]
    Button weaponArrowButton;

    [SerializeField]
    Button itemArrowButton;

    [SerializeField]
    GameObject defaultWeaponPickerGO;

    [SerializeField]
    GameObject defaultItemPickerGO;

    World world;
    Character character;

    List<string> equippedWeapons;
    List<string> equippedItems;

    bool openWeapon;
    bool openItem;
    bool itemVertical = true;
    bool weaponVertical = true;

    // Use this for initialization
    void Start()
    {
        Instance = this;
        world = WorldController.Instance.world;
        character = world.character;

		AddListenerToButtons();
		UpdateItemSelectionButtons();
    }

	void AddListenerToButtons()
	{
		weaponArrowButton.onClick.AddListener(delegate
			{
				WeaponArrowButton_OnClick();
			});

		itemArrowButton.onClick.AddListener(delegate
			{
				ItemArrowButton_OnClick();
			});
	}

	void UpdateItemSelectionButtons()
	{
		// TODO: We need to know if equipped weapons are changed.
		// An action would be nice. We will also update image and name
		// of the equipped item's button.
		// Note: Get method doesn't return the original list. It copies
		// the original one so we won't mess up with it.
		equippedWeapons = character.inventory.GetEquippedWeaponList();

		for (int i = 0; i < weaponPackButtonList.Count; i++)
		{
			string weaponName = equippedWeapons[i];

			Image image = weaponPackButtonList[i].transform.GetChild(0).GetComponent<Image>();
			image.sprite = ItemSpriteController.Instance.GetSpriteForItem(weaponName);

			weaponPackButtonList[i].gameObject.name = weaponName;

			// If we pass "i" directly as a parameter. It's value is
			// always equal to weapon size.
			int slot = i;
			weaponPackButtonList[i].onClick.AddListener(delegate
				{
					OnWeaponSelection(slot);
				}
			);
		}

		for (int i = 0; i < itemPackButtonList.Count; i++)
		{
			// TODO: Will be implemented after some item is added.
		}

		// FIXME: Item for non-selected Default Item picker we need a Sprite for this
	}

    /// <summary>
    /// Handles click event of arrow button and also handles close
    /// operations when a weapon has been choosen.
    /// </summary>
    public void WeaponArrowButton_OnClick()
    {
        openWeapon = !openWeapon;
        defaultWeaponPickerGO.SetActive(!openWeapon);

        ItemAnimatorCont animator = ItemAnimatorCont.Instance;
        animator.PlayWeaponAnimations(openWeapon, weaponVertical);
    }

    public void ItemArrowButton_OnClick()
    {
        openItem = !openItem;
        defaultItemPickerGO.SetActive(!openItem);

        ItemAnimatorCont animator = ItemAnimatorCont.Instance;
        animator.PlayItemAnimations(openItem, itemVertical);
    }

    public void OnWeaponSelection(int slot)
    {
        // Close weapon animation
        WeaponArrowButton_OnClick();

        // Pick the weapon
        character.ChangeWeapon(slot);
    }

    public void OnItemSelection(GameObject selectedGO)
    {
        // Close item animation
        ItemArrowButton_OnClick();

        // TODO: We need to use this item here (I am not sure about the concept)
    }
}