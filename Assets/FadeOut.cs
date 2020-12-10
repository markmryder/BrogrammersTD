/*
 Created by: Mark Ryder
 Contributions:
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    
    public float fadeOutTime;
    public Color originalColor;
    Text text;


    private void Start()
	{
        text = GetComponent<Text>();
        originalColor = text.color;
        gameObject.SetActive(false);
	}
	public void FadeTextOut()
    {
        //gameObject.SetActive(true);
        text.color = originalColor;
        StartCoroutine(FadeOutRoutine());
    }
    private IEnumerator FadeOutRoutine()
    {
       
        //Color originalColor = text.color;
        for (float t = 0.01f; t < fadeOutTime; t += Time.deltaTime)
        {
            text.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / fadeOutTime));
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
