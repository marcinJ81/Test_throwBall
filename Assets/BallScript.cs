using Assets;
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
    private Vector3 targetPosition;
    bool flying = false;
    // Start is called before the first frame update
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(new DistanceAndTime(), 10, 22f, 45f);
      
    }
    void Start()
    {
        rb = ballGameObject.GetComponent<Rigidbody>();
        targetPosition = targetCircle.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.MovePosition(ballFly.CalculateArcOneVector(Time.deltaTime));
        }
        Vector3 distance = targetPosition - transform.position;
        //Debug.Log("distance ball -> target = " + distance.z.ToString());
    }  

}
