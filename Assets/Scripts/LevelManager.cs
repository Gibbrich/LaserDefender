using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name.Equals("Start Menu"))
        {
            ScoreKeeper.ResetScore();
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("New Level load: " + name);
        Application.LoadLevel(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested");
        Application.Quit();
    }
}