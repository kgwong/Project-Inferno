using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

    public void quitGame()
    {
        print("Game has quit (can't do in editor mode)");
        Application.Quit();
    }
}
