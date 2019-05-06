using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicKey : MonoBehaviour
{

    public GameObject Door;

    //Triggers everything that should happen
    public void enableEffects()
    {
        //Open door
        Door.GetComponent<Door>().requesttoopen = true;
    }

    //Revert all effected objects to previous state
    public void disableEffects()
    {
        //Close door
        Door.GetComponent<Door>().requesttoopen = false;
    }
}
