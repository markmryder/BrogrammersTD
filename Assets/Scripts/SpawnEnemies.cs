using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    //[SerializeField] public Node Start;
    //[SerializeField] public Node End;
    [SerializeField] Node SpawnLocation;
    [SerializeField] Node Destination;
    public bool isWaveTriggered;
    [SerializeField] GameObject Enemy;


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
            Vector3 position = SpawnLocation.transform.position;
            Instantiate(Enemy, position, Quaternion.identity);
            yield return new WaitForSeconds(3);
        }

        
	}

    public void TriggerWave()
	{
        isWaveTriggered = true;
	}
}
