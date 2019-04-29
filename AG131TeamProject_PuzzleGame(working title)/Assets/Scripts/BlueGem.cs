using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{

    //Reference to all torch flames
    public List<GameObject> torches = new List<GameObject>();
    //bool debounce = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (GetComponent<Pickup>().counter && debounce == false)
        {
            debounce = true;
            enableEffects();
        }*/
    }

    //Triggers everything that should happen
    public void enableEffects()
    {
        //Light Torches
        foreach (GameObject torch in torches)
        {
            torch.SetActive(true);
        }

        //Open door
    }

    //Revert all effected objects to previous state
    public void disableEffects()
    {
        //Put out torches
        foreach (GameObject torch in torches)
        {
            torch.SetActive(false);
        }

        //Close door
    }
}
