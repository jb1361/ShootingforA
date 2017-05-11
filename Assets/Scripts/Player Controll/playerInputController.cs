using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInputController : MonoBehaviour {


    //set up our interface this is used to eliminate the dependency on the crossplatforminputmanager
    private static IplayerInputController interfacedefault = new MyCrossPlatformInputManager();
    private IplayerInputController inputInterface;

    public IplayerInputController InputInterface
    {
        get { return (inputInterface == null) ? interfacedefault : inputInterface; }
        set { inputInterface = value; }
    }


    

    //variables for Crossplatforminput
    public float Lookh { get; set; }
    public float Lookv { get; set; }
    public float Moveh { get; set; }
    public float Movev { get; set; }
    public float f { get; set; }
    playerController sendInput;
    Animator anim;
    

   
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        sendInput = GetComponent<playerController>();
    
     
     
    }

    public void getCurrentInput()
    {
       
        //left joystick or wasd
        Moveh = InputInterface.GetAxisRaw("Horizontal");
        Movev = InputInterface.GetAxisRaw("Vertical");
        //right joystick or arrow keys
        Lookh = InputInterface.GetAxisRaw("HorizontalLook");
        Lookv = InputInterface.GetAxisRaw("VerticalLook");
        //space or right trigger
        f = InputInterface.GetAxisRaw("Fire1");

    }

  

    // Update is called once per frame
    void Update () {

        //calls a method that gets our current input
        getCurrentInput();


        //send our inputs to the playercontroller
        if (Mathf.Abs(Moveh) != 0 || Mathf.Abs(Movev) != 0)
        {
            
            anim.SetFloat("Blend", 1, 0.1f, Time.deltaTime);         
           sendInput.updatePosition(Moveh, Movev);
           
        }else
        {
            sendInput.notUpdatingPosition();
            anim.SetFloat("Blend", 0, 0.1f, Time.deltaTime);
        }
        //update player direction
        if (Mathf.Abs(Lookh) != 0 || Mathf.Abs(Lookv) != 0) sendInput.updateDirection(Lookh, Lookv);
        else sendInput.notUpdatingDirection();
        //gets if we are firing
        if (Mathf.Abs(f) != 0) sendInput.fire();      
      
        if (InputInterface.GetAxisRaw("Grenade") != 0) UsePowerUp(2);
        if (InputInterface.GetAxisRaw("Armor") != 0) UsePowerUp(0);
        if (InputInterface.GetAxisRaw("SpeedBoost") != 0) UsePowerUp(1);
        if (InputInterface.GetAxisRaw("Nuke") != 0) UsePowerUp(3);

    }



    void UsePowerUp(int i)
    {    
        sendInput.UsePowerUp(i);
    }


}

