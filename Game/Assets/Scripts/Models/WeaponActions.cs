using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    public static void CloseWeapons(Character character)
    {
		Debug.Log("This weapon's attack mode is not implemented.");

        ///we can ray from the object for a specified distance
    }

    public static void One_Shot(Character character)
    {
		GameObject go_mainCharacter = CharacterController.Instance.go_mainCharacter;
		Weapon weapon = character.currentWeapon;

		float currTime = Time.time;

		if (currTime - weapon.weaponParameters["fireCoolDown"] > weapon.weaponParameters["fireFrequency"])
		{
			if(weapon.weaponParameters["bulletCount"] > 0f)
			{
                SoundController.Instance.Shot();
				GameObject chr_go;

				if(character.Type == "Enemy")
				{
                    chr_go = EnemyController.Instance.enemyGOMap[character];
				}
				else if(character.Type == "Main Character")
				{
					chr_go = go_mainCharacter;
				}
				else
				{
					Debug.LogError("One_Shot() -- Undefined character type: " + character.Type);
					return;
				}

				Transform gunPosition = chr_go.transform.Find("Gun");

				GameObject bullet_prefab = Resources.Load<GameObject>("Prefabs/Bullet");

                Vector3 bulletRotation = Vector3.back * 90f;

                GameObject bullet_go = Instantiate<GameObject>(bullet_prefab, gunPosition.position, Quaternion.Euler(bulletRotation));

				// We need to attach bullet instance into bullet go.
				// Because when we hit something we need to know how damage we gave to enemy/character
				bullet_go.GetComponent<BulletController>().bullet = weapon.bullet;

				bullet_go.GetComponent<BulletController>().character = character;

				bullet_go.GetComponent<BulletController>().go_shooter = chr_go;

				weapon.weaponParameters["bulletCount"] -= 1f;
                weapon.weaponParameters["fireCoolDown"] = Time.time;
			}
			else
			{
                
				// We are out of bullet.
                //FIXME: şimdilik direk değştiricez 
                //FIXME sistem çalışması açısından yazıyorum bu kodu düzeltilecek

				if(character.Type == "Main Character")
				{
					float money = character.money;

					
						Debug.Log("Reloaded");
                        if (character.inventory.FindItemCount(weapon.bullet) > weapon.weaponParameters["maxBulletCount"])
                        {
                            int currentCount = character.inventory.FindItemCount(weapon.bullet) - (int)weapon.weaponParameters["maxBulletCount"];
                            character.inventory.AddItem(weapon.bullet, -(int)weapon.weaponParameters[ "maxBulletCount" ] );

                            weapon.weaponParameters["bulletCount"] = weapon.weaponParameters["maxBulletCount"];
                        }
					
				}
                else
                    weapon.weaponParameters["bulletCount"] = weapon.weaponParameters["maxBulletCount"];
			}
		}

    }
   
}
