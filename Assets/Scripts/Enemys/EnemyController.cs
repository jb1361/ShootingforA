using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
	public int health;
	public int damage;
	public float attackSpeed;
	public bool canattack { get; set; }
	float attacktimer;
	public GameObject player { get; set; }
	NavMeshAgent agent;
	public Animator anim;
	public float attackRange = 2;
	public playerController playerc { get; set; }
	public StageController StageControlla { get; set; }
    public decalLimiter decal { get; set; }
	GameObject bloodFX;
	public GameObject ragdoll;
    public GameObject[] drops;
    public int armorDropRate;
    public int speedboostDropRate;
    public int grenadeDropRate;
    public int nukeDropRate;
	// Use this for initialization
	void Start ()
	{
		if(health == 0) health = 100;
		anim.speed = 2.5f;
		canattack = false;
		try {
			
			StageControlla = GameObject.FindGameObjectWithTag ("StageController").GetComponent<StageController>();
			player = GameObject.FindGameObjectWithTag ("Player");
            decal = GameObject.FindGameObjectWithTag("StageController").GetComponent<decalLimiter>();
			playerc = player.GetComponent<playerController> ();
			bloodFX = (GameObject)Resources.Load ("BloodFX");
		} catch (Exception e) {

            //need to change this later it's not even relevant
			Debug.LogError ("Enemy Controller Unable to find the player tag.  " + e);
		}

		agent = GetComponent<NavMeshAgent> ();
	}

	
	void Update ()
	{
		//get the distance from the enmy to the player. if it's within the attack range then update animations and attack.
		float dist = Vector3.Distance (player.transform.position, this.transform.position);
		if (dist <= attackRange) {
			agent.destination = this.transform.position;
			anim.speed = 2.0f;
			anim.SetBool ("inRange", true);
			if (canattack)
				sendDamage (damage);
		} else {
			anim.speed = 2.5f;
			anim.SetBool ("inRange", false);
			agent.destination = player.transform.position;
		}

		//always look at the player
		agent.transform.LookAt (player.transform.position);

		//kill the enemy
		if (health <= 0) {
            death();
            DestroyEnemy();
        }


		//waits for the enemys attack animation to play before hitting the player
		if (!canattack && dist <= attackRange) {
			attacktimer -= 1 * Time.deltaTime;
			if (attacktimer <= 0) {
				attacktimer = attackSpeed;
				canattack = true;
			}
		} else if (dist > attackRange)
			attacktimer = attackSpeed;
	}

    public void death()
    {
        StageControlla.AddScore(124);
        spawnRagdoll();
        spawnBloodFX();
        dropPowerUp();
        StageControlla.Kills();
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

    /// armor = 0
    /// speedboost = 1
    /// grenade =2
    /// nuke = 3
    //provide a random powerupdrop when the enemy is killed
    public void dropPowerUp()
    {
        int rarity = Random(100);
        if(rarity <= 30)
        {
            if (Random(armorDropRate) == armorDropRate - 1) drop(0);
        }else if(rarity > 30 && rarity <= 60)
        {
            if (Random(speedboostDropRate) == speedboostDropRate - 1) drop(1);
        }
        else if(rarity > 60 && rarity <= 90)
        {
            if (Random(grenadeDropRate) == grenadeDropRate - 1) drop(2);
        }
        else if(rarity > 90)
        {
            if (Random(nukeDropRate) == nukeDropRate - 1) drop(3);
        }
       
      
    }

    private void drop(int i)
    {
        //move the position of the drop up 1 unit out of the ground
        Vector3 pos = this.transform.position;
        pos.y += 1;
        Instantiate(drops[i], pos, Quaternion.identity);
    }

    public int Random(int max)
    {
        int rand = UnityEngine.Random.Range(0, max);
        return rand;
    }
  

    //tell the player to take damage
    public void sendDamage (int i)
	{
		playerc.takeDamage (i);
		canattack = false;
	}

	//get if the enemy is shot by our player
	private void OnCollisionEnter (Collision collision)
	{
		if (collision.transform.tag == "Bullet") {
            takeDamage(100);
			Destroy (collision.gameObject);
           
		}
        
       
        
	}

    public void takeDamage(int i)
    {
        health -= i;
    }

	public void spawnBloodFX ()
	{
		// Vector3 rot = this.gameObject.transform.position;
		// Quaternion dir = new Quaternion(0, rot.y, 0, 0);
		// Instantiate(bloodFX, this.gameObject.transform.position,dir);

		//  blood = (Texture2D)Resources.Load("blood");
		// GameObject bloodfx = new GameObject.(blood);
	}

	public void spawnRagdoll ()
	{
		GameObject ragdollO = (GameObject)Instantiate (ragdoll, this.transform.position, Quaternion.Euler (0, this.gameObject.transform.eulerAngles.y, 0));
        decal.addRagDoll(ragdollO);
	}
}
