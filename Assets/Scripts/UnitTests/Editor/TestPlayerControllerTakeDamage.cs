using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestPlayerControllerTakeDamage {


    public playerController playerControllerScript;

    [Test]
    public void TestPlayertakeDamage()
    {

        int expected = 20;
        int actual;
        //set up new object gameobject
        GameObject testObject = new GameObject();
        //add playercontroller to the object
        testObject.AddComponent<playerController>();
        //get the instance of the playercontroller
        playerControllerScript = testObject.GetComponent<playerController>();
        playerControllerScript.health = 100;
        playerControllerScript.takeDamage(80);
        actual = playerControllerScript.health;
        Assert.AreEqual(expected, actual, "Testing TakeDamage Method: ");
    }
}
