using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;

public class StageController : MonoBehaviour
{
	public int stage = 1;
	public int kills = 0;
	public int score = 0;
	public int enemysToSpawn = 1;
	public int enemysSpawned;
	public GameObject[] spawnzones;
	public int maxEnemys = 50;
	public int enemysOnField = 0;
	public bool canSpawn = true;
	public GameObject Enemy;
	float spawnDelay = 0.5f;
	float delayOrigional = 0.5f;
	bool spawnedEnemy;
    decalLimiter decal;
    int maxEnemysModifier;
   public int enemyHealthModifier;
    float enemySpeedModifier;
	void Start ()
	{
        decal = this.gameObject.GetComponent<decalLimiter>();
	}

	void Update ()
	{
		if (spawnedEnemy)
			timer ();
        



		//this needs to be changed to a method that is called when the player kills an enemy because this will cause lag at later stages.
		enemysOnField = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (canSpawn == false) {
			if (enemysOnField == 0)
				canSpawn = true;
		}

		if (enemysSpawned == enemysToSpawn && enemysOnField == 0) {
			nextStage ();
		} else if (canSpawn == true && enemysOnField == 0) {
			spawnEnemys ();
		}
	}

	public void spawnEnemys ()
	{

		int length = enemysToSpawn - enemysSpawned;
		for (int i = 0; i < length; i++) {
			if (enemysOnField < maxEnemys) {
                
				int rand = UnityEngine.Random.Range (0, spawnzones.Length);
				//   Debug.Log(rand);
                GameObject newEnemy = Instantiate (Enemy, spawnzones [rand].transform.position, Quaternion.identity);
                newEnemy.GetComponent<NavMeshAgent>().speed += enemySpeedModifier;
                newEnemy.GetComponent<EnemyController>().takeDamage(-enemyHealthModifier);
				enemysOnField++;
				enemysSpawned++;
                
			} else
				canSpawn = false;
		}



	}


	public void timer ()
	{
		spawnDelay -= 1 * Time.deltaTime;
		if (spawnDelay < 0) {
			spawnedEnemy = false;
			spawnDelay = delayOrigional;

		}

	}
	public void Kills(){
		kills++;
	}


	public void nextStage ()
	{
		stage++;
		AddScore (1000);
		enemysToSpawn = enemysToSpawn + (int)Math.Round ((2.5 * stage) / 1.5);
		enemysSpawned = 0;
		canSpawn = true;
        decal.clearRagDolls();
        modifyDifficulty();
		spawnEnemys ();
	}

	public void AddScore(int i){
		score += i;
	}

    private void modifyDifficulty()
    {
        switch (stage)
        {
          //  case 5:
          //      maxEnemys += 10;
         //   break;
            case 10:
                maxEnemys += 10;
                break;
           // case 15:
           //     maxEnemys += 10;
          //      break;
            case 20:
                maxEnemys += 10;
                break;
        }
        if(stage <= 29) enemySpeedModifier += 0.1f;
        enemyHealthModifier += 20;

    }


}