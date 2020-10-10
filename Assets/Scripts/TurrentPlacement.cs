using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using UnityEngine;

public class TurrentPlacement : MonoBehaviour
{
    [SerializeField] int totalTurrent = 50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.transform.name);
                print(hit.point);
                if (hit.transform.name == "Top")
                {
                    if (totalTurrent > 0)
                    {
                        GameObject turrent = (GameObject)Resources.Load("Turret");
                        Instantiate(turrent);
                        Vector3 position = hit.point;
                        turrent.transform.position = position;
                        totalTurrent--;
                    }
                }
                if (hit.transform.name == "Head")
                {
                    Destroy(hit.transform.gameObject);
                    totalTurrent++;
                    
                }
            }
        }
    }
}
