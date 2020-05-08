using Assets;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
  //  public GameObject ballObject;
    // Start is called before the first frame update
    private Vector3 ballStartPosition;
    public GameObject ballGameObject;
    private float Animation;

    private Rigidbody rb;
    private ThrowBall throwMethod = new ThrowBall();
    private Balistic_Calculation ballFly;

    int framesToSkip;
    // Start is called before the first frame update
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(20, 20f, 45f);
        framesToSkip = UnityEngine.Random.Range(0, 10);
    }
    void Start()
    {
       
        rb = ballGameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (framesToSkip > 0)
        //{
        //    framesToSkip--;
        //}
      //  else
      //  {
            rb.MovePosition(ballFly.CalculateArcOneVector(Time.deltaTime));

            Debug.Log("Position z=" + this.transform.position.z);
            framesToSkip = 10;

     //   }
            // Debug.Log("Position y=" + this.transform.position.y);
            //for (int i = 0; i <= throwMethod.resolution; i++)
            //{
            //    rb.MovePosition(throwMethod.CalculateArcArray()[i]);
            //}
   }

    
   
}
