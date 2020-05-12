using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class SAngleToRadian
    {
        public static float AngleToRadian(float angle)
        {
            return Mathf.Deg2Rad * angle;
        }
    }
    public static class SCalculateVelocity
    {
        public static float CalculateVelocity(float distance, float gravity)
        {
            float result = 0.0f;
            result = Mathf.Sqrt(distance * gravity);
            return result;
        }
    }
    public static class SCalculateAngle
    {
        public static float CalculateAngle(float gravity, float distance, float velocity)
        {
            float result = 0.0f;
            result = 0.5f * Mathf.Asin(gravity * distance/velocity * velocity);
            return result;
        }
    }
}
