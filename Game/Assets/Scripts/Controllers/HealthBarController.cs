using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour {


    //FIXME şuan nasıl yapılır kesin bir bilgim olmadığı için bu şekilde yapıyorum sonra düzelt

    public GameObject character;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform rt = GetComponent<RectTransform>();

        rt.sizeDelta=new Vector2(EnemyController.Instance.GOenemyMap[character].health / 100,.1f);
	}
}
