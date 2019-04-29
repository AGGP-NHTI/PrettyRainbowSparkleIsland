using System.Collections;
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
            if (hit.collider.CompareTag("Pickup"))
            {
                raycastedObject = hit.collider.gameObject;

                if (Input.GetButtonDown("Fire1"))
                {
                    Debug.Log("THIS WORKS (down)");
                    hit.transform.SendMessage("down");            

                } else if (Input.GetButtonUp("Fire1")) {
                    Debug.Log("THIS WORKS (UP)");
                    hit.transform.SendMessage("onUp");
                }
            }
        }
        else
        {
            //Default State
        }

    }
}
