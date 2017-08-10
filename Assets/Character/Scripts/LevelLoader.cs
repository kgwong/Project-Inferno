using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Currently still testing level loading.
<<<<<<< HEAD
	void Start () {
        print("loading level");
        SceneManager.LoadScene(1);
	
	}
	
=======

    public void loadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
	
    public void loadDeathScreen()
    {
        SceneManager.LoadScene(1);
    }
>>>>>>> 45408a9bf9a0841775fdff74ddd671cda7e78ec6
}
