using System;
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
    [SerializeField] Text WaveInfoText;
    public Text TurretInfoText;

    public Node SpawnLocation;
    public Node Destination;
    public bool isWaveTriggered;
    [SerializeField] GameObject Enemy;

    private List<GameObject> Walls;
    private bool isGameActive = true;
    [SerializeField] NavMeshSurface surface;

    private List<Turret> Turrets;
    private int TurretCount;

    private void Awake()
	{

	}




	public void OnLevelWasLoaded(int level)
	{
        Turrets = GameObject.FindObjectsOfType<Turret>().ToList<Turret>();
        Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        var spawn = GameObject.FindObjectOfType<SpawnNode>();
        var destination = GameObject.FindObjectOfType<Base>();
        SpawnLocation = spawn.GetComponent<Node>();
        Destination = destination.GetComponent<Node>();
        TurretInfoText = GameObject.Find("TurretsRemainText").GetComponent<Text>();
        TurrentPlacement.totalTurret = 5;
        waveNumber = WaveStats.Wave;
        score = WaveStats.Score;

        WaveInfoText.text = "Wave: " + waveNumber;
    }

	private void Update()
	{
        CountTurrets();
        UpdateUI();
	}

	private void UpdateUI()
	{
        TurretInfoText.text = "Turrets Remaining: " + TurretCount;
	}
    private void CountTurrets()
	{
        //Turrets = GameObject.FindObjectsOfType<Turret>().ToList<Turret>();
        TurretCount = TurrentPlacement.totalTurret;

    }
	public void StartWave() 
    {
        isWaveTriggered = true;
        StartCoroutine(StartSpawn());
        StartCoroutine(RemoveBlocks());
    }

    public IEnumerator StartSpawn()
    {
        while (isWaveTriggered)
        {
            yield return new WaitForSeconds(3);
            Vector3 position = SpawnLocation.transform.position;
            Instantiate(Enemy, position, Quaternion.identity);

        }
    }

    public void NextWave()
	{
        WaveStats.NextWave();
        //do stuff here

        SceneManager.LoadScene("DemoSceneCopy");
	}

    public IEnumerator RemoveBlocks()
    {

        while (isGameActive)
        {
            if (Walls.Count == 0)
            {
                break;
            }
            surface.BuildNavMesh();
            yield return new WaitForSeconds(5);
            System.Random rand = new System.Random();
            int randNum = rand.Next(0, Walls.Count);
            GameObject destroyed = Walls[randNum];
            Walls.RemoveAt(randNum);
            Debug.Log(destroyed.name);
            Destroy(destroyed);

        }

    }


}
