﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterGunInfoText : MonoBehaviour {

   public Text GunNameText;
    public Text BulletCount;
    public Text MaxBulletCount;
    public Text HealthText;
    public Text MoneyText;

    Weapon characterWeapon;

    /*
    public Text GunNameText;
    public Text GunNameText;
    */
    void Start()
    {
        characterWeapon = WorldController.Instance.world.character.currentWeapon;

    }
	// Update is called once per frame
	void Update () {
        GunNameText.text ="Curr Weapon: " + characterWeapon.type;

        BulletCount.text ="Bullet Count: " + characterWeapon.weaponParameters["bulletCount"].ToString();

        MaxBulletCount.text ="Max Bullet Count: " + characterWeapon.weaponParameters["maxBulletCount"].ToString();


        HealthText.text = "Health :" + WorldController.Instance.world.character.health.ToString();

        MoneyText.text = "Money :" + WorldController.Instance.world.character.money.ToString();

	}
}