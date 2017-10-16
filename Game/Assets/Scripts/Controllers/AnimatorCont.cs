using System.Collections.Generic;
using UnityEngine;

public class AnimatorCont : MonoBehaviour
{
    #region Singelton
    public static AnimatorCont Instance;
    #endregion

	string openWeaponsParam = "open_weapons";
	string openItemsParam = "open_items";
	//string upDownAnimationParam = "upDown";

    public bool upDownAnimate = true;

    [SerializeField]
	Animator itemSelectAnimator;


    // Use this for initialization
    void Start()
    {
        #region Sing.
        Instance = this;
        if (Instance == null)
            Instance = new AnimatorCont();
        #endregion


//        for (int i = 0; i < animatorList.Count; i++)
//        {
//            animatorList[i].SetBool(upDownAnimationParam, upDownAnimate);
//        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAnimations(bool menuOpen)
    {
//        for (int i = 0; i < animatorList.Count; i++)
//        {
//            animatorList[i].SetBool(upDownAnimationParam, upDownAnimate);
//            animatorList[i].SetBool(animationParam, menuOpen);
//
//        }
    }




}
