﻿using System;
using UnityEditor;
using UnityEngine;

public class Character
{
    public float health = 100f;
    public float mana = 100;
    public int money;

    /// <summary>
    /// If we have level system then we need to increase some variables
    /// depend on this
    /// </summary>
    int CurrentLevel;

    public Direction direction;

    //bu şimdilik public buna daha iyi çözümler üretebiliriz
    public bool isAlive = true;

    // FIXME: bunun public olma konusunda düşün
    public Weapon currentWeapon;

    public string Type { get; set; }

    public Vector2 lastPosition;

    public Vector2 currPosition;

    // This is just speed, no direction. We use this to get velocity
    public Vector2 speed;

    // For updating velocity of our character
    public Vector2 velocity;

    // For updating scale of our character
    public Vector3 scale;

    Action<Character> cbOnAttack;
    Action<Character> cbOnJump;
    Action<Character> cbOnCrouch;
    Action<Character> cbOnWalk;
    

    public Inventory inventory;

    World world;

    public Character(World world)
    {
        this.world = world;
    }

    public void ChangeWeapon(int slot)
    {
        inventory.ChangeWeapon(slot);
    }

    public void Attack()
    {
        if (cbOnAttack != null)
        {
            cbOnAttack(this);
        }
    }

    public void Walk(float axis)
    {
        velocity.x = speed.x * axis;

        lastPosition = currPosition;
        currPosition = CharacterCont.GetCharacterPosition();

        if (axis < 0)
        {
            scale = new Vector2(-1f, 1f);
            direction = Direction.Left;
        }
        else if (axis > 0)
        {
            scale = new Vector2(1f, 1f);
            direction = Direction.Right;
        }

		world.checkpointManager.Check();

        if (cbOnWalk != null)
            cbOnWalk(this);
    }

    public bool IsCharacterAtEdge()
    {
        Vector3 characterPos = CharacterCont.GetCharacterPosition();
        Vector3 leftCameraEdge = CameraController.GetLeftEdgePosition();
        Vector3 rightCameraEdge = CameraController.GetRightEdgePosition();

        // FIXME: Make constant offsets.
        if (characterPos.x <= leftCameraEdge.x + 2f && direction == Direction.Left ||
           characterPos.x >= rightCameraEdge.x - 2f && direction == Direction.Right
        ){
            return true;
        }

        return false;
    }

    public void Jump()
    {
        velocity.y = speed.y;
        if (cbOnJump != null)
            cbOnJump(this);
    }

    public void Crouch()
    {

    }


    public void RegisterOnAttackCallback(Action<Character> cb)
    {
        cbOnAttack += cb;
    }

    public void RegisterOnJumpCallback(Action<Character> cb)
    {
        cbOnJump += cb;
    }

    public void RegisterOnCrouchCallback(Action<Character> cb)
    {
        cbOnCrouch += cb;
    }

    public void RegisterOnWalkCallback(Action<Character> cb)
    {
        cbOnWalk += cb;
    }

    public void ResetCharacterCallbacks()
    {
        cbOnAttack = null;
        cbOnJump = null;
        cbOnCrouch = null;
        cbOnWalk = null;
    }

    public void TakeDamage(float damage, BodyPart bodyPart)
    {

        //TODO: We can hit the head of the enemy or enemy can hit our head
        //check to see if we have any armor so if enemy hits us then we can take less damage
    }
    //TODO : İlerleyen zamanda 2 yada 1 kullanılabilir büyü ekleyebiliriz 
    //          zorluk seviyesine göre büyüler işini düünebiliriz
}
