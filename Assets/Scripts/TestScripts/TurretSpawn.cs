/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());
        StartCoroutine(TurretPlacementAnimation());
    }

    

    public IEnumerator TurretPlacementAnimation()
    {
        audioSource.clip = MakeSubclip(audioSource.clip, 0.5f, 1f);
        audioSource.Play();
        while (transform.position.y < 0)
        {
            yield return new WaitForEndOfFrame();
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            position.y += 0.5f;
            transform.position = position;

        }
        yield return null;
    }

    public IEnumerator SpawnTimer()
    {
        gameObject.tag = "Turret_Spawn";
        yield return new WaitForSeconds(1);
        gameObject.tag = "Turret";
    }


    /// <summary>
    /// This method was not created by us. It is meant to chop audioclips at specific time stamps
    /// </summary>
    /// <param name="clip"></param>
    /// <param name="start"></param>
    /// <param name="stop"></param>
    /// <returns></returns>
    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 1, frequency, false);
        float[] data = new float[samplesLength];
        clip.GetData(data, (int)(frequency * start));
        newClip.SetData(data, 0);
        return newClip;
    }

}
