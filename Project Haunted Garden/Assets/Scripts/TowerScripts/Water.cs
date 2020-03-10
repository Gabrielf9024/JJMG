using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Water : MonoBehaviour
{
    public Slider waterSlider;
    private LevelManager lm;

    public float maxWater;
    public float waterAmount;
    public float waterLossPerSecond;
    public bool betweenWaves = true;
    public bool dry = false;
    public bool coroRunning = false;

    private void Awake()
    {
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        waterAmount = maxWater;
        waterSlider.maxValue = maxWater;
    }

    // Update is called once per frame
    void Update()
    {
        if (betweenWaves != lm.readyForNextLevel)
            ReadyForLoss();
        if (!coroRunning && !betweenWaves)
            ReadyForLoss();
    }

    IEnumerator LoseWater()
    {
        while(true)
        {
            betweenWaves = lm.readyForNextLevel;

            if (waterAmount > maxWater)
                waterAmount = maxWater;

            if( waterAmount > 0 )
            {
                waterAmount -= waterLossPerSecond;
                UpdateSlider();
                yield return new WaitForSecondsRealtime(1);
            }

            if (waterAmount <= 0)
            {
                waterAmount = 0;
                OutOfWater();
                break;
            }
        }
    }

    private void ReadyForLoss()
    {
        coroRunning = true;
        StartCoroutine(LoseWater());
    }

    private void UpdateSlider()
    {
        waterSlider.value = waterAmount;
    }

    private void OutOfWater()
    {        
        dry = true;
        coroRunning = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WaterProjectile"))
        {
            waterAmount += collision.gameObject.GetComponent<BulletLogic>().waterValue;
            UpdateSlider();
            dry = false;
        }
    }
}
