using Assets;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    #region public fields
    public GameObject ballGameObject;
    #endregion
    #region private fields 
    private Vector3 ballStartPosition;
    private Rigidbody rb;
    private Balistic_Calculation ballFly;
    private Target_script targetScript;
    #endregion
    private void Awake()
    {
        ballGameObject = GameObject.Find("Sphere");
        ballStartPosition = ballGameObject.transform.position;
        ballFly = new Balistic_Calculation(new DistanceAndTime(), 20);
    }
    void Start()
    {
        rb = ballGameObject.GetComponent<Rigidbody>();
        targetScript = FindObjectOfType(typeof(Target_script)) as Target_script;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.MovePosition(ballFly.CalculateArcOneVector(Time.deltaTime, targetScript.angle,targetScript.velocity));
        }
    }  

}
