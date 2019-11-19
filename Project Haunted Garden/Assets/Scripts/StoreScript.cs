using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : ScriptableObject
{
    public string ItemName;
    public Sprite ItemImage;
    public GameObject ItemObject;

    public virtual void Use(){
    }

}
