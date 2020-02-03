using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public float THealth;
    void Update()
    {
        if (THealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
