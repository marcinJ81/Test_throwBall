using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
   public sealed class SGlobalBpropertiesValue
    {
        private static SGlobalBpropertiesValue Single_Instance = null;
        public static SGlobalBpropertiesValue Instance
        {
            get
            {
                if (Single_Instance == null)
                {
                    Single_Instance = new SGlobalBpropertiesValue();
                }
                return Single_Instance;
            }
        }
        private SGlobalBpropertiesValue()
        {
            MIN_ANGLE = 1f;
            MAX_ANGLE = 90f;
            MIN_VELOCITY = 1f;
            MAX_VELOCITY = 100f;
        }
        public static float MIN_ANGLE { get; private set; }
        public static float MAX_ANGLE { get; private set; }
        public static float MIN_VELOCITY { get; private set; }
        public static float MAX_VELOCITY { get; private set; }
    }
}
