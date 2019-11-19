using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Store Items", menuName = "Items/Towers")]
public class Items : StoreScript
{
    // Start is called before the first frame update
    public override void Use()
    {
        GameObject player = StoreGameManager.instance.player;
        player.GetComponent<HandLogic>().createObject(ItemObject);
    }
}
