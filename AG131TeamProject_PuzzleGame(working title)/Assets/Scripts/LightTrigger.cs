using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    public GameObject flowerlight;
    // Update is called once per frame

    public void Start()
    {
        //flowerlight = gameObject.GetComponentInChildren<Light>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collider");
        flowerlight.SetActive(true);
    }
    void OnTriggerExit(Collider other)
    {
        flowerlight.SetActive(false);
    }
}
