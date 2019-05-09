using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    GameObject flower;
    public Material defaultGlow, brightGlow;
    public GameObject pedals;
    // Update is called once per frame

    public void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collider");
        if (other.transform.CompareTag("Player"))
        {
            //flowerMat.color.em
            pedals.GetComponent<Renderer>().material = brightGlow;
        }

        //flowerlight.intensity = 20;
    }
    void OnTriggerExit(Collider other)
    {
        //flowerlight.intensity = 0;
        if (other.transform.CompareTag("Player"))
        {
            pedals.GetComponent<Renderer>().material = defaultGlow;
        }
  
    }
}
