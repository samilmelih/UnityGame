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
            weaponPrototypes["Knife"].cost = 50;
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
            weaponPrototypes["Magnum"].cost = 150;
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
            weaponPrototypes["Shotgun"].cost = 700;
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
            weaponPrototypes["MP5"].cost = 500;
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


        void CreateUziProto()
        {
            weaponPrototypes.Add(
                "Uzi",
                new Weapon("Uzi", bulletPrototypes["Uzi"])
            );

            weaponPrototypes["Uzi"].type = WeaponType.Rifle;
            weaponPrototypes["Uzi"].cost = 300;
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
    }


