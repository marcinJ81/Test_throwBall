﻿using Assets;
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

    bool flying = false;
    // Start is called before the first frame update
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(new DistanceAndTime(), 10, 22f, 45f);
       // framesToSkip = UnityEngine.Random.Range(0, 10);
    }
    void Start()
    {
       
        rb = ballGameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanceMax;
        
       
        if (Input.GetKey(KeyCode.Space))
        {
            rb.MovePosition(ballFly.CalculateArcOneVector(Time.deltaTime, out distanceMax));
        }


       
    }  
}
