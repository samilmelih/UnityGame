public partial class World
{
    #region Protos

    /// <summary>
    /// Creates the bullet protos.
    /// </summary>
    void CreateBulletProtos()
    {

        //Magnum
        string name = StringLiterals.GetBulletNameForGun(StringLiterals.Magnum);

        itemProtoTypes.Add(name,
            new Bullet(
                name,               // name
                1,                  // cost
                0,                  // count
                10,                 // purchaseAmount
                true,               // isStackable
                false,				// equipped
                15f,				// damage
                20f                 // velocity
            )
        );


        //Mp5
        name = StringLiterals.GetBulletNameForGun(StringLiterals.Mp5);

        itemProtoTypes.Add(name,
            new Bullet(
                name,               // name
                1,                  // cost
                0,                  // count
                50,                 // purchaseAmount
                true,               // isStackable
                false,              // equipped
                25f,                // damage
                20f         		// velocity
            )
        );

        //Shotgun
        name = StringLiterals.GetBulletNameForGun(StringLiterals.Shotgun);

        itemProtoTypes.Add(name,
            new Bullet(
                name,               // name
                1,                  // cost
                0,                  // count
                5,                  // purchaseAmount
                true,               // isStackable
                false,              // equipped
                50f,                // damage
                40f         		// velocity
            )
        );

        //Uzi
        name = StringLiterals.GetBulletNameForGun(StringLiterals.Uzi);

        itemProtoTypes.Add(name,
            new Bullet(
                name,               // name
                1,                  // cost
                0,                  // count
                20,                 // purchaseAmount
                true,               // isStackable
                false,              // equipped
                30f,                // damage
                25f         		// velocity
            )
        );

        //Sniper
        name = StringLiterals.GetBulletNameForGun(StringLiterals.Sniper);

        itemProtoTypes.Add(name,
            new Bullet(
               name,                // name
                1,                  // cost
                0,                  // count
                7,                  // purchaseAmount
                true,               // isStackable
                false,              // equipped
                90f,                // damage
                70f         		// velocity
            )
        );

        //UziLong
        name = StringLiterals.GetBulletNameForGun(StringLiterals.UziLong);


        itemProtoTypes.Add(name,
            new Bullet(
                name,                   // name
                1,                      // cost
                0,                      // count
                30,                     // purchaseAmount
                true,                   // isStackable
                false,                  // equipped
                30f,                    // damage
                25f         			// velocity
            )
        );

        //Machinegun
        name = StringLiterals.GetBulletNameForGun(StringLiterals.Machinegun);

        itemProtoTypes.Add(name,
            new Bullet(
                name,                   // name
                1,                      // cost
                0,                      // count
                100,                    // purchaseAmount
                true,                   // isStackable
                false,                  // equipped
                30f,                    // damage
                25f         			// velocity
            )
        );

        //RocketLauncher
        name = StringLiterals.GetBulletNameForGun(StringLiterals.RocketLauncher);

        itemProtoTypes.Add(name,
            new Bullet(
                name,                       // name
                1,                          // cost
                0,                          // count
                3,                          // purchaseAmount
                true,                       // isStackable
                false,                      // equipped
                30f,                        // damage
                25f         				// velocity
            )
        );

        //RocketLauncherModern
        name = StringLiterals.GetBulletNameForGun(StringLiterals.RocketLauncherModern);

        itemProtoTypes.Add(name,
            new Bullet(
                name,                               // name
                1,                                  // cost
                0,                                  // count
                3,                                  // purchaseAmount
                true,                               // isStackable
                false,                              // equipped
                30f,                                // damage
                25f         						// velocity
            )
        );

        //RocketLauncherSide
        name = StringLiterals.GetBulletNameForGun(StringLiterals.RocketLauncherSide);

        itemProtoTypes.Add(name,
            new Bullet(
                name,                           // name
                1,                              // cost
                0,                              // count
                3,                              // purchaseAmount
                true,                           // isStackable
                false,                          // equipped
                30f,                            // damage
                25f         					// velocity
            )
        );
    }

    /// <summary>
    /// Creates the knife proto.
    /// </summary>

    void CreateKnifeProto()
    {
        string name = StringLiterals.Knife;
        itemProtoTypes.Add(name,
            new Weapon(
                name,    // name
                1,          // cost
                0,          // count
                1,          // purchaseAmount
                false,      // isStackable
                false,      // equipped
                null        // Bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitPower",
            5
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitSpeed",
            2
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.CloseWeapons;


    }

    void CreateKnife_SmoothProto()
    {
        string name = StringLiterals.KnifeSmooth;

        itemProtoTypes.Add(name,
            new Weapon(
                name,     // name
                1,                  // cost
                0,                  // count
                1,                  // purchaseAmount
                false,              // isStackable
                false,              // equipped
                null                // Bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitPower",
            5
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitSpeed",
            2
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.CloseWeapons;
    }

    void CreateKnife_SharpProto()
    {
        string name = StringLiterals.Knife_Sharp;
        itemProtoTypes.Add(name,
            new Weapon(
                name,      // name
                1,                  // cost
                0,                  // count
                1,                  // purchaseAmount
                false,              // isStackable
                false,              // equipped
                null                // Bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitPower",
            5
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            "hitSpeed",
            2
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.CloseWeapons;
    }

    /// <summary>
    /// Creates the magnum proto.
    /// </summary>
    void CreateMagnumProto()
    {
        string name = StringLiterals.Magnum;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCapacity,
            14f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]   // Başlangıçta aniden ateş edebilmesi için gerekli
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    void CreateShotgunProto()
    {
        string name = StringLiterals.Shotgun;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCapacity,
            3f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireFrequency,
            1f      // .5 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    /// <summary>
    /// Creates the Mp5 proto.
    /// </summary>
    void CreateMP5Proto()
    {
        string name = StringLiterals.Mp5;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCapacity,
            50f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .3f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    void CreateSniperProto()
    {
        string name = StringLiterals.Sniper;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCapacity,
            6f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .5f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    void CreateUziProto()
    {
        string name = StringLiterals.Uzi;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCapacity,
            30f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    // *******TODO******TODO*******
    // These gun's weaponParameters have not edited.



    void CreateRocketLauncherProto()
    {
        string name = StringLiterals.RocketLauncher;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet		
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    void CreateRocketLauncher_ModernProto()
    {
        string name = StringLiterals.RocketLauncherModern;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet		
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );
    }
    void CreateRocketLauncher_SideProto()
    {
        string name = StringLiterals.RocketLauncherSide;

        itemProtoTypes.Add(name,
        new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet    // bullet	
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );
    }

    void CreateMachinegunProto()
    {
        string name = StringLiterals.Machinegun;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }

    void CreateUzi_LongProto()
    {
        string name = StringLiterals.UziLong;

        itemProtoTypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                itemProtoTypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        (itemProtoTypes[name] as Weapon).weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -(itemProtoTypes[name] as Weapon).weaponParameters[StringLiterals.FireFrequency]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        (itemProtoTypes[name] as Weapon).cbAttack += ItemActions.Weapons_One_Shot;
    }
    #endregion
}

