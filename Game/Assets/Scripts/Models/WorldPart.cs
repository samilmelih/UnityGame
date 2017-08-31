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
            "Magnum_Bullet",
            //  Type, damage, speed
            new Bullet(
                "Magnum_Bullet",   // name
                15f,        // damage
                20f,         // velocity
                10          //Bullet Count that a magazine can carry
            )

        );

        bulletPrototypes["Magnum_Bullet"].cost = 1;

        bulletPrototypes.Add("MP5_Bullet",
            new Bullet(
                "MP5_Bullet",      // name
                25,         // damage
                20,          // velocity
                25              //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["MP5_Bullet"].cost = 1;

        bulletPrototypes.Add("Shotgun_Bullet",
            new Bullet(
                "Shotgun_Bullet",      // name
                50,         // damage
                40 ,         // velocity
                7          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["Shotgun_Bullet"].cost = 1;

        bulletPrototypes.Add("Uzi_Bullet",
            new Bullet(
                "Uzi_Bullet",      // name
                30,         // damage
                25,          // velocity
                30          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["Uzi_Bullet"].cost = 1;

        bulletPrototypes.Add("Sniper_Bullet",
            new Bullet(
                "Sniper_Bullet",      // name
                90,         // damage
                70,          // velocity
                10          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["Sniper_Bullet"].cost = 1;



        ///Knife_Sharp
        /// Knife_Smooth
        /// RockerLauncher
        /// RockerLauncher_Modern
        /// RockerLauncher_Side
        /// Uzi_Long
        /// Machinegun

        bulletPrototypes.Add("Uzi_Long_Bullet",
            new Bullet(
                "Uzi_Long_Bullet",      // name
                30,         // damage
                25,          // velocity
                30          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["Uzi_Long_Bullet"].cost = 1;

        bulletPrototypes.Add("Machinegun_Bullet",
            new Bullet(
                "Machinegun_Bullet",      // name
                30,         // damage
                25,          // velocity
                40          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["Machinegun_Bullet"].cost = 1;

        bulletPrototypes.Add("RocketLauncher_Bullet",
            new Bullet(
                "RocketLauncher_Bullet",      // name
                30,         // damage
                25,          // velocity
                5          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["RocketLauncher_Bullet"].cost = 1;

        bulletPrototypes.Add("RocketLauncher_Modern_Bullet",
            new Bullet(
                "RocketLauncher_Modern_Bullet",      // name
                30,         // damage
                25,          // velocity
                5          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["RocketLauncher_Modern_Bullet"].cost = 1;

        bulletPrototypes.Add("RocketLauncher_Side_Bullet",
            new Bullet(
                "RocketLauncher_Side_Bullet",      // name
                30,         // damage
                25,          // velocity
                5          //Bullet Count that a magazine can carry
            )
        );

        bulletPrototypes["RocketLauncher_Side_Bullet"].cost = 1;

    
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
            new Weapon(

                "Magnum", 
                bulletPrototypes["Magnum_Bullet"]

            ));

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
            bulletPrototypes["Magnum_Bullet"].count
        );
        weaponPrototypes["Magnum"].weaponParameters.Add(
            "maxBulletCount",
            bulletPrototypes["Magnum_Bullet"].count
        );

        weaponPrototypes["Magnum"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateShotgunProto()
    {

        weaponPrototypes.Add(
           
            "Shotgun",
            new Weapon(

                "Shotgun",
                bulletPrototypes["Shotgun_Bullet"]
            
            ));

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

            bulletPrototypes["Shotgun_Bullet"].count
        );
        weaponPrototypes["Shotgun"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["Shotgun_Bullet"].count
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
            new Weapon(

                "MP5", 
                bulletPrototypes["MP5_Bullet"]
            
            ));

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

            bulletPrototypes["MP5_Bullet"].count
        );
        weaponPrototypes["MP5"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["MP5_Bullet"].count
        );

        weaponPrototypes["MP5"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateSniperProto()
    {
        weaponPrototypes.Add(
           
            "Sniper",
            new Weapon(
                
                "Sniper", 
                bulletPrototypes["Sniper_Bullet"]
            
            ));

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

            bulletPrototypes["Sniper_Bullet"].count
        );
        weaponPrototypes["Sniper"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["Sniper_Bullet"].count
        );

        weaponPrototypes["Sniper"].cbAttack += WeaponActions.One_Shot;
    }

    void CreateUziProto()
    {
        weaponPrototypes.Add(
           
            "Uzi",
            new Weapon(

                "Uzi",
                bulletPrototypes["Uzi_Bullet"]
            
            ));

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

            bulletPrototypes["Uzi_Bullet"].count
        );
        weaponPrototypes["Uzi"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["Uzi_Bullet"].count
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

        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "bulletCount",

            bulletPrototypes["RocketLauncher_Bullet"].count
        );
        weaponPrototypes["RocketLauncher"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["RocketLauncher_Bullet"].count
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

        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "bulletCount",

            bulletPrototypes["RocketLauncher_Modern_Bullet"].count
        );
        weaponPrototypes["RocketLauncher_Modern"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["RocketLauncher_Modern_Bullet"].count
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

            weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
                "bulletCount",

            bulletPrototypes["RocketLauncher_Side_Bullet"].count
            );
            weaponPrototypes["RocketLauncher_Side"].weaponParameters.Add(
                "maxBulletCount",

            bulletPrototypes["RocketLauncher_Side_Bullet"].count
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

        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "bulletCount",

            bulletPrototypes["Machinegun_Bullet"].count
        );
        weaponPrototypes["Machinegun"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["Machinegun_Bullet"].count
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

        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "bulletCount",

            bulletPrototypes["Uzi_Long_Bullet"].count
        );
        weaponPrototypes["Uzi_Long"].weaponParameters.Add(
            "maxBulletCount",

            bulletPrototypes["Uzi_Long_Bullet"].count
        );

        weaponPrototypes["Uzi_Long"].cbAttack += WeaponActions.One_Shot;
    }
    #endregion
}

