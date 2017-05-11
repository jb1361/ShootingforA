using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this will be used for limity the ammount of decals on the map
/// decals include bullet holes and ragdolls currently
/// </summary>
public class decalLimiter : MonoBehaviour {

    //our array of ragdoll and max ammount
   public GameObject[] ragdolls;
    public int MaxRagdolls;
	// Use this for initialization
	void Start () {
        ragdolls = new GameObject[MaxRagdolls];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    //adds a ragdoll to our array and check if we have space and if not calls destroy ragdoll
    public void addRagDoll(GameObject doll)
    {
        for(int i = 0; i < ragdolls.Length; i++)
        {
            if(ragdolls[i] == null)
            {
                ragdolls[i] = doll;
                return;
            }
        }
        destroyRagDoll(0);
        addRagDoll(doll);
    }

    //destroys the oldest ragdoll aka the rakdoll at index 0
    public void destroyRagDoll(int i)
    {
        Destroy(ragdolls[i].gameObject);
        ragdolls[0] = null;
        shiftDown();
    }
    //shifts our array down
    public void shiftDown()
    {
        //can only run if the first element is null
        if (ragdolls[0] == null)
        {
            for (int i = 0; i < ragdolls.Length-1; i++)
            {
                //goes through each element and shifts the array down
                if (ragdolls[i] == null && ragdolls[i+1] != null)
                {
                    ragdolls[i] = ragdolls[i+1];
                    ragdolls[i + 1] = null;
                }
            }
        }
    } 

    //destroy every ragdoll
    public void clearRagDolls()
    {
        for (int i = 0; i < ragdolls.Length-1; i++)
        {
            if (ragdolls[i] != null)
            {
                Destroy(ragdolls[i].gameObject);
                ragdolls[i] = null;
            }
        }
    }
}
