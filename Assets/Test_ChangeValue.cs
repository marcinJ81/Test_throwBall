using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
  public class Test_ChangeValue
    {
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
        public float StrategyTochange(KeyCode key, float valueToChange)
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
        public PropertiesToChange StrategyTochange(KeyCode key, PropertiesToChange propertiesToChange)
        {
            if (propertiesToChange.AngleInfo == InfoChangeAngleORVelocity.angle_change)
            {
                return new PropertiesToChange(ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, propertiesToChange.angle),
                    propertiesToChange.velocity, InfoChangeAngleORVelocity.angle_change, InfoChangeAngleORVelocity.no_change);
            }
            if (propertiesToChange.VelocityInfo == InfoChangeAngleORVelocity.velocity_change)
            {

                return new PropertiesToChange(propertiesToChange.angle, ichangeVelocityAngle.WhenKeyPressChangeValueAngle(key, propertiesToChange.velocity),
                     InfoChangeAngleORVelocity.no_change, InfoChangeAngleORVelocity.velocity_change);
            }

            return new PropertiesToChange(propertiesToChange.angle, propertiesToChange.velocity,
                InfoChangeAngleORVelocity.no_change, InfoChangeAngleORVelocity.no_change);
        }

    }
}
