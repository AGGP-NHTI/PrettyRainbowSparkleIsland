using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRemoval : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Weight w = other.GetComponentInParent<Weight>();
        if(w)
        {
            Destroy(other.GetComponentInParent<Weight>());
        }
        else
        {
            other.gameObject.AddComponent<Weight>();
        }
    }
}
