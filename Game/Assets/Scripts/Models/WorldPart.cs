using System;


public partial class World
{
    #region Protos

    /// <summary>
    /// Creates the bullet protos.
    /// </summary>
    void CreateBulletProtos()
    {
        bulletPrototypes.Add(
            "Magnum",
            //  Type, damage, speed
            new Bullet(
                "Magnum",   // name
                15f,        // damage
                20f         // velocity
            )

        );

        bulletPrototypes.Add("MP5",
            new Bullet(
                "MP5",      // name
                25,         // damage
                20          // velocity
            )
        );

        bulletPrototypes.Add("Shotgun",
            new Bullet(
                "Shotgun",      // name
                50,         // damage
                40          // velocity
            )
        );


        bulletPrototypes.Add("Uzi",
            new Bullet(
                "Uzi",      // name
                30,         // damage
                25          // velocity
            )
        );
        bulletPrototypes.Add("Sniper",
            new Bullet(
                "Sniper",      // name
                90,         // damage
                70          // velocity
            )
        );




        ///Knife_Sharp
        /// Knife_Smooth
        /// RockerLauncher
        /// RockerLauncher_Modern
        /// RockerLauncher_Side
        /// Uzi_Long
        /// Machinegun

        bulletPrototypes.Add("Uzi_Long",
            new Bullet(
                "Uzi_Long",      // name
                30,         // damage
                25          // velocity
            )
        );

        bulletPrototypes.Add("Machinegun",
            new Bullet(
                "Machinegun",      // name
                30,         // damage
                25          // velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher",
            new Bullet(
                "RocketLauncher",      // name
                30,         // damage
                25          // velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher_Modern",
            new Bullet(
                "RocketLauncher_Modern",      // name
                30,         // damage
                25          // velocity
            )
        );

        bulletPrototypes.Add("RocketLauncher_Side",
            new Bullet(
                "RocketLauncher_Side",      // name
                30,         // damage
                25          // velocity
            )
        );

    
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
        weaponPrototypes.Add(
            "Magnum",
            new Weapon("Magnum", bulletPrototypes["Magnum"])
        );

        weaponPrototypes["Magnum"].type = WeaponType.Gun;
        weaponPrototypes["Magnum"].cost = 1;
        weaponPrototypes["Magnum"].weaponParameters.Add(
            "fireFrequency",
            1f      // .5 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Magnum"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Magnum"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Magnum"].weaponParameters.Add(
            "bulletCount",
            10
        );
        weaponPrototypes["Magnum"].weaponParameters.Add(
            "maxBulletCount",
            10
        );

        weaponPrototypes["Magnum"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateShotgunProto()
    {

        weaponPrototypes.Add(
            "Shotgun",
            new Weapon("Shotgun", bulletPrototypes["Shotgun"])
        );

        weaponPrototypes["Shotgun"].type = WeaponType.Rifle;
        weaponPrototypes["Shotgun"].cost = 1;
        weaponPrototypes["Shotgun"].weaponParameters.Add(
            "fireFrequency",
            1f      // .5 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Shotgun"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Shotgun"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Shotgun"].weaponParameters.Add(
            "bulletCount",
            7
        );
        weaponPrototypes["Shotgun"].weaponParameters.Add(
            "maxBulletCount",
            7
        );

        weaponPrototypes["Shotgun"].cbAttack += WeaponActions.One_Shot;
    }

    /// <summary>
    /// Creates the Mp5 proto.
    /// </summary>
    void CreateMP5Proto()
    {
        weaponPrototypes.Add(
            "MP5",
            new Weapon("MP5", bulletPrototypes["MP5"])
        );

        weaponPrototypes["MP5"].type = WeaponType.Rifle;
        weaponPrototypes["MP5"].cost = 1;
        weaponPrototypes["MP5"].weaponParameters.Add(
            "fireFrequency",
            .3f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["MP5"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["MP5"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["MP5"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["MP5"].weaponParameters.Add(
            "maxBulletCount",
            30
        );

        weaponPrototypes["MP5"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateSniperProto()
    {
        weaponPrototypes.Add(
            "Sniper",
            new Weapon("Sniper", bulletPrototypes["Sniper"])
        );

        weaponPrototypes["Sniper"].type = WeaponType.Rifle;
        weaponPrototypes["Sniper"].cost = 1;
        weaponPrototypes["Sniper"].weaponParameters.Add(
            "fireFrequency",
            .5f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Sniper"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Sniper"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Sniper"].weaponParameters.Add(
            "bulletCount",
            10);
        weaponPrototypes["Sniper"].weaponParameters.Add(
            "maxBulletCount",
            10
        );

        weaponPrototypes["Sniper"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUziProto()
    {
        weaponPrototypes.Add(
            "Uzi",
            new Weapon("Uzi", bulletPrototypes["Uzi"])
        );

        weaponPrototypes["Uzi"].type = WeaponType.Rifle;
        weaponPrototypes["Uzi"].cost = 1;
        weaponPrototypes["Uzi"].weaponParameters.Add(
            "fireFrequency",
            .1f // .1 saniyede bir ateş edilebilir
        );

        weaponPrototypes["Uzi"].weaponParameters.Add(
            "fireCoolDown",
            -weaponPrototypes["Uzi"].weaponParameters["fireFrequency"]   // Başlangıç aniden ateş edebilmesi için gerekli
        );

        weaponPrototypes["Uzi"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["Uzi"].weaponParameters.Add(
            "maxBulletCount",
            30
        );

        weaponPrototypes["Uzi"].cbAttack += WeaponActions.One_Shot;
    }

    #endregion

    #region newGuns

    ///Knife_Sharp
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
            new Weapon("RocketLauncher", bulletPrototypes["RocketLauncher"])
        );

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

        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "maxBulletCount",
            30
        );

        weaponPrototypes["RocketLauncher"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateRocketLauncher_ModernProto()
    {
        weaponPrototypes.Add(
            "RocketLauncher_Modern",
            new Weapon("RocketLauncher_Modern", bulletPrototypes["RocketLauncher_Modern"])
        );

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

        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "maxBulletCount",
            30
        );
    }
        void CreateRocketLauncher_SideProto()
        {
            weaponPrototypes.Add(
                "RocketLauncher_Side",
                new Weapon("RocketLauncher_Side", bulletPrototypes["RocketLauncher_Side"])
            );

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

            weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
                "bulletCount",
                30
            );
            weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
                "maxBulletCount",
                30
            );
        }

    void CreateMachinegunProto()
    {
        weaponPrototypes.Add(
            "Machinegun",
            new Weapon("Machinegun", bulletPrototypes["Machinegun"])
        );

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

        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "maxBulletCount",
            30
        );

        weaponPrototypes["Machinegun"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUzi_LongProto()
    {
        weaponPrototypes.Add(
            "Uzi_Long",
            new Weapon("Uzi_Long", bulletPrototypes["Uzi_Long"])
        );

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

        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "bulletCount",
            30
        );
        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "maxBulletCount",
            30
        );

        weaponPrototypes["Uzi_Long"].cbAttack += WeaponActions.One_Shot;
    }
    #endregion
}

