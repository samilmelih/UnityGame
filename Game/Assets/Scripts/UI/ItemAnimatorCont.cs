using System.Collections.Generic;
using UnityEngine;

public class ItemAnimatorCont : MonoBehaviour
{
    #region Singelton
    public static ItemAnimatorCont Instance;
    #endregion

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
        if (Instance == null)
			Instance = this;
        #endregion

		// Before animations start, we should decide orientation.
		// If we don't, it chooses horizontal because "vertical"
		// parameter is set false as default.
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
