using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public bool ShowCollisionEvents = false;
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision collision)
    {
        if (ShowCollisionEvents)
        {
            Debug.Log("Player OnCollisionEnter:" + collision.gameObject.name);
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (ShowCollisionEvents)
        {
            Debug.Log("Player OnCollisionExit:" + collision.gameObject.name);
        }
    }
     
    public void OnCollisionStay(Collision collision)
    {
        if (ShowCollisionEvents)
        {
            Debug.Log("Player OnCollisionStay:" + collision.gameObject.name);
        }
    }
}

   