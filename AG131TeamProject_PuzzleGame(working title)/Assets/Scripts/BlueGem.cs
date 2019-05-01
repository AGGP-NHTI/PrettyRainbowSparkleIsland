using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{
    //Reference to all torch flames
    public List<GameObject> torches = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Triggers everything that should happen
    public void enableEffects()
    {
        //Light Torches
        foreach (GameObject torch in torches)
        {
            torch.GetComponent<ParticleSystem>().Play();
        }

        //Open door
    }

    //Revert all effected objects to previous state
    public void disableEffects()
    {
        //Put out torches
        foreach (GameObject torch in torches)
        {
            //torch.SetActive(false);
            torch.GetComponent<ParticleSystem>().Stop();
        }

        //Close door
    }
}
