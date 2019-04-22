using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Vector3 Close;
    public Vector3 Open;

    // Start is called before the first frame update
    void Start()
    {
        Close = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Opened()
    {
        gameObject.transform.position = Open;
    }
    public void Closed()
    {
        gameObject.transform.position = Close;
    }
}
