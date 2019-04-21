using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightButton : MonoBehaviour
{
    float press = 5f;
    float rise = 500f;
    public GameObject Door;
    Vector3 SwitchLoacation;
    Vector3 DoorLocation;

    public delegate void PressDelegate();
    PressDelegate Press;
    // Start is called before the first frame update
    void Start()
    {
        DoorLocation = Door.transform.position;
        SwitchLoacation = gameObject.transform.position;
        Press += NotPressed;
    }

    // Update is called once per frame
    void Update()
    {
        Press.Invoke();
    }
    private void OnTriggerEnter(Collider other)
    {
     
        Weight w = other.GetComponentInParent<Weight>();
        if(w)
        {
            Press -= NotPressed;
            Press += Pressed;
        }
    }
    void Pressed()
    {
        DoorLocation.y = (rise * Time.deltaTime * 1f);

        SwitchLoacation.y += (press * Time.deltaTime * -1f);

        gameObject.transform.position = SwitchLoacation;

        Door.transform.position = DoorLocation;
    }
    void NotPressed() { }
}
