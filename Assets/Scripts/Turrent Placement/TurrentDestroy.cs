using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentDestroy : MonoBehaviour
{

    void OnMouseOver()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Turret")
            {
                Destroy(gameObject);
                TurrentPlacement.totalTurret++;
            }
        }
    }

}
