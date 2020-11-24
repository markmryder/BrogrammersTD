using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TurrentPlacement : MonoBehaviour
{
    static public int totalTurret = 5;
    private GameObject turrent;

	public void Start()
	{
		//need to be able to disable in editor
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
                turrent = (GameObject)Resources.Load("KenneyPrefabs/KenneyTurret2");
                Vector3 position = new Vector3(transform.position.x, transform.position.y - 20, transform.position.z);
                Instantiate(turrent, position, Quaternion.identity);
                var smoke = (GameObject)Resources.Load("SmokeParticleSystem");
                Instantiate(smoke, transform.position, Quaternion.identity);
                print(transform.position);
                totalTurret--;
                StartCoroutine(PreventAnotherTurretPlacement());
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

}
