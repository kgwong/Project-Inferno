using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	// Currently still testing level loading.

    public void loadFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
	
    public void loadDeathScreen()
    {
        SceneManager.LoadScene(1);
    }
}
