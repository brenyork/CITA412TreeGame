using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNav : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToTitleScreen()
    {
        SceneManager.LoadScene(0);
    }
    public void ToFirstLevel()
    {
        SceneManager.LoadScene(2);
    }
    public void ToNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    public void RestartLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void ToHowTo()
    {
        SceneManager.LoadScene(1);
    }
}
