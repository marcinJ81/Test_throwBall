using UnityEngine;
using System.Collections;
using Assets;

public class Balistic_Calculation
{
    public float velocity { get; set; }
    public float angle;
    public float radianAngle { get; set; }
    public float timeOfFly { get; set; }
    private float lengthpartOfTheDistance;
    private int distancePartNumber;
    private float g;
    private int resolution;
    private float maxDistance;

    private ICalculateDistanceAnTime maxdistanceFlyTime;
    public Balistic_Calculation()
    {
        g = Mathf.Abs(Physics2D.gravity.y);
        this.distancePartNumber = 1;
    }
    public Balistic_Calculation(ICalculateDistanceAnTime distanceAndtime, int resolution, float velocity, float angle)
        :this()
    {
        if ((resolution == 0) || (resolution < 0))
        {
            this.resolution = 10;
        }
        else
        {
            this.resolution = resolution;
        }
        this.angle = angle;
        this.velocity = velocity;
        this.maxdistanceFlyTime = distanceAndtime;
    }

    public Vector3 CalculateArcOneVector(float time, out float maxDistance )
    {
        Vector3 result;
       
        Debug.Log("distancePartNumber= " + distancePartNumber.ToString());
        float partOfRoad =  (float)distancePartNumber / resolution ;

        //how calculate resolution?
        Debug.Log("part of road= " + ((float)distancePartNumber / resolution).ToString());

        //convert angle to radian angle
        radianAngle = SConvertAngleToRadian.AngleToRadian(angle);

        //calculate the maximum distance
        maxDistance = maxdistanceFlyTime.MaxDistance(velocity, radianAngle, g);
        //Debug.Log("Distance= " + maxDistance.ToString());

        //calculate y in one part of road
        result = CalculateArcPoint(time, maxDistance, partOfRoad);
        distancePartNumber++;

        float timeFly = maxdistanceFlyTime.CalculateTimeOfFly(velocity, radianAngle, maxDistance);
        Debug.Log("timeFly= " + timeFly.ToString());
        Debug.Log("time= " + time.ToString());

        if (CalculateArcPoint(time, maxDistance, partOfRoad).z >= maxDistance)
        {
            Debug.Log("---End---");
            return new Vector3(0, 1, 0);       
        }
       
            Debug.Log("---Fly---");
            return result;
       
    }
   
    private Vector3 CalculateArcPoint(float t, float x, float amountDistance)
    {
        //s = V*t
       float s = t * x * amountDistance;
        
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) /
            (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
         Debug.Log("distance=" + s.ToString());
        // Debug.Log("wysokosc=" + y.ToString());
        return new Vector3(0, y, s);
    }

    
}
