using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{

    //locks moving/rotation in certain instances when pushing boxes
    public static bool lockRot = false;
    public static bool lockMove = false;

    //used for highlighting the object that you can interact with
    private Color startColor;

    //used to determine the distance between player and object trying to pickup
    private float distanceDiffx;
    private float distanceDiffz;

    private float OriginalSpeed;

    public void usePullPush()
    {
        //if statement here so that you can only push objects close enough to you
        //if (RaycastTool.PushPullRange == true)
        //{
            lockRot = true;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = GameObject.Find("PlayerController").transform;
            OriginalSpeed = GameObject.Find("PlayerController").GetComponent<Movement>().speed;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = 2.0f;
        //}

    }


    void OnCollisionEnter(Collision collision)
    {
        this.transform.parent = null;
    }

    public void pushPullUp()
    {
        //if (RaycastTool.PushPullRange == true)
        //{
            lockRot = false;
            lockMove = false;
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = OriginalSpeed;
        //}

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