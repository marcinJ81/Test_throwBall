using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.Reflection;

namespace Assets
{
    public enum InfoChangeAngleORVelocity
    {
        angle_change,
        velocity_change,
        no_change
    }
    
   public interface IChangeVelocityAndAngle
    {
       float  WhenKeyPressChangeValueAngle(KeyCode key, float angle);
       float  WhenKeyPressChangeValueVelocity(KeyCode key, float velocity);
       float WhenKeyPressChangeValue(KeyCode key, float valueToChange); 
    }

    public class ChangeValueVelocityAndAngle : IChangeVelocityAndAngle
    {
        public float WhenKeyPressChangeValue(KeyCode key, float valueToChange)
        {
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))
            {
                   return valueToChange += 1;
            }
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                    return valueToChange -= 1;
            }
            return valueToChange;
        }

        public float WhenKeyPressChangeValueAngle(KeyCode key, float angle)
        {          
            if (Input.GetKey(KeyCode.RightArrow))
            {
               
                if (angle <= 89)
                {
                   angle += 1;
                    return angle;
                }
            }
            //decrease angle
            if (Input.GetKey(KeyCode.LeftArrow))
            {
               
                if (angle >= 1)
                {
                   angle -= 1;
                    return angle;
                }
            }
            return angle;
        }

        public float WhenKeyPressChangeValueVelocity(KeyCode key,  float velocity)
        {
            
            //decrease velocity
            if (Input.GetKey(KeyCode.DownArrow))
            {
                if (velocity >= 1)
                {
                    velocity -= 1;
                    return velocity;
                }
            }
            //increase velocity
            if (Input.GetKey(KeyCode.UpArrow))
            {
                if (velocity <= 100)
                {
                    velocity += 1;
                    return velocity;
                }
            }
            return velocity;
        }
    }
}
