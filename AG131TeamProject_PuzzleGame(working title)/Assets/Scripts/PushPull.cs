using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    //STILL BEING WORKED ON RIGHT NOW JUST IS PICKUP SCRIPT, plan on using similar approach to push/pull objects

 
    //where the object getting pickup will attach to
    public Transform theDest;

    //used simply so that object picked up moves with player if being held
    private bool counter = false;

    //used for highlighting the object that you can interact with
    private Color startColor;

    //used to determine the distance between player and object trying to pickup
    private float distanceDiffx;
    private float distanceDiffz;

    void Update()
    {
        //calculates distance between player and object trying to pickup, only x and z matter
        distanceDiffx = Mathf.Abs(this.transform.position.x - theDest.position.x);
        distanceDiffz = Mathf.Abs(this.transform.position.z - theDest.position.z);

        if (counter == true)
        {
            this.transform.position = theDest.position;
        }
    }
    void OnMouseDown()
    {
        //if statement here so that you can only pickup objects close enough to you
        if (distanceDiffx < 1 || distanceDiffz < 1)
        {
            counter = true;
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("PlayerController").transform;
        }

    }
    void OnMouseUp()
    {
        counter = false;
        this.transform.parent = null;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;

    }
    void OnMouseEnter()
    {
        startColor = this.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = startColor;
    }
}
