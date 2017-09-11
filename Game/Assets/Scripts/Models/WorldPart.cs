﻿public partial class World
{
    #region Protos

    /// <summary>
    /// Creates the bullet protos.
    /// </summary>
    void CreateBulletProtos()
    {

        //Magnum
        string name = StringLiterals.GetBulletNameForGun(StringLiterals.Magnum);

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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


        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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

        bulletPrototypes.Add(name,
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
        weaponPrototypes.Add(name,
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

        weaponPrototypes[name].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes[name].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes[name].cbAttack += WeaponActions.CloseWeapons;


    }

    void CreateKnife_SmoothProto()
    {
        string name = StringLiterals.KnifeSmooth;

        weaponPrototypes.Add(name,
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

        weaponPrototypes[name].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes[name].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes[name].cbAttack += WeaponActions.CloseWeapons;
    }

    void CreateKnife_SharpProto()
    {
        string name = StringLiterals.Knife_Sharp;
        weaponPrototypes.Add(name,
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

        weaponPrototypes[name].weaponParameters.Add(
            "hitPower",
            5
        );

        weaponPrototypes[name].weaponParameters.Add(
            "hitSpeed",
            2
        );

        weaponPrototypes[name].cbAttack += WeaponActions.CloseWeapons;
    }

    /// <summary>
    /// Creates the magnum proto.
    /// </summary>
    void CreateMagnumProto()
    {
        string name = StringLiterals.Magnum;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MaxMagazineCount,
            14f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            1f      // .5 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]   // Başlangıçta aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateShotgunProto()
    {
        string name = StringLiterals.Shotgun;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MaxMagazineCount,
            3f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireFrequency,
            1f      // .5 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    /// <summary>
    /// Creates the Mp5 proto.
    /// </summary>
    void CreateMP5Proto()
    {
        string name = StringLiterals.Mp5;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MaxMagazineCount,
            50f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .3f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateSniperProto()
    {
        string name = StringLiterals.Sniper;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MaxMagazineCount,
            6f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .5f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUziProto()
    {
        string name = StringLiterals.Uzi;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MaxMagazineCount,
            30f
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.MagazineCount,
            0f
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
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
        string name = StringLiterals.RocketLauncher;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet		
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateRocketLauncher_ModernProto()
    {
        string name = StringLiterals.RocketLauncherModern;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet		
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );
    }
    void CreateRocketLauncher_SideProto()
    {
        string name = StringLiterals.RocketLauncherSide;

        weaponPrototypes.Add(name,
        new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet    // bullet	
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );
    }

    void CreateMachinegunProto()
    {
        string name = StringLiterals.Machinegun;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUzi_LongProto()
    {
        string name = StringLiterals.UziLong;

        weaponPrototypes.Add(name,
            new Weapon(
                name,           // name
                1,              // cost
                0,              // count
                1,              // purchaseAmount
                false,          // isStackable
                false,          // equipped
                bulletPrototypes[StringLiterals.GetBulletNameForGun(name)].Clone() as Bullet	// bullet
            )
        );

        weaponPrototypes[name].weaponParameters.Add(
             StringLiterals.FireFrequency,
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes[name].weaponParameters.Add(
            StringLiterals.FireCoolDown,
            -weaponPrototypes[name].weaponParameters[StringLiterals.FireFrequency]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes[name].cbAttack += WeaponActions.One_Shot;
    }
    #endregion
}

