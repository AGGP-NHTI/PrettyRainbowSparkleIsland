using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    //STILL BEING WORKED ON RIGHT NOW JUST IS PICKUP SCRIPT, plan on using similar approach to push/pull objects


    //locks moving/rotation in certain instances when pushing boxes
    public static bool lockRot = false;
    public static bool lockMove = false;

    //used for highlighting the object that you can interact with
    private Color startColor;

    //used to determine the distance between player and object trying to pickup
    private float distanceDiffx;
    private float distanceDiffz;

    private float OriginalSpeed;
    void Update()
    {
        //calculates distance between player and object trying to push, only x and z matter
        distanceDiffx = Mathf.Abs(this.transform.position.x - GameObject.Find("PlayerController").transform.position.x);
        distanceDiffz = Mathf.Abs(this.transform.position.z - GameObject.Find("PlayerController").transform.position.z);
    }
    void OnMouseDown()
    {
        //if statement here so that you can only push objects close enough to you
        if (distanceDiffx < .5 || distanceDiffz < .5)
        {
            Debug.Log("Sucks");
            lockRot = true;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = GameObject.Find("PlayerController").transform;
            OriginalSpeed = GameObject.Find("PlayerController").GetComponent<Movement>().speed;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = 2.0f;
        }
        Debug.Log("MouseDown");

    }


    void OnCollisionEnter(Collision collision)
    {
        this.transform.parent = null;
    }

    void OnMouseUp()
    {
        Debug.Log("MouseUp");
        if (distanceDiffx < 1 || distanceDiffz < 1)
        {
            lockRot = false;
            lockMove = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = OriginalSpeed;
        }

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