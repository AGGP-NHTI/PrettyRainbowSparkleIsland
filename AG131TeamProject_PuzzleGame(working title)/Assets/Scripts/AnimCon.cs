using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCon : MonoBehaviour
{
    bool state_idle;
    bool state_attack;
    bool state_block;
    bool state_powerattack;

    public Animator animn;



    public void Start()
    {
        animn = GetComponent<Animator>();
        animn.SetBool("state_idle", true);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animn.SetBool("state_idle", false);
            animn.SetBool("state_attack", true);

        }

       if (Input.GetKeyUp(KeyCode.Q))
        {
            animn.SetBool("state_idle", true);
            animn.SetBool("state_attack", false);

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            animn.SetBool("state_idle", false);
            animn.SetBool("state_block", true);

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            animn.SetBool("state_idle", true);
            animn.SetBool("state_block", false);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            animn.SetBool("state_idle", false);
            animn.SetBool("state_powerattack", true);

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            animn.SetBool("state_idle", true);
            animn.SetBool("state_powerattack", false);

        }

    }




}
