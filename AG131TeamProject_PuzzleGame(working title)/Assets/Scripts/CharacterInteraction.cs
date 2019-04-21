using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    GameObject trnsl;
    // Start is called before the first frame update
    void Start()
    {
        trnsl = gameObject.GetComponentInChildren<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Dialouge d = other.GetComponentInParent<Dialouge>();
        if(d)
        {
            if(trnsl)
            {
                d.Translated();
            }
            else
            {
                d.Untranslated();
            }
        }
    }
}
