﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    //Declare Variables
    Vector2 mouseLook;
    Vector2 smoothV;
    public float sensitivity = 3.0f;
    public float smoothing = 1.0f;
    GameObject character;

    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;

        //On start hide and lock cursor position
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //Get current mouse pos
        Vector2 md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

        //Apply smoothing
        md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
        smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
        mouseLook += smoothV;

        //Locks ability to look past stright up and down
        mouseLook.y = Mathf.Clamp(mouseLook.y, -90f, 90f);

        //Rotate camera up/down
        transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

        //Use character body for left/right rotation
        character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
    }
}

