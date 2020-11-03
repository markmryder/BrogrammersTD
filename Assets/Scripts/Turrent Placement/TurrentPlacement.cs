using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TurrentPlacement : MonoBehaviour
{
    static public int totalTurret = 5;

    

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Floor" && totalTurret > 0)
            {
                GameObject turrent = (GameObject)Resources.Load("KenneyPrefabs/KenneyTurret2");
                Instantiate(turrent, transform.position, Quaternion.identity);
                totalTurret--;
            }
        }
    }

}
