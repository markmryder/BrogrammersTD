/*
 Created by: Mark Ryder
 Contributions:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }



    public void LoadGame()
	{
        SceneManager.LoadScene("DemoSceneCopy");
	}

    public void LoadCredits()
	{
        SceneManager.LoadScene("CreditsScene");
	}
}
