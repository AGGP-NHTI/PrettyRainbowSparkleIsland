using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
   
    Vector3 SwitchLoacation;
    public Vector3 PushedLocation;

   public bool pressed = false;

    public delegate void PressDelegate();
    PressDelegate Press;

    // Start is called before the first frame update
    void Start()
    {
    
        SwitchLoacation = gameObject.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
     
        Weight w = other.GetComponentInParent<Weight>();
        if(w)
        {
            Pressed();
        }
    }
    public void Pressed()
    {
        pressed = true;
        gameObject.transform.position = PushedLocation;
    }
    public void NotPressed()
    {
        pressed = false;
        gameObject.transform.position = SwitchLoacation;
    }
}
