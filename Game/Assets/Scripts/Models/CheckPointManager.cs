using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointManager
{
	public Checkpoint leftCheckpoint;
	public Checkpoint rightCheckpoint;

	// Don't forget me to unregister FIXME
	Action<Checkpoint, Direction> cbLockCameraToCheckpoint;

	Character character;

	public CheckpointManager(Character character)
	{
		this.character = character;
	}

	// If remaining distance of the camera to checkpoint is equal or less then character's
	// position change, then lock camera to checkpoint. In other words, if camera
	// close enough to checkpoint, then lock camera to the checkpoint.
	public void Check()
	{
		float positionChangeOfCharacter = UnityEngine.Mathf.Abs(character.lastPosition.x - character.currPosition.x);
		float distToCheckpoint;

		Checkpoint checkpointToBeLock;

		if(character.direction == Direction.Left)
		{
			distToCheckpoint = UnityEngine.Mathf.Abs(CameraController.GetLeftEdgePosition().x - leftCheckpoint.x);
			checkpointToBeLock = leftCheckpoint;
		}
		else
		{
			distToCheckpoint = UnityEngine.Mathf.Abs(CameraController.GetRightEdgePosition().x - rightCheckpoint.x);
			checkpointToBeLock = rightCheckpoint;
		}

		if(distToCheckpoint <= positionChangeOfCharacter)
		{
			if(cbLockCameraToCheckpoint != null)
				cbLockCameraToCheckpoint(checkpointToBeLock, character.direction);
		}
	}

	public void RegisterLockCameraToCheckpointCallback(Action<Checkpoint, Direction> cb)
	{
		cbLockCameraToCheckpoint += cb;
	}

	public void UnregisterLockCameraToCheckpointCallback(Action<Checkpoint, Direction> cb)
	{
		cbLockCameraToCheckpoint -= cb;
	}
}
