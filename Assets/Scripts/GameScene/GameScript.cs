using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject menu;
	[SerializeField] public GameObject endGameMenu;
	[SerializeField] public GameObject endWaveMenu;
    void Start()
    {
        menu.SetActive(false);
		endGameMenu.SetActive(false);
		endWaveMenu.SetActive(false);
    }
    void Update()
	{
		CheckForPause();
	}

	private void CheckForPause()
	{
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (!menu.activeInHierarchy)
			{
				PauseGame();
			}
			else if (menu.activeInHierarchy)
			{
				ContinueGame();
			}
		}
	}

	private void PauseGame()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }
    private void ContinueGame()
    {
        Time.timeScale = 1;
        menu.SetActive(false);
    }

	public void EndWave() 
	{
		endWaveMenu.SetActive(true);
	}
	public void EndGame()
	{
		endGameMenu.SetActive(true);
	}

    public void GotoHomeMenu()
	{
		StopAllCoroutines();
        SceneManager.LoadScene("HomeScene");
	}
}
