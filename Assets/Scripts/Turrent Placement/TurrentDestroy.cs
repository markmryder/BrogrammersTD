using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurrentDestroy : MonoBehaviour
{
    private List<GameObject> Floors;

    public GameObject turretFloor;

    void Start()
    {
        Floors = GameObject.FindGameObjectsWithTag("Floor_Delay").ToList<GameObject>();
        //turretFloor = Floors[0];
        foreach (GameObject currentFloor in Floors)
        {
            if (currentFloor.transform.position.x == gameObject.transform.position.x
                && currentFloor.transform.position.z == gameObject.transform.position.z)
            {
                turretFloor = currentFloor;
                break;
            }
        }
    }

    void OnMouseOver()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            //is on button or some UI element
            return;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            if (gameObject.tag == "Turret")
            {
                
                StartCoroutine(TurretDestroyAnimation());
                turretFloor.GetComponent<TurrentPlacement>().StartChangeColour();
                TurrentPlacement.totalTurret++;
            }
        }
    }


    public IEnumerator TurretDestroyAnimation()
    {
        while (transform.position.y > -20)
        {
            yield return new WaitForEndOfFrame();
            Vector3 position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            position.y -= 0.5f;
            transform.position = position;
        }
        Destroy(gameObject);
        yield return null;
    }
}
