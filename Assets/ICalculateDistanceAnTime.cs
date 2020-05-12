using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public interface ICalculateDistanceAnTime
    {
        float MaxDistance(float velocity, float radianAngle, float g);
        float CalculateTimeOfFly(float velocity, float radianangle, float maxdistance);
    }

    public class DistanceAndTime : ICalculateDistanceAnTime
    {
        public float CalculateTimeOfFly(float velocity, float radianangle, float maxdistance)
        {
            float timefly;
            timefly = maxdistance / velocity * Mathf.Cos(radianangle);
            return timefly;
        }

        public float MaxDistance(float velocity, float radianAngle, float g)
        {
            float result = 0f;
            result = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;
            return result;
        }
    }
}
