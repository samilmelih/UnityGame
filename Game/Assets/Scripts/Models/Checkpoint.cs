using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint
{
	public Checkpoint prev;
	public Checkpoint next;

	public float x;
	public bool locked;

	public Checkpoint(float x)
	{
		this.x = x;
	}
}
