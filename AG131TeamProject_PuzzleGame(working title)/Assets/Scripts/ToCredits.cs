﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToCredits : MonoBehaviour
{
    string credits = "Credits";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    private void OnTriggerEnter(Collider other)
    {
        Movement m = other.GetComponentInParent<Movement>();
        if (m)
        {
            SceneManager.LoadScene(credits);
        }
    }
}
