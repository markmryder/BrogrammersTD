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
