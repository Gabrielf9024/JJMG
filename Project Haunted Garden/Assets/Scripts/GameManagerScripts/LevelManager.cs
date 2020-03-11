using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject[] towers;
    public bool readyForNextLevel = true; // For debugging
    public int levelIndex = 0;

    public List<GameObject> Levels = null;

    void Awake()
    {
        Levels = new List<GameObject>(GameObject.FindGameObjectsWithTag("Spawner"));
        Levels = Levels.OrderBy(e => e.GetComponent<Spawn>().ordinal).ToList();
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth.deathEvent += OnEnemyDeath;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        towers = GameObject.FindGameObjectsWithTag("Tower");
    }

    // Update is called once per frame
    void Update()
    {
        readyForNextLevel = CheckIfLevelDone();

        if(readyForNextLevel)
        {
            if (levelIndex == Levels.Count)
                GameObject.Find("GameManager").GetComponent<GameManager>().WonGame();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartNextLevel();
            }
            foreach( GameObject tower in towers)
            {
                if( tower.GetComponent<Water>() != null)
                    tower.GetComponent<Water>().betweenWaves = true;
            }

        }
    }

    void OnEnemyDeath( bool alive )
    {
        readyForNextLevel = CheckIfLevelDone();
    }

    public bool CheckIfLevelDone()
    {
        // Return true if the game just started
        if (levelIndex == 0)
            return true;


        enemies = null;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        towers = GameObject.FindGameObjectsWithTag("Tower");


        if (enemies.Length == 0)
        {
            if (Levels[levelIndex-1].GetComponent<Spawn>().doneSpawning)
            {
                return true;
            }
        }
        return false;

    }

    public void StartNextLevel()
    {
        Levels[levelIndex++].GetComponent<Spawn>().enabled = true;
    }
}
