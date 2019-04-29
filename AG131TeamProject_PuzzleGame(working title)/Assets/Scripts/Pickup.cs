﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //where the object getting pickup will attach to
    public Transform theDest;

    //used simply so that object picked up moves with player if being held
    private bool counter = false;

    //used for highlighting the object that you can interact with
    private Color startColor;

    public Color objColor;

    //used to determine the distance between player and object trying to pickup
    private float distanceDiffx;
    private float distanceDiffz;

    private void Start()
    {
        //Make obj NOT invisible
        objColor.a = 1;
    }

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

    //Gets called from raycast script on camera
    public void down()
    {
        //if statement here so that you can only pickup objects close enough to you
        if(distanceDiffx < 1 || distanceDiffz < 1)
        {
            counter = true;
            //Collide needs to stay active for raycast to work
            //GetComponent<BoxCollider>().enabled = false;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true; 
            this.transform.position = theDest.position;
            this.transform.parent = GameObject.Find("PlayerController").transform;
        }

    }

    //Gets called from raycast script on camera
    public void onUp()
    {
        counter = false;
        this.transform.parent = null;
        //GetComponent<BoxCollider>().enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    void OnMouseEnter()
    {
        startColor = this.GetComponent<Renderer>().material.color;
        GetComponent<Renderer>().material.color = objColor;
    }

    void OnMouseExit()
    {
        this.GetComponent<Renderer>().material.color = startColor;
    }

}
