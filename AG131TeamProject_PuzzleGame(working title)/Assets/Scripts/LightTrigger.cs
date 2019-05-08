using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrigger : MonoBehaviour
{
    GameObject flower;
    public Material flowerMat;
    // Update is called once per frame

    public void Start()
    {
        flower = gameObject;
        //flowerMat = flower.GetComponent<Renderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entered collider");
        if (other.transform.CompareTag("Player"))
        {
            //flowerMat.color.em
            flowerMat.EnableKeyword("_EMISSION");
        }

        //flowerlight.intensity = 20;
    }
    void OnTriggerExit(Collider other)
    {
        //flowerlight.intensity = 0;
        if (other.transform.CompareTag("Player"))
        {
            flowerMat.DisableKeyword("_EMISSION");
        }
  
    }
}
