﻿using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasAuthority)
        {
            return; //We don't want other people to be controlling us.
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Translate(Vector3.right * (int)(Input.GetAxis("Horizontal")));
        } else if (Input.GetButtonDown(("Vertical"))) //we don't want diagonal movement (?)
        {
            transform.Translate(Vector3.up * (int)(Input.GetAxis("Vertical")));
        }
    }
}
