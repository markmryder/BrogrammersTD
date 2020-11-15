using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpawn : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
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
            position.y += 1f;
            transform.position = position;

        }
        yield return null;
    }

    private AudioClip MakeSubclip(AudioClip clip, float start, float stop)
    {
        /* Create a new audio clip */
        int frequency = clip.frequency;
        float timeLength = stop - start;
        int samplesLength = (int)(frequency * timeLength);
        AudioClip newClip = AudioClip.Create(clip.name + "-sub", samplesLength, 1, frequency, false);
        /* Create a temporary buffer for the samples */
        float[] data = new float[samplesLength];
        /* Get the data from the original clip */
        clip.GetData(data, (int)(frequency * start));
        /* Transfer the data to the new clip */
        newClip.SetData(data, 0);
        /* Return the sub clip */
        return newClip;
    }

}
