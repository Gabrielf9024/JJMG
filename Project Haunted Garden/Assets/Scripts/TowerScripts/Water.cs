using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public Slider waterSlider;
    private LevelManager lm;

    public int maxWater;
    public int waterAmount;
    public int waterLossPerSecond;
    public bool betweenWaves = true;
    public bool dry = false;

    private void Awake()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waterAmount = maxWater;
        waterSlider.maxValue = maxWater;
        StartCoroutine(LoseWater());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator LoseWater()
    {
        while(true)
        {
            if (waterAmount < 0)
                waterAmount = 0;

            if ( waterAmount > 0)
            {
                while (betweenWaves)
                {
                    yield return null;
                    betweenWaves = lm.readyForNextLevel;
                }

                yield return new WaitForSecondsRealtime(1);
                waterAmount -= waterLossPerSecond;
                UpdateSlider();           
            }
            else
            {
                OutOfWater();
                break;
            }
        }
    }

    private void UpdateSlider()
    {
        waterSlider.value = waterAmount;
    }

    private void OutOfWater()
    {        
        GetComponent<Animator>().enabled = false;
        dry = true;
    }
}
