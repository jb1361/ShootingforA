using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using NSubstitute;
public class TestPlayerDirectionUpdate
{


    public playerController playerControllerScript;

    [Test]
    public void TestPlayerDirection()
    {

        //expected position and new position
        Vector3 expectedForwardVector = new Vector3(1.0f, 0, 0.0f);
        Vector3 actualForwardVector;


        //set up new object gameobject
        GameObject testObject = new GameObject();
        //add playercontroller to the object
        testObject.AddComponent<playerController>();
        //get the instance of the playercontroller
        playerControllerScript = testObject.GetComponent<playerController>();
        //set the player gameobject to our new gameobject
        GameObject playerObject = new GameObject();
        playerControllerScript.player = playerObject;
        playerObject.transform.forward = new Vector3(0, 0, 1.0f);
        Debug.Log(playerObject.transform.forward);
        //update the player position
        playerControllerScript.updateDirection(1.0f, 0.0f);
        //get the position
        actualForwardVector = playerObject.transform.forward;
        Debug.Log(playerObject.transform.forward);
        Assert.That(actualForwardVector.x, Is.EqualTo(expectedForwardVector.x).Within(0.1f), "Testing Player Position x: ");
      //  Assert.That(expectedPosition.z, Is.EqualTo(actualPosition.z).Within(0.1f), "Testing Player Position z: ");
      //  Assert.That(0, Is.EqualTo(actualPosition.y).Within(0.1f), "Testing Player Position Y (should always be 0): ");


    }
}
