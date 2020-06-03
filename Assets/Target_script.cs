﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_script : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle { get; private set; }
    public float velocity { get; private set; }
    void Start()
    {
        this.angle = 1.0f;
        this.velocity = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //increase angle
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0,4 * Time.deltaTime,0);
            if(angle <=  89)
                this.angle += 1;
            Debug.Log("angle in script = " + angle.ToString());
        }
        //decrease angle
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0,-4 * Time.deltaTime,0);
            if(angle >= 1)
                this.angle -= 1;
            Debug.Log("angle in script = " + angle.ToString());
        }
    }


}