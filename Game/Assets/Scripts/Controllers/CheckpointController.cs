using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
	public Transform[] checkpoints;

	CheckpointManager cpm;

	// Use this for initialization
	void Start ()
	{
		cpm = WorldController.Instance.world.checkpointManager;

		cpm.leftCheckpoint = new Checkpoint(checkpoints[0].position.x);
		Checkpoint curr = cpm.leftCheckpoint;

		for(int i = 1; i < checkpoints.Length; i++)
		{
			curr.next = new Checkpoint(checkpoints[i].position.x);
			curr = curr.next;
		}

		cpm.rightCheckpoint = cpm.leftCheckpoint.next;
	}
}
