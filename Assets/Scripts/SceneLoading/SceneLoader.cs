using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour {

	// Use this for initialization

	public void ChangeScene(int number){
		SceneManager.LoadScene (number);
    }
}
