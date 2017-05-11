using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnimation : MonoBehaviour {


    //textures
    Texture2D texture;
    Texture2D dead;
    GUISkin skin;
    //values used for fading
    float fadeSpeed = 0.8f;
    int drawDepth = -1000;
    float alpha = 0.0F;
    int fadeDir = 1;
    Color colour;
    int stage;
	AudioClip deathSound;
    // Use this for initialization
    void Start () {
        //disable gui for player mainly due to the pause button setting timescale back to 1.
        GameObject.FindGameObjectWithTag("UI").GetComponent<playerGUI>().enabled = false;

		deathSound = Resources.Load ("Wilhelm-Scream") as AudioClip;
		AudioSource audio = GetComponent<AudioSource> ();
		audio.pitch = 1.0f;
		audio.volume = 0.04f;
		audio.clip = deathSound;
		audio.Play();
        //load textures from resources
        stage = GameObject.FindGameObjectWithTag("StageController").GetComponent<StageController>().stage;
        dead = (Texture2D)Resources.Load("dead");
        texture = (Texture2D) Resources.Load("black");
        skin = (GUISkin)Resources.Load("DeathText");
        //make the game slow motion
        UnityEngine.Time.timeScale = 0.15f;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }


    void OnGUI()
    {
        //DIsplayed the stage we made it to
        GUI.skin = skin;
        GUI.Box(new Rect((Screen.width/2)-175,Screen.height/1.2f,350,60), "You Made it to stage: " + stage.ToString());
       
        //Displays you are dead texture
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height / 1.2f), dead);

        //fade out the screen by increasing the black images alpha
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);
        colour.a = alpha;
        GUI.color = colour;
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
       
        //if our screen is completely black set time back to normal and load the main menu
        if (alpha == 1)
        {
            UnityEngine.Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
            SceneManager.LoadScene(0);
        }
    }
}
