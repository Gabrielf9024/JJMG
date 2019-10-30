using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
	public GameObject EnemySprite;
	public int Max;
	public int count;
	public bool horde;
	private float mtime;
    void Start(){
    	Max = 30;
    	count = 0;
    	mtime = 2;
    	horde = false;
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
    	 	int HordeNumber = Random.Range(2,7);
    	 	if (Random.Range(0f,1f) > 0.9 && horde){
    	 		for (int num = 0; num < HordeNumber; num++){    	 			
    	 			Vector3 NewSpritePosition = new Vector3(Position_x + Random.Range(-1f,1f),-4,0);
	    			Instantiate(EnemySprite,NewSpritePosition,Quaternion.identity);
	    			count++;
    	 		}
    	 	}
    	 	else{ 
		    	Vector3 NewSpritePosition = new Vector3(Position_x,-4,0);
		    	Instantiate(EnemySprite,NewSpritePosition,Quaternion.identity);
		    	count++;
	    	}
	    }
    }
}
