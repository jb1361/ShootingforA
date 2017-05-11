using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class playerController : MonoBehaviour {

  

    public GameObject player;
    PowerUp powerup;
    public int health;
    public int moveSpeed;
    public int lives;
    // Vector3 pdist;
    //Vector3 ndist;
    fireWeapon fireW;

    //these are here so that we can update position inside of fixedUpdate function and the booleans stop our code from running every frame
    bool moving = false;
    bool turning = false;
    Vector3 newDir;
    Vector3 newPos;


    // Use this for initialization
    void Start () {
        moveSpeed = 10;     
        player = this.gameObject;
        fireW = GetComponent<fireWeapon>();
        powerup = GetComponent<PowerUp>();
      //  pdist = player.transform.position;
    }

    //this updates our players position
    public void updatePosition(float x, float z) {  newPos = new Vector3(x, 0, z).normalized; moving = true; }
    //this takes input from a joystick or arrow keys and put them into a forward vector.
    public void updateDirection(float x, float z) {  newDir = new Vector3(x, 0, z).normalized; turning = true; }
    //these are called when our input controller is not receiving input
    public void notUpdatingPosition() { moving = false; }
    public void notUpdatingDirection() { turning = false; }
  


    public void fire()
    {
        fireW.fire();
    }

    private void FixedUpdate()
    {
        if (moving)  player.transform.position = new Vector3(player.transform.position.x + newPos.x * moveSpeed * Time.deltaTime, player.transform.position.y, player.transform.position.z + newPos.z * moveSpeed * Time.deltaTime);       
        if (turning) player.transform.forward = newDir;       
    }
    // Update is called once per frame
    void Update () {
      

        //  these gets our players velocity (not to an acutal unit)
        //   ndist = player.transform.position;
        // float velocity = Vector3.Distance(pdist, ndist);
        //  Debug.Log(velocity);
        // pdist = player.transform.position;
       
    }
    //you use this method whenever you need to damage these enemies
    public void takeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            death();
        }
    }

    private void death()
    {
		if (this.GetComponent<DeathAnimation> () == null) {
			this.GetComponent<playerInputController> ().enabled = false;
			this.gameObject.AddComponent<DeathAnimation> ();
			this.enabled = false;
		}

    }

  
    //adds a powerup based on the given i
    public void NewPowerup(int i)
    {
        powerup.AddPowerUp(i);
    }
    //uses powerup based on given i
    public void UsePowerUp(int i)
    {
        powerup.UsePowerup(i);
    }






    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Armor")
        {
            NewPowerup(0);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "SpeedBoost")
        {
            NewPowerup(1);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Grenade")
        {
            NewPowerup(2);
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Nuke")
        {
            NewPowerup(3);
            Destroy(other.gameObject);
        }

    }



}

