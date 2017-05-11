using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// armor = 0
/// speedboost = 1
/// grenade =2
/// nuke = 3
/// </summary>
public class PowerUp : MonoBehaviour
{
	int armor;
	int speedboost;
	int grenade;
	int nuke;
	public int[] powerup;
	public GameObject grenadePrefab;
	public GameObject nukePrefab;
	public playerController player { get; set; }
	public bool haveArmor;
	float armorTimer;
	bool speedBoost;
	float speedTimer;
	public AudioSource bomb;
	public AudioSource SpeedBoostAudio;
	public void Start ()
	{
        
		player = GetComponent<playerController> ();
		powerup = new int[4];
		haveArmor = false;
		speedBoost = false;
      
	}

	//adds a new powerup based on the given id
	public void AddPowerUp (int i)
	{
		switch (i) {
		case 0:
			armor++;
			break;
		case 1:
			speedboost++;
			break;
		case 2:
			grenade++;
			break;
		case 3:
			nuke++;
			break;
		default:
			Debug.Log ("This is an invalid powerup id or the case has not been implemented");
			break;
		}
		//update array values
		updateArray ();
	}

	//check if we have the powerup then apply the powerup
	public void UsePowerup (int i)
	{
		switch (i) {
		case 0:              
                //only use armor powerup if we are at base health
			if (HavePowerup (i) && player.health <= 100) {
				armor--;
				AddArmor ();
			}
			break;
		case 1:
			if (HavePowerup (i) && player.moveSpeed < 30 && !speedBoost) {
				speedboost--;
				SpeedBoost ();
			}
			break;
		case 2:
			if (HavePowerup (i)) {
				grenade--;
				Grenade ();
			}
			break;
		case 3:
			if (HavePowerup (i)) {
				nuke--;
				Nuke ();
			}
			break;
		default:
			Debug.Log ("This is an invalid powerup id or the case has not been implemented");
			break;
		}
		//update array values
		updateArray ();
	}


	//updates the array values
	void updateArray ()
	{
		powerup [0] = armor;
		powerup [1] = speedboost;
		powerup [2] = grenade;
		powerup [3] = nuke;
	}


	//check to see if we have the powerup we are wanting to use
	public bool HavePowerup (int i)
	{
		if (powerup [i] > 0)
			return true;
		else
			return false;
	}
	//the playergui uses this to display how much of each powerup we have
	public int getPowerUpAmmount (int i)
	{
		return powerup [i];
	}


	//methods for powerup effects

	//really just adds more health but we like to call it armor
	public void AddArmor ()
	{
		armorTimer = 10.0f;
		haveArmor = true;
		player.health += 200;
	}
	//uses a speedboost that plows through enemies
	public void SpeedBoost ()
	{     
		speedTimer = 1.0f;
		speedBoost = true;      
		player.moveSpeed = 30;
		SpeedBoostAudio.Play ();
	}
	//drops a grenade near the player and kills zombies in a small radius
	public void Grenade ()
	{
		try {
			Vector3 spawnPos = player.transform.position;
			Instantiate (grenadePrefab, spawnPos, Quaternion.identity);
			bomb.Play();
		} catch (Exception e) {
			Debug.Log ("Grenade Prefab not set or missing!" + e);
		}
	}
	//kills all enemies currently on the map (may exclude bosses/deals damage to enemies rather than killing them)
	public void Nuke ()
	{
		try { 
			Vector3 spawnPos = player.transform.position;
			Instantiate (nukePrefab, spawnPos, Quaternion.identity);
			bomb.Play();
		} catch (Exception e) {
			Debug.Log ("Nuke Prefab not set or missing!" + e);
		}
	}
	//this will handle timers for powerups
	public void Update ()
	{
		if (haveArmor) {
			if (player.health <= 100)
				haveArmor = false;
		}
		//timer for armor
		//   if (haveArmor)
		// {
		///  armorTimer -= 1 * Time.deltaTime;
		//   if(armorTimer <= 0.0f)
		//   {
		//      haveArmor = false;
		//      int temp = player.health;
		//     if (temp > 100) player.health = 100;
		//  }
		// }



		//timer for speedboost
		if (speedBoost) {
			speedTimer -= 1 * Time.deltaTime;
			if (speedTimer <= 0.0f) {
				speedBoost = false;
				player.moveSpeed = 10;
              
			}
		}

	}

	//Kill any enemy the player touches when they are using speedboost.
	private void OnCollisionEnter (Collision collision)
	{
		if (speedBoost) {
			if (collision.gameObject.tag == "Enemy") {
				collision.gameObject.GetComponent<EnemyController> ().takeDamage (5000);
			}
		}
	}
}
