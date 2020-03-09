using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splatter : MonoBehaviour
{

    public float timeAlive = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitThenDie(timeAlive));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToCorpse( Transform corpse)
    {
        transform.position = corpse.position;
    }
    IEnumerator WaitThenDie(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        Destroy(gameObject);
    }
}
