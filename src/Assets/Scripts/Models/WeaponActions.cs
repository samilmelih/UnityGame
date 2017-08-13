using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponActions : MonoBehaviour
{
    //bunun içerisinde silahın bulunması ne gibibir fayda verir

    public static void Magnum_One_Shot(Character character, Weapon magnum)
    {
		float currTime = Time.time;

		if (currTime - magnum.weaponParameters["fireCoolDown"] > magnum.weaponParameters["fireFrequency"])
		{
			if(magnum.weaponParameters["bulletCount"] > 0f)
			{
				GameObject chr_go;

				magnum.weaponParameters["bulletCount"] -= 1f;

				if(character.Type == "Enemy")
				{
                    chr_go = EnemyController.Instance.enemyGameObjectMap[character];
				}
				else if(character.Type == "Main Character")
				{
					chr_go = CharacterController.go_mainCharacter;
				}
				else
				{
					Debug.LogError("Magnum_One_Shot() -- Undefined character type: " + character.Type);
					return;
				}

				Transform gunPosition = chr_go.transform.Find("Gun");

				GameObject go = Resources.Load<GameObject>("Prefabs/Bullet");

                GameObject bullet = Instantiate<GameObject>(go, gunPosition.position, Quaternion.identity);

				// We need to attach bullet instance into bullet go.
				// Because when we hit something we need to know how damage we gave to enemy/character
				bullet.GetComponent<BulletBehaviour>().bullet = magnum.bullet;

				bullet.GetComponent<BulletBehaviour>().character = character;

				bullet.GetComponent<BulletBehaviour>().go_shooter = chr_go;

                magnum.weaponParameters["fireCoolDown"] = Time.time;
			}
			else
			{
				// We are out of bullet.
			}
		}

    }
}
