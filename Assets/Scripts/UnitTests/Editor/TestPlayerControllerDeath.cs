using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestPlayerControllerDeath {
    public playerController playerControllerScript;
    [Test]
	public void TestPlayerDeath() {

        GameObject testObject = new GameObject();
        //add playercontroller to the object
        testObject.AddComponent<playerController>();
        //get the instance of the playercontroller
        playerControllerScript = testObject.GetComponent<playerController>();
        //set health to 100
        playerControllerScript.health = 100;

        //add required components
        testObject.AddComponent<playerInputController>();
        playerInputController input = testObject.GetComponent<playerInputController>();
        Debug.Log(input.isActiveAndEnabled);
        Debug.Log(playerControllerScript.health);
        playerControllerScript.takeDamage(1000);
        Debug.Log(input.isActiveAndEnabled);
        Debug.Log(playerControllerScript.health);
        //  this.gameObject.AddComponent<DeathAnimation>();
        Assert.That(input.isActiveAndEnabled, Is.False, "Testing is playerinput is disabled: ");
        Assert.That(testObject.GetComponent<DeathAnimation>().isActiveAndEnabled, Is.True, "Testing is death animation added: ");
        Assert.That(playerControllerScript.isActiveAndEnabled, Is.False, "Testing is playercontroller is disable: ");

       
       
    }
}
