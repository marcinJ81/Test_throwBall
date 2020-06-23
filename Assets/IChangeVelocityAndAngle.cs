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
        angle,
        velocity,
        empty
    }
    public class PropertiesToChange
    {
        private float privateAngle { get; set; }
        public float angle
        {
            get
            {
                return privateAngle;
            }
            set
            {
                if (info == InfoChangeAngleORVelocity.angle)
                {
                    if ((angle <= 89) && (angle >= 1))
                    {
                        privateAngle = angle;
                    }
                }
            }
        }
        public float velocity { get; set; }
        public InfoChangeAngleORVelocity info { get; set; }
    }
    public class StrategyForChangeAngleAndVelocity
    {
        //private PropertyInfo[] propertyInfos;
        //public StrategyForChangeAngleAndVelocity(Target_script target_Script)
        //{
        //    propertyInfos = typeof(Target_script).GetProperties(BindingFlags.Public);

        //}

        private IChangeVelocityAndAngle ichangeVelocityAngle;
        public StrategyForChangeAngleAndVelocity()
        {
            this.ichangeVelocityAngle = new ChangeValueVelocityAndAngle();
        }
        public  float StrategyTochange(KeyCode key, float valueToChange)
        {
            if (key == KeyCode.RightArrow || key == KeyCode.LeftArrow)
            {
                return ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, valueToChange);
                
            }
            if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
            {
               
               return  ichangeVelocityAngle.WhenKeyPressChangeValueVelocity(key, valueToChange);
               
            }
            return valueToChange;
        }
        public Dictionary<float,float> StrategyTochange(KeyCode key, Dictionary<float, float> valueToChange)
        {
            
            if (key == KeyCode.RightArrow || key == KeyCode.LeftArrow)
            {
                return ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, valueToChange);

            }
            if (key == KeyCode.DownArrow || key == KeyCode.UpArrow)
            {

                return ichangeVelocityAngle.WhenKeyPressChangeValueVelocity(key, valueToChange);

            }

            return valueToChange;
        }

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
