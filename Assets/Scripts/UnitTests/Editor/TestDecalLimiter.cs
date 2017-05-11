using UnityEngine;
using UnityEditor;
using NUnit.Framework;

public class TestDecalLimiter {
    //destroy ragdoll and clearragdolls could not be tested due to not being able to destroy gameobjects in the editor
	[Test]
	public void TestAddRagdoll() {
        GameObject testObject = new GameObject();
        GameObject ragDollObject = new GameObject();
        testObject.AddComponent<decalLimiter>();
        decalLimiter decal = testObject.GetComponent<decalLimiter>();
        decal.ragdolls = new GameObject[1];
        decal.addRagDoll(ragDollObject);
        Assert.True(decal.ragdolls[0] , "Testing if we added a ragdoll.");
	}

    [Test]
    public void TestShiftDown()
    {
        GameObject testObject = new GameObject();
        GameObject ragDollObject = new GameObject();
        testObject.AddComponent<decalLimiter>();
        decalLimiter decal = testObject.GetComponent<decalLimiter>();
        decal.ragdolls = new GameObject[10];
        decal.ragdolls[1] = ragDollObject;
        decal.shiftDown();  
        Assert.True(decal.ragdolls[0], "Testing if we shifted the array objects down.");
    }
}
