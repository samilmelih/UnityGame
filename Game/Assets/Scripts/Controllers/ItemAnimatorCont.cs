﻿using System.Collections.Generic;
using UnityEngine;

public class ItemAnimatorCont : MonoBehaviour
{
    #region Singelton
    public static ItemAnimatorCont Instance;
    #endregion

	// 0 = idle, 1 = vertical, 2 = horizontal
	string openParam = "open";
	string verticalAnimationParam = "vertical";

    [SerializeField]
	Animator itemSelectAnimator;

	public List<Animator> itemAnimators;
	public List<Animator> weaponAnimators;

    // Use this for initialization
    void Start()
    {
        #region Sing.
        Instance = this;
        if (Instance == null)	// FIXME: Will this condition be true ever? 
            Instance = new ItemAnimatorCont();
        #endregion

		PlayItemAnimations(false, true);
    }

	public void PlayItemAnimations(bool openItems, bool vertical)
	{
		foreach(Animator animator in itemAnimators)
		{
			animator.SetBool(verticalAnimationParam, vertical);
			animator.SetBool(openParam, openItems);
		}
	}

	public void PlayWeaponAnimations(bool openWeapons, bool vertical)
	{
		foreach(Animator animator in weaponAnimators)
		{
			animator.SetBool(openParam, openWeapons);
		}
	}
}