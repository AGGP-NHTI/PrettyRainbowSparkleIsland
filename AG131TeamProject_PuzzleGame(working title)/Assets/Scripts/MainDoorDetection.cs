using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorDetection : MonoBehaviour
{
    //Door to grab script from
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Pickup"))
        {
            door.GetComponent<Door>().requesttoopen = true;
           // other.GetComponent<BlueGem>
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Pickup"))
        {
            door.GetComponent<Door>().requesttoopen = false;
        }
    }
}
