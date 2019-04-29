using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject ButtonOne;
    public GameObject ButtonTwo;
    public GameObject ButtonThree;
    public GameObject ButtonFour;

    public GameObject door;

    public bool Multibutton = false;

    WeightButton first;
    WeightButton second;
    WeightButton third;
    WeightButton fourth;

    Door D;

    // Start is called before the first frame update
    void Start()
    {
         first = ButtonOne.GetComponent<WeightButton>();
        if(Multibutton)
        {
            second = ButtonTwo.GetComponent<WeightButton>();
            third = ButtonThree.GetComponent<WeightButton>();
            fourth = ButtonFour.GetComponent<WeightButton>();
        }
       

         D = door.GetComponent<Door>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Multibutton)
        {
            if(first.pressed == true)
            {
                D.requesttoopen = true;
            }
        }
        else
        {
            if(second.pressed == true && first.pressed == false)
            {
                second.NotPressed();
            }
            else if(third.pressed == true && second.pressed == false)
            {
                third.NotPressed();
            }
            else if(fourth.pressed == true && third.pressed == false)
            {
                fourth.NotPressed();
            }
            else if(first.pressed == true && second.pressed == true && third.pressed == true && fourth.pressed == true)
            {
                D.requesttoopen = true;
            }
        }
    }
}
