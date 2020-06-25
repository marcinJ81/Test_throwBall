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
    public GameObject InfoTextObject;
    // private IChangeVelocityAndAngle changeAngleVelocity;
    private StrategyForChangeAngleAndVelocity strategy;
    private TextMesh textMesh;
    private void Awake()
    {
        //changeAngleVelocity = new ChangeValueVelocityAndAngle();
        strategy = new StrategyForChangeAngleAndVelocity();
       
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
        if ((key == KeyCode.RightArrow || key == KeyCode.LeftArrow))
        {
            this.angle = strategy.StrategyTochange(key, this.angle);
        }
        if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
        {
            this.velocity = strategy.StrategyTochange(key, this.velocity);
        }
        ShowSpeedDistanceMassAboutBall(InfoTextObject.GetComponent(typeof(TextMesh)) as TextMesh);
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
    private void ShowSpeedDistanceMassAboutBall(TextMesh textmesh)
    {
        textmesh.text = "Angle : " + angle.ToString("n2");
        textmesh.text += "\nVelocity : " + velocity.ToString("n2");
    }

}
