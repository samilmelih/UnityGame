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
				1,					// cost
				0,					// count
				10,					// purchaseAmount
				true,				// isStackable
				false,				// equipped
                15f,				// damage
                20f         		// velocity
         	)
		);

        bulletPrototypes.Add("MP5_Bullet",
            new Bullet(
                "MP5_Bullet",		// name
				1,					// cost
				0,					// count
				50,					// purchaseAmount
				true,				// isStackable
				false,				// equipped
				25f,				// damage
				20f         		// velocity
            )
        );

        bulletPrototypes.Add("Shotgun_Bullet",
            new Bullet(
                "Shotgun_Bullet",	// name
				1,					// cost
				0,					// count
				5,					// purchaseAmount
				true,				// isStackable
				false,				// equipped
				50f,				// damage
				40f         		// velocity
            )
        );

        bulletPrototypes.Add("Uzi_Bullet",
            new Bullet(
                "Uzi_Bullet",		// name
				1,					// cost
				0,					// count
				20,					// purchaseAmount
				true,				// isStackable
				false,				// equipped
				30f,				// damage
				25f         		// velocity
            )
        );

        bulletPrototypes.Add("Sniper_Bullet",
            new Bullet(
                "Sniper_Bullet",	// name
				1,					// cost
				0,					// count
				7,					// purchaseAmount
				true,				// isStackable
				false,				// equipped
				90f,				// damage
				70f         		// velocity
            )
        );

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
				1,						// cost
				0,						// count
				30,						// purchaseAmount
				true,					// isStackable
				false,					// equipped
				30f,					// damage
				25f         			// velocity
            )
        );

        bulletPrototypes.Add("Machinegun_Bullet",
            new Bullet(
                "Machinegun_Bullet",	// name
				1,						// cost
				0,						// count
				100,					// purchaseAmount
				true,					// isStackable
				false,					// equipped
				30f,					// damage
				25f         			// velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher_Bullet",
            new Bullet(
                "RocketLauncher_Bullet",	// name
				1,							// cost
				0,							// count
				3,							// purchaseAmount
				true,						// isStackable
				false,						// equipped
				30f,						// damage
				25f         				// velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher_Modern_Bullet",
            new Bullet(
                "RocketLauncher_Modern_Bullet",		// name
				1,									// cost
				0,									// count
				3,									// purchaseAmount
				true,								// isStackable
				false,								// equipped
				30f,								// damage
				25f         						// velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher_Side_Bullet",
            new Bullet(
                "RocketLauncher_Side_Bullet",	// name
				1,								// cost
				0,								// count
				3,								// purchaseAmount
				true,							// isStackable
				false,							// equipped
				30f,							// damage
				25f         					// velocity
            )
        );
    }

    /// <summary>
    /// Creates the knife proto.
    /// </summary>

    void CreateKnifeProto()
    {
        weaponPrototypes.Add("Knife",
            new Weapon(
				"Knife",	// name
				1,			// cost
				0,			// count
				1,			// purchaseAmount
				false,		// isStackable
				false,		// equipped
				null		// Bullet
			)
        );

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
        weaponPrototypes.Add("Knife_Smooth",
            new Weapon(
				"Knife_Smooth",		// name
				1,					// cost
				0,					// count
				1,					// purchaseAmount
				false,				// isStackable
				false,				// equipped
				null				// Bullet
			)
        );

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
        weaponPrototypes.Add("Knife_Sharp",
            new Weapon(
				"Knife_Sharp",		// name
				1,					// cost
				0,					// count
				1,					// purchaseAmount
				false,				// isStackable
				false,				// equipped
				null				// Bullet
			)
        );
			
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
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);

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
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);

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
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);

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
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);

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
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);

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
	// These gun's weaponParameters have not edited.

    /// Knife_Sharp
    /// Knife_Smooth
    /// RockerLauncher
    /// RockerLauncher_Modern
    /// RockerLauncher_Side
    /// Uzi_Long
    /// Machinegun

    void CreateRocketLauncherProto()
    {
		string name = "RocketLauncher";

        weaponPrototypes.Add(name,
			new Weapon(
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet		
            )
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

    void CreateRocketLauncher_ModernProto()
    {
		string name = "RocketLauncher_Modern";

		weaponPrototypes.Add(name,
            new Weapon(
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet		
            )
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]
        );
    }
    void CreateRocketLauncher_SideProto()
    {
		string name = "RocketLauncher_Side";

		weaponPrototypes.Add(name,
        new Weapon(
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet	
        	)
		);

		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]
        );
    }

    void CreateMachinegunProto()
    {
		string name = "Machinegun";

		weaponPrototypes.Add(name,
            new Weapon(
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
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

    void CreateUzi_LongProto()
    {
		string name = "Uzi_Long";

		weaponPrototypes.Add(name,
            new Weapon(
				name,			// name
				1,				// cost
				0,				// count
				1,				// purchaseAmount
				false,			// isStackable
				false,			// equipped
				bulletPrototypes[name + "_Bullet"].Clone() as Bullet	// bullet
            )
		);
				
		weaponPrototypes[name].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

		weaponPrototypes[name].weaponParameters.Add(
            "fireCoolDown",
			-weaponPrototypes[name].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

		weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }
	#endregion
}

