using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
   public sealed class SGlobalBpropertiesValue
    {
        private static SGlobalBpropertiesValue Single_Instance = new SGlobalBpropertiesValue();

        public static SGlobalBpropertiesValue Instance
        {
            get
            {
                return Single_Instance;
            }
        }
        static  SGlobalBpropertiesValue()
        {
            MIN_ANGLE = 1f;
            MAX_ANGLE = 89f;
            MIN_VELOCITY = 1f;
            MAX_VELOCITY = 100f;
        }
        private SGlobalBpropertiesValue() { }

        public static float MIN_ANGLE { get; private set; }
        public static float MAX_ANGLE { get; private set; }
        public static float MIN_VELOCITY { get; private set; }
        public static float MAX_VELOCITY { get; private set; }
    }
}
