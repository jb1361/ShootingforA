using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestPowerUpClass {

    //for each test we create a game object and add the powerup class to it then get that instance of the component
    //we then initialize our powerup array
    //finally we test each method and the powerup array's values to make sure they are correct.
    //some tests will require other methods to work properly but since those methods are also tested we do not have to test each case for every method 
    //since we just need to make sure that the methods being called work.

    [Test]
    public void TestHavePowerUp()
    {

        bool expected = true;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(0);
        Assert.AreEqual(expected, powerup.HavePowerup(0), "Testing if we have a powerup.");
    }


    [Test]
    public void TestgetPowerUpAmmount()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(0);
        Assert.AreEqual(expected, powerup.getPowerUpAmmount(0), "Testing if getpowerupammount returns the correct value.");
    }

    [Test]
	public void TestNewPowerUpAddArmor() {

        int expected = 1;
		//Arrange
		GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(0);
        Assert.AreEqual(expected, powerup.powerup[0], "Testing if we have an armor powerup.");
	}

    [Test]
    public void TestNewPowerUpAddSpeedBoost()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(1);
        Assert.AreEqual(expected, powerup.powerup[1], "Testing if we have an speedboost powerup.");
    }

    [Test]
    public void TestNewPowerUpAddGrenade()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(2);
        Assert.AreEqual(expected, powerup.powerup[2], "Testing if we have an grenade powerup.");
    }

    [Test]
    public void TestNewPowerUpAddNuke()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.AddPowerUp(3);
        Assert.AreEqual(expected, powerup.powerup[3], "Testing if we have an nuke powerup.");
    }

    [Test]
    public void TestUsePowerUpArmorWhenThereIsNone()
    {

        int expected = 0;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.UsePowerup(0);
        Assert.AreEqual(expected, powerup.powerup[0], "Testing if we used the armor powerup.");
    }
    [Test]
    public void TestUsePowerUpSpeedBoostWhenThereIsNone()
    {

        int expected = 0;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.UsePowerup(1);
        Assert.AreEqual(expected, powerup.powerup[1], "Testing if we used the speedboost powerup.");
    }
    [Test]
    public void TestUsePowerUpGrenadeWhenThereIsNone()
    {

        int expected = 0;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.UsePowerup(2);
        Assert.AreEqual(expected, powerup.powerup[2], "Testing if we used the grenade powerup.");
    }
    [Test]
    public void TestUsePowerUpNukeWhenThereIsNone()
    {

        int expected = 0;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.powerup = new int[4];
        powerup.UsePowerup(3);
        Assert.AreEqual(expected, powerup.powerup[3], "Testing if we used the nuke powerup.");
    }

    [Test]
    public void TestUsePowerUpArmorWhenWeHaveIt()
    {

        int expected = 0;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.player = playerc;
        powerup.powerup = new int[4];
        powerup.AddPowerUp(0);
        powerup.UsePowerup(0);
        Assert.AreEqual(expected, powerup.powerup[0], "Testing if we used the armor powerup.");
    }
    [Test]
    public void TestUsePowerUpArmorWhenPlayerHealthOverOneHundred()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 200;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.player = playerc;
        powerup.powerup = new int[4];
        powerup.AddPowerUp(0);
        powerup.UsePowerup(0);
        Assert.AreEqual(expected, powerup.powerup[0], "Testing if we used the armor powerup.");
    }


    [Test]
    public void TestUsePowerUpSpeedBoostWhenWeAreAlreadyUsingSPeedBoost()
    {

        int expected = 1;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        playerc.moveSpeed = 10;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.player = playerc;
        powerup.powerup = new int[4];
        powerup.AddPowerUp(1);
        powerup.AddPowerUp(1);
        powerup.UsePowerup(1);
        powerup.UsePowerup(1);
        Assert.AreEqual(expected, powerup.powerup[1], "Testing if we cannot use a seocnd speedboost while already using one.");
    }



    [Test]
    public void TestAddArmor()
    {

        int expected = 300;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.player = playerc;
        powerup.AddArmor();
        Assert.AreEqual(expected, playerc.health, "Testing if we used the armor powerup.");
    }

    [Test]
    public void TestSpeedBoost()
    {

        int expected = 30;
        //Arrange
        GameObject testObject = new GameObject();
        testObject.AddComponent<PowerUp>();
        testObject.AddComponent<playerController>();
        playerController playerc = testObject.GetComponent<playerController>();
        playerc.player = new GameObject();
        playerc.health = 100;
        PowerUp powerup = testObject.GetComponent<PowerUp>();
        powerup.player = playerc;
        powerup.SpeedBoost();
        Assert.AreEqual(expected, playerc.moveSpeed, "Testing if we used the armor powerup.");
    }
}
