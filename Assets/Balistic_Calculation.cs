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

    private ICalculateDistanceAndTime maxdistanceFlyTime;
    private IFileIO savefiletodisk;
    public Balistic_Calculation()
    {
        g = Mathf.Abs(Physics2D.gravity.y);
        this.distancePartNumber = 1;
        this.savefiletodisk = new FileIO();
    }
    public Balistic_Calculation(ICalculateDistanceAndTime distanceAndtime, int resolution)
        : this()
    {
        if ((resolution == 0) || (resolution < 0))
        {
            this.resolution = 10;
        }
        else
        {
            this.resolution = resolution;
        }
        this.maxdistanceFlyTime = distanceAndtime;
    }
    public Balistic_Calculation(ICalculateDistanceAndTime distanceAndtime, int resolution, float velocity, float angle)
        :this(distanceAndtime,resolution)
    {
        this.angle = angle;
        this.velocity = velocity;
    }

    public Vector3 CalculateArcOneVector(float time, float angle, float velocity)
    {
        Vector3 result;

        Debug.Log("distancePartNumber= " + distancePartNumber.ToString());
        float partOfRoad = (float)distancePartNumber / resolution;
        radianAngle = SAngleToRadian.AngleToRadian(angle);
        maxDistance = maxdistanceFlyTime.MaxDistance(velocity, radianAngle, g);
        result = CalculateArcPoint(time, maxDistance, partOfRoad);
        distancePartNumber++;
        float timeFly = maxdistanceFlyTime.CalculateTimeOfFly(velocity, radianAngle, maxDistance);
        Debug.Log("timeFly= " + timeFly.ToString());
        Debug.Log("time= " + time.ToString());

        if (CalculateArcPoint(time, maxDistance, partOfRoad,velocity).z >= maxDistance)
        {
            return new Vector3(0, 1, 0);
        }
        return result;
    }
    private Vector3 CalculateArcPoint(float t, float x, float amountDistance,float velocity)
    {
        float s = t * x * amountDistance;
        savefiletodisk.writeFileToDisc(s.ToString());
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) /
            (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
       // savefiletodisk.writeFileToDisc(y.ToString());
        Debug.Log("distance=" + s.ToString());
        return new Vector3(0, y, s);
    }
    public Vector3 CalculateArcOneVector(float time)
    {
        Vector3 result;
       
        Debug.Log("distancePartNumber= " + distancePartNumber.ToString());
        float partOfRoad =  (float)distancePartNumber / resolution ;

        //how i can calculate resolution?
       //  Debug.Log("part of road= " + ((float)distancePartNumber / resolution).ToString());

        //convert angle to radian angle
        radianAngle = SAngleToRadian.AngleToRadian(angle);

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
        savefiletodisk.writeFileToDisc(s.ToString());
        float y = s * Mathf.Tan(radianAngle) - ((g * s * s) /
            (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        savefiletodisk.writeFileToDisc(y.ToString());
        Debug.Log("distance=" + s.ToString());
        return new Vector3(0, y, s);
    }

    
}
