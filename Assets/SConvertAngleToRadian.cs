using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public static class SConvertAngleToRadian
    {
        public static float AngleToRadian(float angle)
        {
            return Mathf.Deg2Rad * angle;
        }
    }
}
