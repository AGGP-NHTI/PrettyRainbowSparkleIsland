﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastTool : MonoBehaviour
{

    private GameObject raycastedObject;

    [SerializeField]
    private int rayLength = 10;

    //[SerializeField]
    //private LayerMask layerMaskInteract;

    //[SerializeField]
    //private TextMeshProUGUI uiCrossHair;

    //[SerializeField]
    //private TextMeshProUGUI uiDescriptor;

    void Start()
    {
        //uiCrossHair = CrossHairType.instance.GetComponent<TextMeshProUGUI>();
        //uiDescriptor = DescriptorType.instance.GetComponent<TextMeshProUGUI>();
        //uiDescriptor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength))
        {
            //LOOK FOR PICKUP TAGGED OBJECTS
            if (hit.collider.CompareTag("Pickup"))
            {
                raycastedObject = hit.collider.gameObject;
               
                if (Input.GetButtonDown("Fire1"))
                {
                    //Call down() in other objects pickup script
                    hit.transform.SendMessage("down");

                    //Check for gem type script on object
                    if (hit.transform.GetComponent<BlueGem>())
                    {
                        hit.transform.SendMessage("enableEffects");
                    } //add other gems with else if GreenGem etc...

                } else if (Input.GetButtonUp("Fire1")) {

                    //Call onUp() in other objects pickup script
                    hit.transform.SendMessage("onUp");

                    if (hit.transform.GetComponent<BlueGem>())
                    {
                        hit.transform.SendMessage("disableEffects");
                    }
                }
            }
        }
        else
        {
            //Default State
        }

    }
}