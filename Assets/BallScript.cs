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
    // Start is called before the first frame update
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(10, 14f, 45f);
    }
    void Start()
    {
        rb = ballGameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(ballFly.CalculateArcOneVector(1));
        for (int i = 0; i <= throwMethod.resolution; i++)
        {
            rb.MovePosition(throwMethod.CalculateArcArray()[i]);
        }
    }

    
   
}
