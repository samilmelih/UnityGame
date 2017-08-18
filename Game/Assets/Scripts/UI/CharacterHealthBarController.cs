using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class CharacterHealthBarController : MonoBehaviour
{
    public Text health;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        RectTransform rt = GetComponent<RectTransform>();

        rt.sizeDelta = new Vector2(WorldController.Instance.world.character.health * 2, 30f);
        health.text = "%" + WorldController.Instance.world.character.health;

	}
}
