/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{

    [SerializeField]public int Hitpoints = 5;


    [SerializeField] GameObject hanger1;
    [SerializeField] GameObject hanger2;
    [SerializeField] GameObject SatelliteDish;
    [SerializeField] GameObject Relay1;
    [SerializeField] GameObject Relay2;
    private List<GameObject> buildings;

    [SerializeField] Camera mainCamera;


    // Start is called before the first frame update
    void Start()
    {
        buildings = new List<GameObject>();
        buildings.Add(hanger1);
        buildings.Add(hanger2);
        buildings.Add(SatelliteDish);
        buildings.Add(Relay1);
        buildings.Add(Relay2);
    }



	private void OnTriggerEnter(Collider other)
	{
        Destroy(other.gameObject);
        Hitpoints--;
        if(Hitpoints <= 0)
		{
            Hitpoints = 0;
            StartCoroutine(DestroyBase());
		}
	}

    public IEnumerator DestroyBase()
    {
        //Get Camera to base
        mainCamera.transform.position = new Vector3(150, 100, -30);

        //Destroy each object
        foreach (GameObject building in buildings)
        {
            GameObject explosion = (GameObject)Resources.Load("Exploson1");
            Instantiate(explosion, building.transform.position, Quaternion.identity);
            Destroy(building);
            yield return new WaitForSeconds(1);
        }

        var script = GameObject.FindObjectOfType<GameScript>();
        script.EndGame();
        yield return null;
    }
}
