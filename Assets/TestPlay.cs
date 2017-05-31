using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TestPlay : MonoBehaviour {

    public void playGame()
    {
        print("loading level");
        SceneManager.LoadScene(1);
    }
}
