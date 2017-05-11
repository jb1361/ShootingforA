using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestFireweapon {
    public fireWeapon fireW;
	[Test]
	public void TestFireWeaponcanFireisfalseafterfire() {
        GameObject testObject = new GameObject();
        testObject.AddComponent<fireWeapon>();
        fireW = testObject.GetComponent<fireWeapon>();
        GameObject projectile = new GameObject();
        GameObject spawnloc = new GameObject();
        spawnloc.transform.position = new Vector3(0,0,0);
        projectile.name = "Test";
        fireW.setFireRate(1.0f);
        fireW.setProjectile(projectile);
        fireW.spawnLoc = spawnloc;
        fireW.fire();
     //   bool expected = false;
        Assert.False(fireW.canFire,"Testing if we cannot fire after we fire.");
	}
}
