using UnityEngine;
using System.Collections;

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

    public Balistic_Calculation()
    {
        g = Mathf.Abs(Physics2D.gravity.y);
        this.distancePartNumber = 1;
    }
    public Balistic_Calculation(int resolution, float velocity, float angle)
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
    }
    public Vector3 CalculateArcOneVector()
    {
        Vector3 result;
        if (distancePartNumber == this.resolution)
        {
            return new Vector3(0,0, maxDistance);
        }
         Debug.Log("distancePartNumber= " + distancePartNumber.ToString());
        float partOfRoad = (float) distancePartNumber / resolution ;

        //convert angle to radina angle
        radianAngle = ConvertAngleToRadian(angle);

        //calculate the maximum distance
        maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
        Debug.Log("Distance= " + maxDistance.ToString());

        //calculate time of fly in one part of road
        timeOfFly = CalculateTimeOfFly(velocity, radianAngle, maxDistance);
        Debug.Log("Time of fly= " + timeOfFly.ToString());

        //calculate y in one part of road
        result = CalculateArcPoint(timeOfFly, maxDistance, partOfRoad);
        this.distancePartNumber++;
        return result;
    }
    public Vector3 CalculateArcOneVector(float time, out float maxDistance )
    {
        Vector3 result;
       
        Debug.Log("distancePartNumber= " + distancePartNumber.ToString());
        float partOfRoad =  (float)distancePartNumber / resolution ;

        //how calculate resolution?
        Debug.Log("part of road= " + ((float)distancePartNumber / resolution).ToString());

        //convert angle to radian angle
        radianAngle = ConvertAngleToRadian(angle);

        //calculate the maximum distance
        maxDistance = MaxDistance(velocity,radianAngle,g);
        //Debug.Log("Distance= " + maxDistance.ToString());

        //calculate y in one part of road
        result = CalculateArcPoint(time, maxDistance, partOfRoad);
        distancePartNumber++;

        float timeFly = CalculateTimeOfFly(velocity, radianAngle, maxDistance);
        Debug.Log("timeFly= " + timeFly.ToString());
        Debug.Log("time= " + time.ToString());

        if (CalculateArcPoint(time, maxDistance, partOfRoad).z >= maxDistance)
        {
            Debug.Log("---End---");
            return new Vector3(0, 0, 0);       
        }
        else
        {
            Debug.Log("---Fly---");
            return result;
        }
    }
    public float MaxDistance(float velocity, float radianAngle, float g)
    {
        float result = 0f;
        result = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
        return result;
    }
    public float ConvertAngleToRadian(float angle)
    {
        return Mathf.Deg2Rad * angle;
    }
   
    private Vector3 CalculateArcPoint(float t, float x, float amountDistance)
    {
        //s = V*t
       float s = t * x * amountDistance;
        
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) /
            (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
         Debug.Log("droga=" + s.ToString());
        // Debug.Log("wysokosc=" + y.ToString());
        return new Vector3(0, y, s);
    }

    public float CalculateTimeOfFly(float velocity, float radianangle, float maxdistance)
    {
        float timefly;
      //  Debug.Log("maxdistance in time method= " + maxdistance.ToString());
        timefly = maxdistance / velocity * Mathf.Cos(radianangle);
        //Debug.Log("velocity * Mathf.Cos(radianAngle) = " + (velocity * Mathf.Cos(radianangle)).ToString());
       // Debug.Log("timefly in method = " + timefly.ToString());
        return timefly;
    }
}
