using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//Created by Arashdeep Wander, and Jake Arthurs

public class TurrentPlacement : MonoBehaviour
{
    static public int totalTurret = 5;
    private GameObject turrent;
    public Text textField;

    public Material floorMaterial;
    public Material blueMaterial;
    public Material redFloor;
    public int locationx;
    public int locationz;

    public void Start()
	{
        floorMaterial = gameObject.transform.GetChild(5).gameObject.GetComponent<Renderer>().material;
        locationx = MazeLocation(gameObject.transform.position.x, gameObject.transform.position.z)[0];
        locationz = MazeLocation(gameObject.transform.position.x, gameObject.transform.position.z)[1];
    }

	void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {

			if (EventSystem.current.IsPointerOverGameObject()) 
            {
                //is on button or some UI element
                return;
            }

            else if (gameObject.tag == "Floor" && totalTurret > 0)
            {
                if (!WillBlock())
                {
                    turrent = (GameObject)Resources.Load("KenneyPrefabs/KenneyTurret2");
                    Vector3 position = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
                    Instantiate(turrent, position, Quaternion.identity);
                    var smoke = (GameObject)Resources.Load("SmokeParticleSystem");
                    Instantiate(smoke, transform.position, Quaternion.identity);
                    print(transform.position);
                    totalTurret--;
                    StartCoroutine(PreventAnotherTurretPlacement());
                }
				else
				{
                    //do something to tell user they cant place because it will block the path
                    var wave = FindObjectOfType<WaveManager>();

                    wave.FadeText();
				}
            }
        }
    }


    public IEnumerator PreventAnotherTurretPlacement()
	{
        gameObject.tag = "Floor_Delay";
        yield return new WaitForSeconds(1);
        gameObject.tag = "Floor";
	}

    public IEnumerator TurretPlacementAnimation()
	{
        
        while(turrent.transform.position.y < 0) 
        {
            yield return new WaitForEndOfFrame();
            Vector3 position = new Vector3(turrent.transform.position.x, turrent.transform.position.y, turrent.transform.position.z);
            position.y += 1f;
            turrent.transform.position = position;
            
        }
        yield return null;
    }

    public IEnumerator ChangeColour()
    {
        gameObject.tag = "Floor_Delay";
        gameObject.transform.GetChild(5).gameObject.GetComponent<Renderer>().material = redFloor;
        yield return new WaitForSeconds(10);
        gameObject.tag = "Floor";
        gameObject.transform.GetChild(5).gameObject.GetComponent<Renderer>().material = floorMaterial;
    }

    public void StartChangeColour()
    {
        StartCoroutine(ChangeColour());
    }

    bool WillBlock()
    {
        int[] getLocation;
        List<GameObject> Walls = GameObject.FindGameObjectsWithTag("Wall").ToList<GameObject>();
        List<GameObject> Turrets = GameObject.FindGameObjectsWithTag("Turret").ToList<GameObject>();
        int[,] mazeValues = new int[24, 12];
        for (int z = 0; z < 12; z++)
            for (int x = 0; x < 24; x++)
            {
                if (x == 0 || x == 23 || z == 0 || z == 11)
                    mazeValues[x, z] = 1;
                else
                    mazeValues[x, z] = 0;
            }
        foreach (GameObject currentWall in Walls)
        {
            getLocation = MazeLocation(currentWall.transform.position.x, currentWall.transform.position.z);
            mazeValues[getLocation[0], getLocation[1]]++;
        }
        foreach (GameObject currentTurret in Turrets)
        {
            getLocation = MazeLocation(currentTurret.transform.position.x, currentTurret.transform.position.z);
            mazeValues[getLocation[0], getLocation[1]]++;
        }
        mazeValues[locationx, locationz]++;

        SolveMaze(mazeValues,1,5);

        if (mazeValues[22, 5] == 1)
            return false;
        return true;
    }

    void SolveMaze(int[,] values, int cx, int cz)
    {
        values[cx, cz]++;
        if (values[cx + 1,cz] == 0)
            SolveMaze(values, cx + 1, cz);
        if (values[cx, cz + 1] == 0)
            SolveMaze(values, cx, cz + 1);
        if (values[cx - 1, cz] == 0)
            SolveMaze(values, cx - 1, cz);
        if (values[cx, cz - 1] == 0)
            SolveMaze(values, cx, cz - 1);
    }

    int[] MazeLocation(float posx, float posz)
    {
        int x, z = 0;
        z = (int)posz / 10 + 1;
        if (posx < 0)
            x = 1;
        else if (posx == 174.6)
            x = 22;
        else
            x = (int)posx / 10 + 2;
        int[] r = { x, z };
        return r;
    }
}
