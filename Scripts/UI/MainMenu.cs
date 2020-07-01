using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void SetVolume (float sliderValue)
    {
        audioMixer.SetFloat("volume", Mathf.Log10 (sliderValue) *20);
    }

    public void TEST()
    {
        SceneManager.LoadScene("TEST");
        Debug.Log("TEST");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level-1");
        Debug.Log("Level-1");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level-2");
        Debug.Log("Level-2");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Level-3");
        Debug.Log("Level-3");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
