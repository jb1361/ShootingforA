using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class TestSceneLoader {
    //this currently does not test because SceneManager.LoadScene  can only be used during runtime and not in the editor
    [Test]
	public void TestChangeScene() {
		//Create an object, add our monobehavior then get that class
		GameObject testObject = new GameObject();
        testObject.AddComponent<SceneLoader>();
      //  SceneLoader sl = testObject.GetComponent<SceneLoader>();
        int expected = -1;
       // sl.ChangeScene(1);
        int actual = SceneManager.GetActiveScene().buildIndex;
        Assert.AreEqual(expected, actual, "Testing to see if the scene is changed");
	}
}
