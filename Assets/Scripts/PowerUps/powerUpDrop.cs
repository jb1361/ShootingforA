using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerUpDrop : MonoBehaviour {

    float spinSpeed;
    float despawnTimer;
    bool visible;
    float delay;
    MeshRenderer render;
	// Use this for initialization
	void Start () {
        spinSpeed = 40.0f;
        despawnTimer = 15.0f;
        visible = true;
        delay = 0.5f;
        render = this.gameObject.GetComponentInChildren<MeshRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
        despawnTimer -= 1 * Time.deltaTime;
        if (despawnTimer <= 6.0f) flickerMesh();
        if (despawnTimer <= 0) Destroy(this.gameObject);
	}

    private void FixedUpdate()
    {
        float y = this.transform.rotation.eulerAngles.y;
       transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, y += spinSpeed * Time.deltaTime, this.transform.rotation.eulerAngles.z);
    }
    public void flickerMesh()
    {
        delay -= 1 * Time.deltaTime;
        if (delay <= 0.0f)
        {
            if (visible)
            {
               render.enabled = false;
                visible = false;
            }else
            {
                render.enabled = true;
                visible = true;
            }
            delay = 0.5f;

        }
    }
}
