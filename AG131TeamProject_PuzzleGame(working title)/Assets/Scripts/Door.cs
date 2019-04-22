using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    Vector3 Close;
    public Vector3 Open;

   public bool requesttoopen = false;

    public delegate void DoorDelegate();
    DoorDelegate state;

    // Start is called before the first frame update
    void Start()
    {
        Close = gameObject.transform.position;
        state += Closed;
    }

    // Update is called once per frame
    void Update()
    {
        state.Invoke();
        if(requesttoopen)
        {
            state -= Closed;
            state += Opened;
            requesttoopen = false;
        }
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
