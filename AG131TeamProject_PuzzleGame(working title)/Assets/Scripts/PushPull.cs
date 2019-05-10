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
    public Color objColor;

    private float OriginalSpeed;

    public void usePullPush()
    {        
            lockRot = true;
            this.transform.parent = GameObject.Find("PlayerController").transform;
            OriginalSpeed = GameObject.Find("PlayerController").GetComponent<Movement>().speed;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = 2.0f;
    }


    void OnCollisionEnter(Collision collision)
    {
        this.transform.parent = null;
    }

    public void pushPullUp()
    {
            lockRot = false;
            lockMove = false;
            this.transform.parent = null;
            GameObject.Find("PlayerController").GetComponent<Movement>().speed = 10.0f;
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