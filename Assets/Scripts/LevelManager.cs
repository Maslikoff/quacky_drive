using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void Restart()
    {
        SceneManager.LoadScene("TestDev");
        Time.timeScale = 1;
    }

    public void LoadVictoryScene()
    {
        SceneManager.LoadScene("VictoryScene"); SceneManager.LoadScene("LostScene");
    }

    public void LoadLostScene()
    {
        SceneManager.LoadScene("LostScene");
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }

    public void PlayMission(string nameMission)
    {
        SceneManager.LoadScene(nameMission);
    }
}
