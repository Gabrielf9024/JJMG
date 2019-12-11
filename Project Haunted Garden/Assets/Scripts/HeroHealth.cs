using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroHealth : MonoBehaviour
{
    [SerializeField] int maxHearts = 3;
    public int currentHearts = 3;
    public float knockbackAmountWhenHit = 2.0f;
    public float stunTime = 1f;


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
    
    // ouch() doesn't hurt the player's health but hinders the player in some way
    // i.e. making them stunned for a while
    public void ouch( Vector2 d)
    {
        Debug.Log("ouch");
        GetComponentInChildren<GunLogic>().enabled = false;
        GetComponent<HeroMovement>().enabled = false;

        this.transform.Translate(-d * knockbackAmountWhenHit);
        StartCoroutine( Hurting() );
    }

    IEnumerator Hurting()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        yield return new WaitForSecondsRealtime( stunTime );
        GetComponent<HeroMovement>().enabled = true;
        GetComponentInChildren<GunLogic>().enabled = true;

    }

    public void ToggleGrayscale()
    {

    }
}
