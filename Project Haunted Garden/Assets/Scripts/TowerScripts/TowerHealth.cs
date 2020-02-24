using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    public float THealth;
    public int TowerType;
    private bool activate = true;
    [TextArea]
    [Tooltip("Doesn't do anything. Just comments shown in inspector")]
    public string Notes = "Seeker: 1; Spread: 2; Eater: 3;";

    void Update()
    {
        if (THealth <= 0)
        {
            HandleDry();
            activate = false;
        }

        else
        {
            switch (TowerType)
            {
                case 1:
                    GetComponent<SeekTowerLogic>().enabled = true;
                    break;
                case 2:
                    GetComponent<TowerShoot>().enabled = true;
                    break;
                case 3:
                    GetComponent<TowerBugEater>().enabled = true;
                    break;
                default:
                    break;
            }
        }
    }
    public void HandleDry()
    {
        switch (TowerType)
        {
            case 1:
                GetComponent<SeekTowerLogic>().enabled = false;
                break;
            case 2:
                GetComponent<TowerShoot>().enabled = false;
                break;
            case 3:
                GetComponent<TowerBugEater>().enabled = false;
                break;
            default:
                break;
        }
    }
}
