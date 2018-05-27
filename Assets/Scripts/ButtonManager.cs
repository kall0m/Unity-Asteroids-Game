using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {
    public void StartGameBtn(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void ExitGameBtn()
    {
        Application.Quit();
    }
}
