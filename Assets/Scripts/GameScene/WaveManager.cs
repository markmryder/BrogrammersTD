﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{

    public static WaveManager wave;
    private int waveNumber;
    private int score;
    public int timeBetweenSpawn = 3;


    [SerializeField] Text WaveInfoText;
    public Text TurretInfoText;
    public Text BaseHealthInfoText;
    public Text ScoreInfoText;
    public Text EnemiesRemainingText;

    public Node SpawnLocation;
    public Node Destination;
    public bool isWaveTriggered;
    [SerializeField] GameObject Enemy;

    private List<GameObject> Walls;
    private bool isGameActive = true;
    [SerializeField] NavMeshSurface surface;

    private int TurretCount;
    public int BaseHealth = 5;
    private int enemiesRemaining;
    private bool IsGameOver = false;

    private Coroutine spawnRoutine;
    private Coroutine wallRemove;
    [SerializeField] int TimeBetweenWallRemove = 5;

    public AudioSource audioSource;

    



	public void OnLevelWasLoaded(int level)
	{
        //Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        var spawn = GameObject.FindObjectOfType<SpawnNode>();
        var destination = GameObject.FindObjectOfType<Base>();
        SpawnLocation = spawn.GetComponent<Node>();
        Destination = destination.GetComponent<Node>();

        TurretInfoText = GameObject.Find("TurretsRemainText").GetComponent<Text>();
        BaseHealthInfoText = GameObject.Find("HealthText").GetComponent<Text>();
        ScoreInfoText = GameObject.Find("ScoreText").GetComponent<Text>();
        EnemiesRemainingText = GameObject.Find("EnemiesRemainingText").GetComponent<Text>();

        var Base = FindObjectOfType<Base>();
        BaseHealth = Base.Hitpoints;
        spawnRoutine = null;
        wallRemove = null;


        TurrentPlacement.totalTurret = 5;
        waveNumber = WaveStats.Wave;
        score = WaveStats.Score;
        WaveInfoText.text = "Wave: " + waveNumber;
        enemiesRemaining = WaveStats.EnemiesPerWave;
    }

	private void Update()
	{
        CheckBaseHealth();
        CountTurrets();
        UpdateTurretUI();
        UpdateScoreBoard();
        UpdateBaseHealthUI();
        UpdateEnemiesRemainingUI();


		if (IsWaveOver())
		{
            //have some transition for next wave
            //NextWave();
            StopCoroutine(wallRemove);
            var script = GameObject.FindObjectOfType<GameScript>();
            script.EndWave();
        }
	}

	private void CheckBaseHealth()
	{
        var Base = FindObjectOfType<Base>();
        BaseHealth = Base.Hitpoints;
        if(BaseHealth <= 0)
		{
            GameOver();
		}
	}

    public void GameOver()
	{
        StopCoroutine(spawnRoutine);
        StopCoroutine(wallRemove);
		if (IsGameOver)
		{
            IsGameOver = false;
            StartCoroutine(GameOverCoroutine());
        }

        // start some coroutine maybe
        // return to home screen
        print("GameOver");
        IsGameOver = true;
	}

    public void AddToScore()
	{
        score += 1;
	}

    private IEnumerator GameOverCoroutine()
	{
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
		{
            enemy.GetComponent<Animator>().SetBool("Win",true);
		}
        yield return null;
	}

	private void UpdateTurretUI()
	{
        TurretInfoText.text = "Turrets Remaining: " + TurretCount;
	}
    private void UpdateScoreBoard()
	{
        ScoreInfoText.text = "Score: " + score;
	}
    private void UpdateBaseHealthUI()
	{
        BaseHealthInfoText.text = "Base Health: " + BaseHealth;
	}

    private void UpdateEnemiesRemainingUI()
	{
        EnemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
	}
        
    private void CountTurrets()
	{
        TurretCount = TurrentPlacement.totalTurret;
    }
    private bool IsWaveOver()
	{
        if(enemiesRemaining > 0 || CountEnemies() > 0)
		{
            return false;
		}
        else
        {
            //check base health first
            var Base = FindObjectOfType<Base>();
            if(Base.Hitpoints > 0)
			{
                return true;
            }
            return false;
		}
	}
    private int CountEnemies()
	{
        List<EnemyMoveTo> enemies = FindObjectsOfType<EnemyMoveTo>().ToList<EnemyMoveTo>();
        int enemyCount = enemies.Count;
        enemies.Clear();
        return enemyCount;
	}

	public void StartWave() 
    {
        isWaveTriggered = true;
        spawnRoutine = StartCoroutine(StartSpawn());
        wallRemove = StartCoroutine(RemoveBlocks());
        audioSource.Play();
        var button = GameObject.Find("StartWaveButton");
        button.SetActive(false);
    }

    public IEnumerator StartSpawn()
    {
        while (isWaveTriggered && enemiesRemaining > 0)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Vector3 position = SpawnLocation.transform.position;
            Instantiate(Enemy, position, Quaternion.identity);
            enemiesRemaining--;

        }
    }


    public void NextWave()
	{
        //increment the wave
        WaveStats.Score = score;
        WaveStats.NextWave();

        SceneManager.LoadScene("DemoSceneCopy");
	}

    public IEnumerator RemoveBlocks()
    {
        Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        while (isGameActive)
        {
            if (Walls.Count == 0)
            {
                break;
            }
            yield return new WaitForSeconds(TimeBetweenWallRemove);
            System.Random rand = new System.Random();
            int randNum = rand.Next(0, Walls.Count);
            GameObject destroyed = Walls[randNum];
            GameObject explosion = (GameObject)Resources.Load("Exploson1");
            Instantiate(explosion, destroyed.transform.position, Quaternion.identity);
            Walls.RemoveAt(randNum);
            Debug.Log(destroyed.name);
            Destroy(destroyed);


        }

    }


}
