using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{
    [SerializeField] int maxHearts = 3;
    public int currentHearts = 3;

    void Awake()
    {
        currentHearts = maxHearts;
    }

    void Update()
    {

    }

    public void DamageSelf()
    {
        --currentHearts;

        if (currentHearts == 0)
            ; // Game Over?
    }

    public void ToggleGrayscale()
    {

    }
}
