using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0,4 * Time.deltaTime,0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0,-4 * Time.deltaTime,0);
        }
    }
}
