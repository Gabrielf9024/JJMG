using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject EnemySprite;
	public int Max = 2;
	public int count = 0;
	public bool horde = false;
	public float mtime = 2;

    void Start()
    {

    }
    void Update()
    {
    	mtime -= Time.deltaTime;
    	float xAxis = Random.Range(-9.0f,9.0f);
    	if (mtime <= 0f){
    		EnemySpawner(xAxis);
    		mtime = 2f;
    	}
    }

    public void EnemySpawner(float Position_x){
    	 if (count < Max){
		    	Vector3 NewSpritePosition = new Vector3(4.5f,-5f);
		    	Instantiate(EnemySprite,NewSpritePosition,Quaternion.identity);
		    	count++;
	    }
    }
}
