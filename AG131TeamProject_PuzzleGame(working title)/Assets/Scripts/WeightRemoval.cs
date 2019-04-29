using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRemoval : MonoBehaviour
{
    void start()
    {

    }

    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        Weight w = other.GetComponentInParent<Weight>();
        if (w)
        {
            Destroy(other.GetComponentInParent<Weigth>());

        }

        else
        {
            other.gameObject.AddComponent<Weight>();
        }
    }
}