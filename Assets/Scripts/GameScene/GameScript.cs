using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    void Start()
    {
        menu.SetActive(false);
    }
    void Update()
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

    public void GotoHomeMenu()
	{
        SceneManager.LoadScene("HomeScene");
	}
}
