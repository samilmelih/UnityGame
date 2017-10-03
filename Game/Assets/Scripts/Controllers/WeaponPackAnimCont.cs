using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPackAnimCont : MonoBehaviour
{
    string animationParameter = "open";

    [SerializeField]
    List<Animator> animatorList;

    [SerializeField]
    Button btnUpDownArrow;

    [SerializeField]
    Button btnDefaultItem;

    [SerializeField]
    List<Button> itemButtonList;

    [SerializeField]
    GameObject DefaultItemPıckerGO;




    // Use this for initialization
    void Start()
    {
        btnUpDownArrow.onClick.AddListener(delegate
        {
            btnUpDownArrow_Clik();
        });



        for (int i = 0; i < itemButtonList.Count; i++)
        {
            itemButtonList[i].onClick.AddListener(delegate
        {
            onGunSelection(i + 1);
        });

        }



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

        for (int i = 0; i < animatorList.Count; i++)
        {
            animatorList[i].SetBool(animationParameter, openClose);

        }


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
