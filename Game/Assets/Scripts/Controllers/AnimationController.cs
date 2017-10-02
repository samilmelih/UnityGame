using UnityEngine;
using UnityEngine.UI;

public class AnimationController : MonoBehaviour
{
    string animationParameter = "open";

    [SerializeField]
    Animator item1Animator;
    [SerializeField]
    Animator item2Animator;
    [SerializeField]
    Animator item3Animator;
    [SerializeField]
    Animator item4Animator;
    [SerializeField]
    Animator ArrowAnimator;

    [SerializeField]
    Button btnUpDownArrow;

    [SerializeField]
    Button btnItem1;

    [SerializeField]
    Button btnItem2;

    [SerializeField]
    Button btnItem3;

    [SerializeField]
    Button btnItem4;

    [SerializeField]
    Button btnItem5;

    [SerializeField]
    Button btnDefaultItem;

    [SerializeField]
    GameObject DefaultItemPıckerGO;




    // Use this for initialization
    void Start()
    {
        btnUpDownArrow.onClick.AddListener(delegate
        {
            btnUpDownArrow_Clik();
        });

        int i = 1;

        btnItem1.onClick.AddListener(delegate
        {
            onGunSelection(i++);
        });

        btnItem2.onClick.AddListener(delegate
        {
            onGunSelection(i++);
        });

        btnItem3.onClick.AddListener(delegate
        {
            onGunSelection(i++);
        });

        btnItem4.onClick.AddListener(delegate
        {
            onGunSelection(i++);
        });

        btnItem5.onClick.AddListener(delegate
        {
            onGunSelection(i++);
        });

        btnDefaultItem.onClick.AddListener(delegate
        {
            OnDefaultItem_Click();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    //the Menu state
    bool openClose = false;
    /// <summary>
    /// handels click event of arrow Button
    /// </summary>
    /// <param name="openCloseParam">if this is not triggerd by button then I called this as method I want to do things </param>
    /// <param name="fromButton">this is a control if we triggered by button or nah</param>
    public void btnUpDownArrow_Clik(bool openCloseParam = false, bool fromButton = true)
    {

        if (openClose == true)
        {
            DefaultItemPıckerGO.SetActive(openClose);
        }
        else
        {
            DefaultItemPıckerGO.SetActive(openClose);
        }

        if (fromButton == false)
        {
            openClose = openCloseParam;
        }
        else
        {
            openClose = !openClose;
        }

        item1Animator.SetBool(animationParameter, openClose);
        item2Animator.SetBool(animationParameter, openClose);
        item3Animator.SetBool(animationParameter, openClose);
        item4Animator.SetBool(animationParameter, openClose);
        ArrowAnimator.SetBool(animationParameter, openClose);

    }

    public void onGunSelection(int index)//TODO: find an useful parameter to detect what I've choosed
    {
        //Close Anims
        btnUpDownArrow_Clik(false, false);

        //Pick the Gun

        //show on The default Item 

    }

    public void OnDefaultItem_Click()
    {
        //use this item...
    }

}
