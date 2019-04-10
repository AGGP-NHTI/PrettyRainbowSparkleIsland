using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapp : MonoBehaviour
{
    public float timer;
    public float starttimer = 5.0f;

    int counter;
    // Start is called before the first frame update
    void Start()
    {
        timer = starttimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        counter = (int)Mathf.Ceil(timer);
        if(counter == 0)
        {
            gameObject.SetActive(false);
            timer = starttimer;
        }
    }
}
