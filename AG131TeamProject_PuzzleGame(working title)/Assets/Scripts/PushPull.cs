using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour
{
    //STILL BEING WORKED ON RIGHT NOW JUST IS PICKUP SCRIPT, plan on using similar approach to push/pull objects



    //used simply so that object picked up moves with player if being held
    private bool counter = false;

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
        //calculates distance between player and object trying to pickup, only x and z matter
        distanceDiffx = Mathf.Abs(this.transform.position.x - GameObject.Find("PlayerController").transform.position.x);
        distanceDiffz = Mathf.Abs(this.transform.position.z - GameObject.Find("PlayerController").transform.position.z);
    }
    void OnMouseDown()
    {
        //if statement here so that you can only pickup objects close enough to you
        if (distanceDiffx < 1.2 || distanceDiffz < 1.2)
        {
            lockRot = true;
            counter = true;
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.parent = GameObject.Find("PlayerController").transform;
            OriginalSpeed = GameObject.Find("PlayerController").GetComponent<Movement>().speed;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = 2.0f;

        }

    }


    void OnCollisionEnter(Collision collision)
    {
        this.transform.parent = null;
        if (Input.GetButton("Fire1"))
        {
            lockMove = true;
        }

    }

    void OnMouseUp()
    {
        lockRot = false;
        lockMove = false;
        counter = false;
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GameObject.Find("PlayerController").GetComponent<Movement>().speed = OriginalSpeed;

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