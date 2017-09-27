using System;
using System.Collections.Generic;
using UnityEngine;

public partial class World
{
    // We only can Instantiate Character Instance in the world
    // THINK: We can have multiple characters soon maybe???(think about it)
    // Yes, maybe AI allies?

    public Character character { get; protected set; }

    public CheckpointManager checkpointManager;

    public List<Character> enemies { get; protected set; }

    public Dictionary<string, Item> itemProtoTypes;

    Action<Character> cbOnEnemyChanged;
    Action<Character> cbOnEnemyDestroyed;

    bool firstTimeStarted;

    public World()
    {
        firstTimeStarted = PlayerPrefsController.FirstTimeStarted;

        itemProtoTypes = new Dictionary<string, Item>();

        CreatePrototypes();

        CreateCharacters();
        CreateEnemies();

        // Character should be created before checkpoint manager. Because it uses character.
        checkpointManager = new CheckpointManager(character);
    }




    void CreateCharacters()
    {
        // We only have one character, maybe later we'll have allias?
        // If we have, We need a character list.
        character = new Character(this);
        character.Type = StringLiterals.CharacterName;
        character.money = (firstTimeStarted) ? 200 : PlayerPrefsController.Money;

        // Default move speed in x-axis is +-5f.
        // Default jump speed in y-axis is 12f.
        character.speed = new Vector2(7f, 12f);

        // At the begining our characters looks right
        character.direction = Direction.Right;
        character.scale = new Vector3(1f, 1f, 0f);

        Inventory ch_inventory = new Inventory(this);
        character.inventory = ch_inventory;
    }

    void CreateEnemies()
    {
        enemies = new List<Character>();

        for (int i = 0; i < 20; i++)
        {
            Character enemy = new Character(this);
            enemy.Type = StringLiterals.EnemyName;

            // Default move speed in x-axis is +-3f.
            // Default jump speed in y-axis is 9f.
            enemy.speed = new Vector2(3f, 9f);

            enemy.direction = (Direction)UnityEngine.Random.Range(1, 3);
            if (enemy.direction == Direction.Left)
                enemy.scale = new Vector3(-1f, 1f, 0f);
            else
                enemy.scale = new Vector3(1f, 1f, 0f);

            // FIXME: şimdilik oyunun akışı açısından silah atamasını rastgele yapıyorum
            if (UnityEngine.Random.Range(0, 2) == 0)
            {
                enemy.currentWeapon = itemProtoTypes[StringLiterals.Magnum].Clone() as Weapon;
            }
            else
            {
                enemy.currentWeapon = itemProtoTypes[StringLiterals.Mp5].Clone() as Weapon;
            }
            enemies.Add(enemy);
        }
    }

    //Bu çok uzun bir metod olacak parçalara ayıracağız muhtemelen her bir silah için ayrı bir metod yapmak daha okunaklı olacaktır
    void CreatePrototypes()
    {
        CreateBulletProtos();

        CreateMagnumProto();

        CreateMP5Proto();

        CreateKnifeProto();

        CreateShotgunProto();

        CreateUziProto();

        CreateSniperProto();

        CreateKnife_SharpProto();

        CreateKnife_SmoothProto();

        CreateRocketLauncherProto();

        CreateRocketLauncher_SideProto();

        CreateRocketLauncher_ModernProto();

        CreateUzi_LongProto();

        CreateMachinegunProto();
    }

    public void OnEnemyChanged(Character enemy)
    {
        if (cbOnEnemyChanged != null)
            cbOnEnemyChanged(enemy);
    }

    public void OnEnemyDestroyed(Character enemy)
    {
        if (cbOnEnemyDestroyed != null)
            cbOnEnemyDestroyed(enemy);
    }

    public void RegisterOnEnemyChangedCallback(Action<Character> cb)
    {
        cbOnEnemyChanged += cb;
    }

    public void RegisterOnEnemyDestroyedCallback(Action<Character> cb)
    {
        cbOnEnemyDestroyed += cb;
    }

    public void ResetWorldCallbacks()
    {
        cbOnEnemyChanged = null;
        cbOnEnemyDestroyed = null;
    }
}
