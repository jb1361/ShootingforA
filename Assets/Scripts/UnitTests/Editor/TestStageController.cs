using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestStageController {

	[Test]
	public void TestKills() {
        GameObject testObject = new GameObject();
        testObject.AddComponent<StageController>();
        StageController sc = testObject.GetComponent<StageController>();
        sc.Kills();
        int expected = 1;
        int actual = sc.kills;
        Assert.AreEqual(expected, actual, "Testing if a kill is added");
	}

    [Test]
    public void TestAddScore()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<StageController>();
        StageController sc = testObject.GetComponent<StageController>();
        sc.AddScore(20);
        int expected = 20;
        int actual = sc.score;
        Assert.AreEqual(expected, actual, "Testing if a kill is added");
    }

    [Test]
    public void TestSpawnEnemies()
    {
        GameObject testObject = new GameObject();
        testObject.AddComponent<StageController>();
        StageController sc = testObject.GetComponent<StageController>();
        sc.Enemy = new GameObject();
        sc.spawnzones = new GameObject[1];
        sc.spawnzones[0] = new GameObject();
        sc.enemysToSpawn = 5;
        sc.spawnEnemys();
        int expected = 5;
        int actual = sc.enemysOnField;
        Assert.AreEqual(expected, actual, "Testing if a kill is added");
    }
}
