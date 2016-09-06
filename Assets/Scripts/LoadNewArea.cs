using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadNewArea : MonoBehaviour {
	public string levelToLoad;

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name == "Player") {
			SceneManager.LoadScene (levelToLoad);
		}
	}

}
