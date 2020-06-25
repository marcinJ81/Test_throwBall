using UnityEngine;
using System.Collections;
using Assets;

public class Balistic_Calculation
{
    #region public fields
    public float velocity { get; set; }
    public float angle;
    public float radianAngle { get; set; }
    public float timeOfFly { get; set; }
    #endregion
    #region private fields
    private int distancePartNumber;
    private float g;
    private int resolution;
    private float maxDistance;
    private ICalculateDistanceAndTime maxdistanceFlyTime;
    private IFileIO savefiletodisk;
    #endregion
    #region constructors
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
    #endregion
    public Vector3 CalculateArcOneVector(float time, float angle, float velocity)
    {
        Vector3 result; 
        float partOfRoad = (float)distancePartNumber / resolution;
        radianAngle = SAngleToRadian.AngleToRadian(angle);
        maxDistance = maxdistanceFlyTime.MaxDistance(velocity, radianAngle, g);
        result = CalculateArcPoint(time, maxDistance, partOfRoad,velocity);
        distancePartNumber++;
        float timeFly = maxdistanceFlyTime.CalculateTimeOfFly(velocity, radianAngle, maxDistance);
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
        return new Vector3(0, y, s);
    }
}
