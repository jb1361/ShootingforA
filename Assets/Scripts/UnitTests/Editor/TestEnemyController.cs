using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestEnemyController {
    //we set up a test object and add the required classes to it and get those instances of the classes and perform our tests from those.
	[Test]
	public void TestTakeDamage() {
        GameObject testObject = new GameObject();
        testObject.AddComponent<EnemyController>();
        EnemyController enemyC = testObject.GetComponent<EnemyController>();
        enemyC.health = 100;
        enemyC.takeDamage(50);
        int expected = 50;
        int actual = enemyC.health;
        Assert.AreEqual(expected, actual, "Testing to see if the enemy has taken the proper ammount of damage");
	}

    [Test]
    public void TestSendDamage()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<EnemyController>();
        testObject.AddComponent<playerController>();
        EnemyController enemyC = testObject.GetComponent<EnemyController>();
        enemyC.playerc = testObject.GetComponent<playerController>();
        enemyC.playerc.health = 100;
        enemyC.sendDamage(50);
        int expected = 50;
        int actual = enemyC.playerc.health;
        Assert.AreEqual(expected, actual, "Testing to see if the player has taken the proper ammount of damage");
        Assert.False(enemyC.canattack, "Testing if canattack is false after attacking");
    }

    //for this test we will only be testing if it returns a number which we will set the random parameters between 0 and 2 so we always get 1
    [Test]
    public void TestRandom()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<EnemyController>();
        EnemyController enemyC = testObject.GetComponent<EnemyController>();     
        int expected = 1;
        int actual = enemyC.Random(2);
        Assert.AreEqual(expected, actual, "Testing to see if random returns 1");
    }

    [Test]
    public void TestdropPowerUp()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<EnemyController>();
        EnemyController enemyC = testObject.GetComponent<EnemyController>();
        //set up drop table
        enemyC.drops = new GameObject[4];
        enemyC.drops[0] = new GameObject("test");
        enemyC.drops[1] = new GameObject("test");
        enemyC.drops[2] = new GameObject("test");
        enemyC.drops[3] = new GameObject("test");
        enemyC.dropPowerUp();
        GameObject drop = GameObject.Find("test");
        //we are testing if the powerup is in the hierarchy
        Assert.IsTrue(drop.activeInHierarchy);
          
    }

    [Test]
    public void Testdeath()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<EnemyController>();
        testObject.AddComponent<StageController>();
        testObject.AddComponent<decalLimiter>();
        EnemyController enemyC = testObject.GetComponent<EnemyController>();
        StageController sc = testObject.GetComponent<StageController>();
        decalLimiter dl = testObject.GetComponent<decalLimiter>();
        dl.ragdolls = new GameObject[2];
        dl.MaxRagdolls = 2;
        enemyC.decal = dl;
        enemyC.StageControlla = sc;

        enemyC.ragdoll = new GameObject();
        //set up drop table
        enemyC.drops = new GameObject[4];
        enemyC.drops[0] = new GameObject("test");
        enemyC.drops[1] = new GameObject("test");
        enemyC.drops[2] = new GameObject("test");
        enemyC.drops[3] = new GameObject("test");
        
        enemyC.death();

        int expected = 1;
        int actual = sc.kills;
        Assert.AreEqual(expected, actual, "Testing to see if the death method updated values accurately");

    }

}


