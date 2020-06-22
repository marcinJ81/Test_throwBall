using Assets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Target_script : MonoBehaviour
{
    // Start is called before the first frame update
    public float angle { get; private set; }
    public float velocity { get; private set; }

    private IChangeVelocityAndAngle changeAngleVelocity;
    private void Awake()
    {
        changeAngleVelocity = new ChangeValueVelocityAndAngle();
    }
    void Start()
    {
        this.angle = 1.0f;
        this.velocity = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {

        KeyCode key = SKeyDetecion.KeysDown().Any() ? SKeyDetecion.KeysDown().First() : KeyCode.AltGr;

        this.angle  = changeAngleVelocity.WhenKeyPressChangeValueAngle(key, this.angle);
        this.velocity = changeAngleVelocity.WhenKeyPressChangeValueVelocity(key,this.velocity);
       
    }

    void changeValue()
    {
        //increase angle
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0, 4 * Time.deltaTime, 0);
            if (angle <= 89)
                this.angle += 1;
            Debug.Log("angle in script = " + angle.ToString());
        }
        //decrease angle
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(0, -4 * Time.deltaTime, 0);
            if (angle >= 1)
                this.angle -= 1;
            Debug.Log("angle in script = " + angle.ToString());
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            if (velocity >= 1)
                this.velocity -= 1;
            Debug.Log("velocity in script = " + velocity.ToString());
        }
        //increase velocity
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (velocity <= 100)
                this.velocity += 1;
            Debug.Log("velocity in script = " + velocity.ToString());
        }
    }

}
