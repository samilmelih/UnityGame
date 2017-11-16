using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CheckpointManager
{
	public Checkpoint leftCheckpoint;
	public Checkpoint rightCheckpoint;
	public Checkpoint lockedCheckpoint;

	// Don't forget me to unregister FIXME
	Action<Checkpoint, Direction> cbLockCameraToCheckpoint;
	Action<Direction> cbUnlockCameraFromCheckpoint;

	Character character;

	public CheckpointManager(Character character)
	{
		this.character = character;
	}


	public void Check()
	{
		float positionChangeOfCharacter = UnityEngine.Mathf.Abs(character.lastPosition.x - character.currPosition.x);

		if(lockedCheckpoint == null)
			lockCameraIfNeeded(positionChangeOfCharacter);
		else
			unlockCameraIfNeeded(positionChangeOfCharacter);
	}

	// If remaining distance of the camera to checkpoint is equal or less then character's
	// position change, then lock camera to checkpoint. In other words, if camera
	// close enough to checkpoint, then lock camera to the checkpoint.
	void lockCameraIfNeeded(float positionChangeOfCharacter)
	{
		float distToCheckpoint;

		if(character.direction == Direction.Left)
		{
			distToCheckpoint = UnityEngine.Mathf.Abs(CameraController.GetLeftEdgePosition().x - leftCheckpoint.x);
			lockedCheckpoint = leftCheckpoint;
		}
		else
		{
			distToCheckpoint = UnityEngine.Mathf.Abs(CameraController.GetRightEdgePosition().x - rightCheckpoint.x);
			lockedCheckpoint = rightCheckpoint;
		}

		if(distToCheckpoint <= positionChangeOfCharacter)
		{
			// Lock camera
			if(cbLockCameraToCheckpoint != null)
				cbLockCameraToCheckpoint(lockedCheckpoint, character.direction);
		}
	}

	void unlockCameraIfNeeded(float positionChangeOfCharacter)
	{
		float distToCenterOfCamera = UnityEngine.Mathf.Abs(character.currPosition.x - CameraController.GetCameraPosition().x);

		if (distToCenterOfCamera <= positionChangeOfCharacter)
		{
			if (cbUnlockCameraFromCheckpoint != null)
			{
				cbUnlockCameraFromCheckpoint(character.direction);
				lockedCheckpoint = null;
			}
		}
		else if (character.IsCharacterAtEdge() == true)
		{
			character.velocity.x = 0f;
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

	public void RegisterUnlockCameraFromCheckpointCallback(Action<Direction> cb)
	{
		cbUnlockCameraFromCheckpoint += cb;
	}

	public void UnregisterUnlockCameraFromCheckpointCallback(Action<Direction> cb)
	{
		cbUnlockCameraFromCheckpoint -= cb;
	}
}
