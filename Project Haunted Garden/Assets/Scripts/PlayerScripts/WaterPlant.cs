using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPlant : MonoBehaviour
{
    public bool UsedWater;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            UsedWater = true;
        }
        UsedWater = false;
    }
}
