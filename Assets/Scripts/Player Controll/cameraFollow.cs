using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class cameraFollow : MonoBehaviour {
    public GameObject mCamera;
    public GameObject player;
    public int distance;

    //These floats are to edit the boundary of where our camera can go
    public float maxboundx;
    public float minboundx;
    public float maxboundz;
    public float minboundz;
    bool clampx;
    bool clampz;
    // Use this for initialization
    void Start () {
       
        //distance camera is from the player
        distance = 25;
        try { 
            mCamera = GameObject.FindGameObjectWithTag("cameraPosition");
            player = this.gameObject;

        }
        catch (Exception e) {
            Debug.Log("No Camera: " + e);
        }//catch

        //set up initial position of the camera
        mCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distance, player.transform.position.z - 10);
        //sets the rotation of our camera
        mCamera.transform.eulerAngles = new Vector3(70, 0, 0);

    }//start


    void FixedUpdate () {
        //this checks if our player position is outside of these bounds then prevents our camera from going further.

        //clamp x position of our camera
        if (player.transform.position.x > maxboundx || player.transform.position.x < minboundx)
        {
            //if we are already clamping z then we need to not update the z position
            if(clampz) mCamera.transform.position = new Vector3(mCamera.transform.position.x, player.transform.position.y + distance, mCamera.transform.position.z);
            else mCamera.transform.position = new Vector3(mCamera.transform.position.x, player.transform.position.y + distance, player.transform.position.z - 10);
            clampx = true;
        }
        else clampx = false;

        //clamp z position of the camera
        if (player.transform.position.z > maxboundz || player.transform.position.z < minboundz)
        {
            //if we are already clamping x then we need to not update the x position
            if (clampx) mCamera.transform.position = new Vector3(mCamera.transform.position.x, player.transform.position.y + distance, mCamera.transform.position.z);
            else mCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distance, mCamera.transform.position.z);
            clampz = true;
        }
        else clampz = false;

        //if we are in the bounds then update normally
        if(!clampx && !clampz)  mCamera.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + distance, player.transform.position.z - 10);
	
	}//update

}//script
