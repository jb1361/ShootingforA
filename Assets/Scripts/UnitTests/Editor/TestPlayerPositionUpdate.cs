using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;

public class TestPlayerPositionUpdate {

    public playerController playerControllerScript;

    [Test]
    public void TestPlayerPosition()
    {
        
        //expected position and new position
        Vector3 expectedPosition = new Vector3(2.4f, 0, 2.4f);
        Vector3 actualPosition;


        //set up new object gameobject
        GameObject testObject = new GameObject();
        //add playercontroller to the object
        testObject.AddComponent<playerController>();
        //get the instance of the playercontroller
        playerControllerScript = testObject.GetComponent<playerController>();
        //set the player gameobject to our new gameobject
        GameObject playerObject = new GameObject();
        playerControllerScript.player = playerObject;
      //  playerControllerScript.player.transform.position = new Vector3(0, 0, 0);
        playerControllerScript.moveSpeed = 10;

        //update the player position
        playerControllerScript.updatePosition(1.0f, 1.0f);
        //get the position
        actualPosition = playerObject.transform.position;
        
        Assert.That(actualPosition.x, Is.EqualTo(expectedPosition.x).Within(0.1f), "Testing Player Position x: ");
        Assert.That(actualPosition.z, Is.EqualTo(expectedPosition.z).Within(0.1f), "Testing Player Position z: ");
      


    }
}
