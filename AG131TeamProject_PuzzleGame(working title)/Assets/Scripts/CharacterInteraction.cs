using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    bool interaction = false;
    Inventory inv;
    GameObject trnsl;

    public GameObject Eyes;
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
        DrawDebugRay();
        if(interaction)
        {
            GetInteraction();
        }
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
    void GetInteraction()
    {
        interaction = Input.GetKeyDown("Interaction");
    }
    void Seek()
    {
        Ray see = new Ray();

        
        see.direction = Eyes.transform.forward;

        RaycastHit hit;

        bool hashit = Physics.Raycast(see, out hit, Check);
        if(hashit)
        {
            Dialouge d = hit.collider.gameObject.GetComponentInParent<Dialouge>();
            if(d)
            {
                d.Translated();
            }
        }
    }
    public void DrawDebugRay()
    {
        float drawLength = Check;
        Vector3 origin = Eyes.transform.position;
        Vector3 direction = origin + (Eyes.transform.forward * Check);
        Color drawColor = Color.red;
        Debug.DrawRay(origin, direction, drawColor);

    }
}
