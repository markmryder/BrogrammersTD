/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] Node SpawnLocation;
    [SerializeField] Node Destination;
    public bool isWaveTriggered;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject Enemy2;


    // Start is called before the first frame update
    void Start()
    {
        TriggerWave();
        StartCoroutine(StartSpawn());
    }



    // Update is called once per frame
    void Update()
    {
        
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

    public void TriggerWave()
	{
        isWaveTriggered = true;
	}
}
