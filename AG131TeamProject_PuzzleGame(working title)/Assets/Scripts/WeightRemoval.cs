using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightRemoval : MonoBehaviour
{
    public GameObject snow;
    public GameObject snowprefab;
    Transform start;
    // Start is called before the first frame update
    void Start()
    {
        start = snow.GetComponent<Transform>();
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
            Destroy(snow);
        }
        else
        {
            other.gameObject.AddComponent<Weight>();
            Instantiate(snow, start);
        }
    }
}
