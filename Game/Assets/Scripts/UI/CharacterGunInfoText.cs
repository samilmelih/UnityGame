using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class CharacterGunInfoText : MonoBehaviour
{
	public Text GunNameText;
    public Text BulletCount;
    public Text MaxBulletCount;
    public Text HealthText;
    public Text MoneyText;

    Weapon characterWeapon;

	// Update is called once per frame
	void Update ()
	{
		// FIXME: These need local string literals.

		HealthText.text = "Health : " + WorldController.Instance.world.character.health.ToString();

		MoneyText.text = "Money : " + WorldController.Instance.world.character.money.ToString();

		characterWeapon = WorldController.Instance.world.character.currentWeapon;

        if (characterWeapon != null)
        {
            GunNameText.text = "Weapon: " + characterWeapon.name;

            if(characterWeapon.isReloadable == true)
            {
				BulletCount.text =
					"Magazine: " + characterWeapon.weaponParameters[StringLiterals.MagazineCount].ToString();

				MaxBulletCount.text =
					"Magazine Capacity: " + characterWeapon.weaponParameters[StringLiterals.MagazineCapacity].ToString();
            }
            else
            {
				BulletCount.text = "Magazine: ";

				MaxBulletCount.text = "Magazine Capacity: ";
            }

        }
	}
}
