using UnityEngine;

namespace Electrical {
    public class Needle : MonoBehaviour
    {
        public void SetNeedle(float angle)
        {
            transform.SetPositionAndRotation(transform.position, Quaternion.Euler(0f, 0f, -angle));
        }       
    }

}