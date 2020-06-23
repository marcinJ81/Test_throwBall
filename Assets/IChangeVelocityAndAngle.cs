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
    public class PropertiesToChange
    {
        private float privateAngle { get; set; }
        private float privateVelocity { get; set; }
        public float angle
        {
            get
            {
                return privateAngle;
            }
            set
            {
                if (AngleInfo == InfoChangeAngleORVelocity.angle_change)
                {
                    if ((angle <= SGlobalBpropertiesValue.MAX_ANGLE) && (angle >= SGlobalBpropertiesValue.MIN_ANGLE))
                    {
                        privateAngle = angle;
                    }
                }
            }
        }
        public float velocity
        {
            get
            {
                return privateVelocity;
            }
            set
            {
                if (VelocityInfo == InfoChangeAngleORVelocity.velocity_change)
                {
                    if ((velocity >= SGlobalBpropertiesValue.MIN_VELOCITY) && (velocity <= SGlobalBpropertiesValue.MAX_VELOCITY))
                    {
                        privateVelocity = velocity;
                    }
                }
            }
        }
        public InfoChangeAngleORVelocity AngleInfo { get; set; }
        public InfoChangeAngleORVelocity VelocityInfo { get; set; }

        public PropertiesToChange(float paramangle, float paramvelocity, InfoChangeAngleORVelocity paramInfoVelocity, InfoChangeAngleORVelocity paramInfoAngle)
        {
            this.angle = paramangle;
            this.velocity = paramvelocity;
            this.AngleInfo = paramInfoAngle;
            this.VelocityInfo = paramInfoVelocity;
        }
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
        public PropertiesToChange StrategyTochange(KeyCode key, PropertiesToChange propertiesToChange)
        {
            if (propertiesToChange.AngleInfo == InfoChangeAngleORVelocity.angle_change)
            {
                return new PropertiesToChange(ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, propertiesToChange.angle),
                    propertiesToChange.velocity, InfoChangeAngleORVelocity.angle_change, InfoChangeAngleORVelocity.no_change);
            }
            if (propertiesToChange.VelocityInfo == InfoChangeAngleORVelocity.velocity_change)
            {

                return new PropertiesToChange(propertiesToChange.angle,ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, propertiesToChange.velocity),
                     InfoChangeAngleORVelocity.no_change, InfoChangeAngleORVelocity.velocity_change);
            }

            return new PropertiesToChange(propertiesToChange.angle,propertiesToChange.velocity,
                InfoChangeAngleORVelocity.no_change, InfoChangeAngleORVelocity.no_change);
        }

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
