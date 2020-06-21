using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
 
    public static class SKeyDetecion
    {
        /// <summary>
        /// https://stackoverflow.com/questions/12076107/how-to-detect-if-any-key-is-pressed
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<KeyCode> KeysDown()
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(key))
                    yield return key;
            }
        }
    }
}
