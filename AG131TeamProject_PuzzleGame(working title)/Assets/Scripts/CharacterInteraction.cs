using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    bool interaction = false;
    Inventory inv;
    GameObject trnsl;

 
    float Check = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        inv = gameObject.GetComponentInChildren<Inventory>();
        trnsl = inv.inventory[0];
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
