using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item  {


    public string name;

    public int cost;

    public bool isStackable;

    public virtual Item Clone()
    {
        return null;
    }


}
