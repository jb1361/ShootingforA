using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireWeapon : MonoBehaviour {
    public GameObject spawnLoc;
    public GameObject bullet;
    public float firerate;
    float timer;
    AudioSource audio;
  public  bool canFire { get; set; }
 
	// Use this for initialization
	void Start ()
    {
        audio = GetComponent<AudioSource>();
        canFire = true;
        timer = firerate;
	}
   

    public void fire()
    {
       

        if (canFire)
        {
            //These create and set up our projectile by getting its spawn location and its forward vector(up vector on the projectile itself)
            spawnLoc = GameObject.FindGameObjectWithTag("projectileSpawn");
            GameObject Projectile = Instantiate(bullet);
            Projectile.transform.position = spawnLoc.transform.position;
            Projectile.transform.up = spawnLoc.transform.forward;
            if(!audio.isPlaying) audio.Play();
            canFire = false;
        }

    }

   public void Update()
    {
       
        //this delays our fie rate so we cant fire every frame.
        if (!canFire)
        {
            if (timer < 0.1)
            {
                timer = firerate;
                canFire = true;
            }
            else timer -= 1 * Time.deltaTime;
        }
    }


    public void setFireRate(float i)
    {
        firerate = i;

    }
   public void setProjectile(GameObject p)
    {
        bullet = p;

    }


    
}
