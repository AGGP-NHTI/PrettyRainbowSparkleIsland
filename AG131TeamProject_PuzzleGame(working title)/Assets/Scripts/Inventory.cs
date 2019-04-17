using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory;
    int index;
    public GameObject newitem;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ObtainedItem()
    {
        inventory.Capacity++;
        for(int i = 0; i < inventory.Capacity; i++)
        {
            if(index == inventory.Capacity -1)
            {
                inventory[i] = newitem;
            }
        }
    }
   
}
