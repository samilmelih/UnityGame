using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	// ***FIXME***: These static methods are just a workaround. We can't register
	// these methods to character callbacks. (e.g. we call jump callback
	// in our character but we didn't know it'll jump or not. CharacterController
	// will check if it is able to jump or not.

	public static SoundController Instance;

	void Start()
	{
		Instance = this;
	}

	public void Shot()
	{
		AudioClip ac = Resources.Load<AudioClip>("Sounds/shot");
		GetComponent<AudioSource>().PlayOneShot(ac);
	}

	public void Jump()
	{
		AudioClip ac = Resources.Load<AudioClip>("Sounds/jump");
		GetComponent<AudioSource>().PlayOneShot(ac);
	}

	public void Hit()
	{
		AudioClip ac = Resources.Load<AudioClip>("Sounds/hit");
		GetComponent<AudioSource>().PlayOneShot(ac);
	}

	public void Ground_Hit()
	{
		AudioClip ac = Resources.Load<AudioClip>("Sounds/ground_hit");
		GetComponent<AudioSource>().PlayOneShot(ac);
	}
}
