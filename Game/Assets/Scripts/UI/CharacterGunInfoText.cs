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
		HealthText.text = "Health : " + WorldController.Instance.world.character.health.ToString();

		MoneyText.text = "Money : " + WorldController.Instance.world.character.money.ToString();

		characterWeapon = WorldController.Instance.world.character.currentWeapon;

        if (characterWeapon != null)
        {
            GunNameText.text = "Curr Weapon: " + characterWeapon.name;

            if(characterWeapon.isReloadable == true)
            {
				BulletCount.text = "Magazine Count: " + characterWeapon.weaponParameters["Magazine_Count"].ToString();

				MaxBulletCount.text = "Max Magazine Count: " + characterWeapon.weaponParameters["Max_Magazine_Count"].ToString();
            }
            else
            {
                BulletCount.text = "Bullet Count: ";

                MaxBulletCount.text = "Max Bullet Count: ";
            }

        }
	}
}
