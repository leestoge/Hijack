﻿using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState // for keeping track of the current state
    {
        SPAWNING,
        WAITING,
        COUNTING
    };

    [System.Serializable]
    public class Wave
    {
        public string name; // name of the wave if we want to announce it, etc.
        public Transform enemy;  // reference to the prefab enemy (final with all components etc)
        public int count;
        public float rate; // spawn rate
    }

    public Wave[] waves;
    private int nextWave; // index of next wave


    public Transform[] spawnPoints;

    public float timeBetweenWaves = 5f; // spawn time between waves (in seconds)
    private float waveCountdown;

    private float searchCountdown = 1f;

    public Text HUD_Wave_element; // variable to link to the ui element
    public Text HUD_Enemy_element;

    private SpawnState state = SpawnState.COUNTING;

	// Use this for initialization
	void Start ()
	{
	    if (spawnPoints.Length == 0)
	    {
	        Debug.Log("ERROR: No spawn points referenced.");
	    }

        waveCountdown = timeBetweenWaves;

	    HUD_Wave_element.text = "Wave:" + nextWave;
    }
	
	// Update is called once per frame
	void Update ()
	{
	    if (state == SpawnState.WAITING)
	    {
            // check if player has killed all of the enemies.
	        if (!EnemyIsAlive())
	        {
                // begin a new wave
                WaveCompleted();
	        }
	        else
	        {
	            return; // if enemies still alive then let the player kill them off before doing anything else
	        }
	    }

	    if (waveCountdown <= 0) // if its time to start spawning waves
	    {
	        if (state != SpawnState.SPAWNING) // if we're not spawning
	        {
                // start spawning wave
	            StartCoroutine(SpawnWave(waves[nextWave]));

	        }
	    }
	    else // if its not time to start spawning
	    {
	        waveCountdown -= Time.deltaTime; // go down the appropriate amount of time for each frame
	    }

	    HUD_Wave_element.text = "Wave:" + nextWave;
    }

    void WaveCompleted()
    {
        Debug.Log("Wave completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1) // if next wave we try to spawn is > number of waves that we have
        {
            nextWave = 0;
            Debug.Log("Finished waves. Looping...");
        }
        else
        {
            nextWave++; // increment up the array (and therefore change wave)
        }      
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator SpawnWave(Wave _wave) // so we can wait an amount of seconds inside the method before continuing
    {
        Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        // Spawn
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f/_wave.rate);
        }

        state = SpawnState.WAITING;

        HUD_Enemy_element.text = _wave.count.ToString();
        yield break; // return nothing as IEnumerator MUST return something.  
    }

    void SpawnEnemy(Transform _enemy)
    {
        // Spawn enemy
        Debug.Log("Spawning enemy: " + _enemy.name);

        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)]; // randomly generate a spawnpoint between 0 and the length of spawn points
        Instantiate(_enemy, _sp.position, _sp.rotation);     
    }
}
