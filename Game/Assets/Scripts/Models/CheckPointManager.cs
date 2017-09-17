using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointManager
{
	public Checkpoint left;
	public Checkpoint right;

	// Don't forget me to unregister FIXME
	Action<Direction> cbLockCameraToCheckpoint;

	public bool cameraLockedToCheckpoint = false;

	public void Check()
	{
		if(cameraLockedToCheckpoint == false && CameraController.GetLeftEdgePosition().x <= left.x)
		{
			if(cbLockCameraToCheckpoint != null)
				cbLockCameraToCheckpoint(Direction.Left);

			WorldController.Instance.world.character.cameraLockedToCharacter = false;
			cameraLockedToCheckpoint = true;
		}
		else if(cameraLockedToCheckpoint == false && CameraController.GetRightEdgePosition().x >= right.x)
		{
			if(cbLockCameraToCheckpoint != null)
				cbLockCameraToCheckpoint(Direction.Right);

			WorldController.Instance.world.character.cameraLockedToCharacter = false;
			cameraLockedToCheckpoint = true;
		}
	}

	public void RegisterLockCameraToCheckpointCallback(Action<Direction> cb)
	{
		cbLockCameraToCheckpoint += cb;
	}

	public void UnregisterLockCameraToCheckpointCallback(Action<Direction> cb)
	{
		cbLockCameraToCheckpoint -= cb;
	}
}
