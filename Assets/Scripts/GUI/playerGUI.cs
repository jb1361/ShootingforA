using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class playerGUI : MonoBehaviour {
	public Text textStage;
	public Text textStage2;
	public Text textStage3;
	public Text textStage4;
	public Image Image1;
	public Image Image2;
	public Light lightIntensity;
	public Button PauseButton;
	public Button ResumeButton;
	public Button Restart;
	public Button Mainmenu;
    public Image ArmorIcon;
    public Text ArmorAmmount;
	public StageController stage;
    public Text ArmorNumber;
    public Text SpeedBoostNumber;
    public Text GrenadeNumber;
    public Text NukeNumber;
    PowerUp powerup;
    playerInputController input;
    playerController player;
    public bool pause;
    // Use this for initialization
    void Start () {
        powerup = GameObject.FindGameObjectWithTag("Player").GetComponent<PowerUp>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        input = GameObject.FindGameObjectWithTag("Player").GetComponent<playerInputController>();
        pause = false;
	}
	
	// Update is called once per frame
	void Update () {
		textStage.text = "" + stage.stage;
		textStage2.text = "" + stage.score.ToString ("000000");
		textStage3.text = "Kills: " + stage.kills;
		textStage4.text = "Zombies: " + stage.enemysOnField;
       
        

        //same for optimization as below
       
        ArmorNumber.text = powerup.getPowerUpAmmount(0).ToString();
        SpeedBoostNumber.text = powerup.getPowerUpAmmount(1).ToString();
        GrenadeNumber.text = powerup.getPowerUpAmmount(2).ToString();
        NukeNumber.text = powerup.getPowerUpAmmount(3).ToString();
        //optimization can be done here to only make this run once instead of every frame
        if (powerup.haveArmor)
        {
            ArmorIcon.enabled = true;
            ArmorAmmount.enabled = true;
            ArmorAmmount.text = (player.health-100).ToString();
        }else
        {
            ArmorIcon.enabled = false;
            ArmorAmmount.enabled = false;
            ArmorAmmount.text = "0";
        }
       
      //  p = CrossPlatformInputManager.GetAxisRaw("Pause");
        if (CrossPlatformInputManager.GetButtonDown("Pause")) Pause();
        

        
    }



    public void Pause()
    {
        pause = !pause;
		if (pause)
		{
			input.enabled = false;
			Time.timeScale = 0;
			lightIntensity.intensity = 0f;
			PauseButton.gameObject.SetActive (false);
			ResumeButton.gameObject.SetActive (true);
			Mainmenu.gameObject.SetActive (true);
			Restart.gameObject.SetActive (true);
			Image1.gameObject.SetActive (true);
			Image2.gameObject.SetActive (true);

		}
		else
		{
			input.enabled = true;
			Time.timeScale = 1;
			lightIntensity.intensity = .9f;
			PauseButton.gameObject.SetActive (true);
			ResumeButton.gameObject.SetActive (false);
			Mainmenu.gameObject.SetActive (false);
			Restart.gameObject.SetActive (false);
			Image1.gameObject.SetActive (false);
			Image2.gameObject.SetActive (false);

		}
    }


}
