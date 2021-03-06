﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nuke : MonoBehaviour {

    public GameObject[] enemies;
    // Use this for initialization
    public GameObject[] ragdolls;
    bool exploded = false;
    public Rigidbody[] rb;
    float wait = 1.0f;
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            if (Vector3.Distance(enemies[i].transform.position, this.transform.position) < 150.0f)
            {
                enemies[i].GetComponent<EnemyController>().takeDamage(100000);
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        if (exploded)
        {
            wait -= 1 * Time.deltaTime;
            if (wait <= 0) Destroy(this.gameObject);
        }

    }//update
}
