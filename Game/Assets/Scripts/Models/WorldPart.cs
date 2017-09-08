public partial class World
{
    #region Protos

    /// <summary>
    /// Creates the bullet protos.
    /// </summary>
    void CreateBulletProtos()
    {
        bulletPrototypes.Add("Magnum_Bullet",
            new Bullet(
                "Magnum_Bullet",	// name
                15f,        		// damage
                20f         		// velocity
         	)
		);

        bulletPrototypes["Magnum_Bullet"].cost = 1;
		bulletPrototypes["Magnum_Bullet"].purchaseAmount = 10;


        bulletPrototypes.Add("MP5_Bullet",
            new Bullet(
                "MP5_Bullet",	// name
                25,         	// damage
                20          	// velocity
            )
        );

        bulletPrototypes["MP5_Bullet"].cost = 1;
		bulletPrototypes["MP5_Bullet"].purchaseAmount = 50;


        bulletPrototypes.Add("Shotgun_Bullet",
            new Bullet(
                "Shotgun_Bullet",	// name
                50,         		// damage
                40         			// velocity
            )
        );

        bulletPrototypes["Shotgun_Bullet"].cost = 1;
		bulletPrototypes["Shotgun_Bullet"].purchaseAmount = 5;


        bulletPrototypes.Add("Uzi_Bullet",
            new Bullet(
                "Uzi_Bullet",	// name
                30,         	// damage
                25		       	// velocity
            )
        );

        bulletPrototypes["Uzi_Bullet"].cost = 1;
		bulletPrototypes["Uzi_Bullet"].purchaseAmount = 20;


        bulletPrototypes.Add("Sniper_Bullet",
            new Bullet(
                "Sniper_Bullet",	// name
                90,         		// damage
                70          		// velocity
            )
        );

        bulletPrototypes["Sniper_Bullet"].cost = 1;
		bulletPrototypes["Sniper_Bullet"].purchaseAmount = 7;


        /// Knife_Sharp
        /// Knife_Smooth
        /// RockerLauncher
        /// RockerLauncher_Modern
        /// RockerLauncher_Side
        /// Uzi_Long
        /// Machinegun

        bulletPrototypes.Add("Uzi_Long_Bullet",
            new Bullet(
                "Uzi_Long_Bullet",		// name
                30,         			// damage
                25          			// velocity
            )
        );

        bulletPrototypes["Uzi_Long_Bullet"].cost = 1;
		bulletPrototypes["Uzi_Long_Bullet"].purchaseAmount = 30;


        bulletPrototypes.Add("Machinegun_Bullet",
            new Bullet(
                "Machinegun_Bullet",	// name
                30,       				// damage
                25          			// velocity
            )
        );

        bulletPrototypes["Machinegun_Bullet"].cost = 1;
		bulletPrototypes["Machinegun_Bullet"].purchaseAmount = 100;


        bulletPrototypes.Add("RocketLauncher_Bullet",
            new Bullet(
                "RocketLauncher_Bullet",	// name
                30,         				// damege
                25	       					// velocity
            )
        );

        bulletPrototypes["RocketLauncher_Bullet"].cost = 1;
		bulletPrototypes["RocketLauncher_Bullet"].purchaseAmount = 3;


        bulletPrototypes.Add("RocketLauncher_Modern_Bullet",
            new Bullet(
                "RocketLauncher_Modern_Bullet",		// name
                30,         						// damage
                25         							// velocity
            )
        );

        bulletPrototypes["RocketLauncher_Modern_Bullet"].cost = 1;
		bulletPrototypes["RocketLauncher_Modern_Bullet"].purchaseAmount = 3;


        bulletPrototypes.Add("RocketLauncher_Side_Bullet",
            new Bullet(
                "RocketLauncher_Side_Bullet",		// name
                30,        							// damage
                25						         	// velocity
            )
        );

        bulletPrototypes["RocketLauncher_Side_Bullet"].cost = 1;
		bulletPrototypes["RocketLauncher_Side_Bullet"].purchaseAmount = 3;

    }

    /// <summary>
    /// Creates the knife proto.
    /// </summary>

    void CreateKnifeProto()
    {
        weaponPrototypes.Add(
            "Knife",
            new Weapon("Knife")
        );

        weaponPrototypes["Knife"].type = WeaponType.Close;
        weaponPrototypes["Knife"].cost = 1;
        weaponPrototypes["Knife"].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes["Knife"].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes["Knife"].cbAttack += WeaponActions.CloseWeapons;
    }

    void CreateKnife_SmoothProto()
    {
        weaponPrototypes.Add(
            "Knife_Smooth",
            new Weapon("Knife_Smooth")
        );

        weaponPrototypes["Knife_Smooth"].type = WeaponType.Close;
        weaponPrototypes["Knife_Smooth"].cost = 1;
        weaponPrototypes["Knife_Smooth"].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes["Knife_Smooth"].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes["Knife_Smooth"].cbAttack += WeaponActions.CloseWeapons;
    }

    void CreateKnife_SharpProto()
    {
        weaponPrototypes.Add(
            "Knife_Sharp",
            new Weapon("Knife_Sharp")
        );

        weaponPrototypes["Knife_Sharp"].type = WeaponType.Close;
        weaponPrototypes["Knife_Sharp"].cost = 1;
        weaponPrototypes["Knife_Sharp"].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes["Knife_Sharp"].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes["Knife_Sharp"].cbAttack += WeaponActions.CloseWeapons;
    }

    /// <summary>
    /// Creates the magnum proto.
    /// </summary>
    void CreateMagnumProto()
    {
		string name = "Magnum";

		weaponPrototypes.Add(name,
            new Weapon(
				name,
                bulletPrototypes[name + "_Bullet"]
            )
		);
			
		weaponPrototypes[name].cost = 1;

		weaponPrototypes[name].weaponParameters.Add(
			"Max_Magazine_Count",
			14f
		);

		weaponPrototypes[name].weaponParameters.Add(
			"Magazine_Count",
			0f
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            1f      // .5 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]   // Başlangıçta aniden ateş edebilmesi için gerekli
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateShotgunProto()
	{
		string name = "Shotgun";

		weaponPrototypes.Add(name,
            new Weapon(
				name,
                bulletPrototypes[name + "_Bullet"]
            )
		);
				
		weaponPrototypes[name].cost = 1;

		weaponPrototypes[name].weaponParameters.Add(
			"Max_Magazine_Count",
			3f
		);

		weaponPrototypes[name].weaponParameters.Add(
			"Magazine_Count",
			0f
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            1f      // .5 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    /// <summary>
    /// Creates the Mp5 proto.
    /// </summary>
    void CreateMP5Proto()
    {
		string name = "MP5";

		weaponPrototypes.Add(name,
            new Weapon(
				name,
				bulletPrototypes[name + "_Bullet"]
            )
		);

		weaponPrototypes["MP5"].cost = 1;

		weaponPrototypes[name].weaponParameters.Add(
			"Max_Magazine_Count",
			50f
		);

		weaponPrototypes[name].weaponParameters.Add(
			"Magazine_Count",
			0f
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .3f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateSniperProto()
    {
		string name = "Sniper";

		weaponPrototypes.Add(name,
            new Weapon(
				name,
                bulletPrototypes[name + "_Bullet"]
            )
		);

		weaponPrototypes[name].cost = 1;

		weaponPrototypes[name].weaponParameters.Add(
			"Max_Magazine_Count",
			6f
		);

		weaponPrototypes[name].weaponParameters.Add(
			"Magazine_Count",
			0f
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .5f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUziProto()
    {
		string name = "Uzi";

		weaponPrototypes.Add(name,
            new Weapon(
				name,
                bulletPrototypes[name + "_Bullet"]
            )
		);

		weaponPrototypes[name].cost = 1;

		weaponPrototypes[name].weaponParameters.Add(
			"Max_Magazine_Count",
			30f
		);

		weaponPrototypes[name].weaponParameters.Add(
			"Magazine_Count",
			0f
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    #endregion





    #region newGuns

	// *******TODO******TODO*******
	// These guns weaponParameters have not edited.
	// They have some compatibility problems. Edit later.

	// FIXME: They make some problem in store. After we setup everything, we can
	// add new weapons. For now I leave them as comment.

    /// Knife_Sharp
    /// Knife_Smooth
    /// RockerLauncher
    /// RockerLauncher_Modern
    /// RockerLauncher_Side
    /// Uzi_Long
    /// Machinegun

    void CreateRocketLauncherProto()
    {
        weaponPrototypes.Add(

            "RocketLauncher",
            new Weapon(

                "RocketLauncher",
                bulletPrototypes["RocketLauncher_Bullet"]

            ));

        weaponPrototypes["RocketLauncher"].type = WeaponType.Rifle;
        weaponPrototypes["RocketLauncher"].cost = 1;
        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["RocketLauncher"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["RocketLauncher"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateRocketLauncher_ModernProto()
    {
        weaponPrototypes.Add(

            "RocketLauncher_Modern",
            new Weapon(

                "RocketLauncher_Modern",
                bulletPrototypes["RocketLauncher_Modern_Bullet"]

            ));

        weaponPrototypes["RocketLauncher_Modern"].type = WeaponType.Rifle;
        weaponPrototypes["RocketLauncher_Modern"].cost = 1;
        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["RocketLauncher_Modern"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );
    }
    void CreateRocketLauncher_SideProto()
    {
        weaponPrototypes.Add(

            "RocketLauncher_Side",
        new Weapon(
            "RocketLauncher_Side",
            bulletPrototypes["RocketLauncher_Side_Bullet"]

        ));

        weaponPrototypes["RocketLauncher_Side"].type = WeaponType.Rifle;
        weaponPrototypes["RocketLauncher_Side"].cost = 1;
        weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["RocketLauncher_Side"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );
    }

    void CreateMachinegunProto()
    {
        weaponPrototypes.Add(

            "Machinegun",
            new Weapon(

                "Machinegun",
                bulletPrototypes["Machinegun_Bullet"]

            ));

        weaponPrototypes["Machinegun"].type = WeaponType.Rifle;
        weaponPrototypes["Machinegun"].cost = 1;
        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Machinegun"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Machinegun"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUzi_LongProto()
    {
        weaponPrototypes.Add(

            "Uzi_Long",
            new Weapon(

                "Uzi_Long",
                bulletPrototypes["Uzi_Long_Bullet"]

            ));

        weaponPrototypes["Uzi_Long"].type = WeaponType.Rifle;
        weaponPrototypes["Uzi_Long"].cost = 1;
        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Uzi_Long"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Uzi_Long"].cbAttack += WeaponActions.One_Shot;
    }
	#endregion
}

