using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurrentDestroy : MonoBehaviour
{

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
