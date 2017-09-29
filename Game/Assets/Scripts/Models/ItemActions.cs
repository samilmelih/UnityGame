

using UnityEngine;

public class ItemActions : MonoBehaviour
{
    #region Singelton

    public static ItemActions Instance;

    private void Awake()
    {
        Instance = this;

        DontDestroyOnLoad(Instance);
    }

    #endregion

    #region Weapons
    public void CloseWeapons(Character character)
    {
        Debug.Log("This weapon's attack mode is not implemented.");

        ///we can ray from the object for a specified distance
    }

    public void Weapons_One_Shot(Character character)
    {
        GameObject go_mainCharacter = CharacterCont.Instance.go_mainCharacter;
        Weapon weapon = character.currentWeapon;

        float currTime = Time.time;

        if (currTime - weapon.weaponParameters[StringLiterals.FireCoolDown] > weapon.weaponParameters[StringLiterals.FireFrequency])
        {
            if (weapon.weaponParameters[StringLiterals.MagazineCount] > 0f)
            {
                SoundController.Instance.Shot();
                GameObject chr_go;

                if (character.Type == StringLiterals.EnemyName)
                {
                    chr_go = EnemyController.Instance.enemyGOMap[character];
                }
                else if (character.Type == StringLiterals.CharacterName)
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

                weapon.weaponParameters[StringLiterals.MagazineCount] -= 1;
                weapon.bullet.count -= 1;

                weapon.weaponParameters[StringLiterals.FireCoolDown] = Time.time;
            }
            else
            {
                // We are out of bullet.

                if (character.Type == StringLiterals.CharacterName)
                {
                    int reloadableBulletCount = Mathf.Min(
                        weapon.bullet.count,
                        (int)weapon.weaponParameters[StringLiterals.MagazineCapacity]
                    );

                    weapon.weaponParameters[StringLiterals.MagazineCount] = reloadableBulletCount;
                }
                else
                    weapon.weaponParameters[StringLiterals.MagazineCount] = weapon.weaponParameters[StringLiterals.MagazineCapacity];
            }
        }
    }
    #endregion

    #region HealPot
    //TODO: HealPot Actions


    //Şuan iyileştirme aşaması başladı mı?
    bool healing = false;
    //şuan kullandığımız HealPot
    HealPot currentHealPot = null;

    //Yapılan iyileştirme miktarı. Bu miktar potun MaxHealValue 'su kadar olmalı toplam iyileştirmeyi bu şekilde bulabiliriz.
    float topHealing = 0;
    private void Update()
    {

        if (healing == true)
        {
            //karakterimizin can değerini artırmak istediğimiz miktarın hesabı : saniyede ne kadar can dolmasını istyoruz.
            //Healingtime = 10 MaxHealingValue 40 olsun bu 10 saniyede 40 can yenilemek istiyorum demek yani saniyede 4 can yenileyeceğiz
            // (currentHealPot.maxHealValue / currentHealPot.healingTime) * Time.deltaTime 
            WorldController.Instance.world.character.health += (currentHealPot.maxHealValue / currentHealPot.healingTime) * Time.deltaTime;

            //şuana kadar yapılan toplam iyileştirme miktarını bu değişkende tutuyoruz
            topHealing += (currentHealPot.maxHealValue / currentHealPot.healingTime) * Time.deltaTime;

            //örneğin canımız 77 potumuz geliştirilmiş ve 50 can değeri var. Kullandığımızda 100 ün üstüne geçmesini istemiyorum
            WorldController.Instance.world.character.health = Mathf.Clamp(WorldController.Instance.world.character.health, 0, 100);

            //eğer yapmamız gereken iyiliştirme miktarına ulaşmısak yada canımız maximum değerinde ise(100 değerini ve 0 değerini bir değişken yapabiliriz characterMaxHealth  characterMinHealthv gibi)
            if (topHealing >= currentHealPot.maxHealValue ||
                WorldController.Instance.world.character.health == 100)
            {
                //iyileşme süreci sona erdi değerleri eski haline getir
                healing = false;
                currentHealPot.UnregisterHealPotAction(HealPotAct);
                topHealing = 0;
            }

        }

    }
    public void HealPotAct(HealPot h)
    {
        //Bazı kodlar geçici olacağı için açıklamalrı türkçe yapıyorum

        //Eğer biz bir pot kullanmış isek iyileşme süreci başlamış demektir
        //ve hangi pot bizi iyileştiriyor bu bilgiye ihtiyacımız olacak bunu almanın en iyi yolu bu olmayabilir
        currentHealPot = h;
        healing = true;




    }



    #endregion
}
