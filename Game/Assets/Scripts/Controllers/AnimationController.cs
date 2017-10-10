using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    #region Singelton

    static public AnimationController Instance;

    #endregion

    string animationParameter = "open";
    string UpDwonanimationParameter = "upDown";

    public bool UpDwonAnimate = true;

    [SerializeField]
    List<Animator> animatorList;


    // Use this for initialization
    void Start()
    {
        #region Sing.
        Instance = this;
        if (Instance == null)
            Instance = new AnimationController();
        #endregion


        for (int i = 0; i < animatorList.Count; i++)
        {
            animatorList[i].SetBool(UpDwonanimationParameter, UpDwonAnimate);
        }
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void PlayAnimations(bool menuOpen)
    {
        for (int i = 0; i < animatorList.Count; i++)
        {
            animatorList[i].SetBool(UpDwonanimationParameter, UpDwonAnimate);
            animatorList[i].SetBool(animationParameter, menuOpen);

        }
    }




}
