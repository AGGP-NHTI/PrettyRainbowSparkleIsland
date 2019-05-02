using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public Light flowerlight;
    // Update is called once per frame

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collider");
        flowerlight.intensity = 20;
    }
    void OnTriggerExit(Collider other)
    {
        flowerlight.intensity = 0;
    }
}
