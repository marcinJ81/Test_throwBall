using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public class StrategyForChangeAngleAndVelocity
    {

    }
   public interface IChangeVelocityAndAngle
    {
       float  WhenKeyPressChangeValueAngle(KeyCode key, float angle);
       float  WhenKeyPressChangeValueVelocity(KeyCode key, float velocity);
    }

    public class ChangeValueVelocityAndAngle : IChangeVelocityAndAngle
    {
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
