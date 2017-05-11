using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
   public float velocity;
    GameObject bullet;
    Rigidbody rb;
    float flyTime;
	// Use this for initialization
	void Start () {
        //stops the bullet from clipping our player
        Physics.IgnoreCollision(GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>(),this.GetComponent<Collider>());
        flyTime = 5;
        bullet = this.gameObject;
        rb = bullet.GetComponent<Rigidbody>();
        //adds an initial force to our bullet, propels it in its up vector
        rb.AddForce(bullet.transform.up * velocity, ForceMode.Impulse);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Enviroment") Destroy(this.gameObject);
        if (collision.transform.tag == "ragdoll") Destroy(this.gameObject);
    }

    void Update () {
        //This destroys our bullet after some time.
        if (flyTime < 0) Destroy(this.gameObject);
        flyTime -= 1 * Time.deltaTime;
        
	}
    
}
