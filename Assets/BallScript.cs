﻿using Assets;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //  public GameObject ballObject;
    // Start is called before the first frame update
    public GameObject targetCircle;
    public GameObject ballGameObject;

    private float Animation;
    private Vector3 ballStartPosition;
    private Rigidbody rb;
    private ThrowBall throwMethod = new ThrowBall();
    private Balistic_Calculation ballFly;
    bool flying = false;
    // Start is called before the first frame update
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(new DistanceAndTime(), 10, 45f, 45f);
    }
    void Start()
    {
        rb = ballGameObject.GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //finally hir set angle and velocity and resolution
            rb.MovePosition(ballFly.CalculateArcOneVector(Time.deltaTime));
        }
        
        //Debug.Log("distance ball -> target = " + distance.z.ToString());
    }  

}
