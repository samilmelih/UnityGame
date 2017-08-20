using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
	None,
	Left,
	Right
}

public enum EnemyImpact
{
    None,
    Player,
    Wall,
    Enemy
}

public enum WeaponType : byte
{
	Gun=1,
	Rifle=2,
	Close=0
}