using UnityEngine;

namespace Electrical {
    public class NeedleRotation : MonoBehaviour
    {
        [Header("Device Parameters")]
        public double MinReadingValue, MaxreadingValue;
        double CurAngle; // Gives the current rotation value of the needle
        [Header("Needle Parameters")]
        public double MinAngle, MaxAngle;
        [Header("Prefab")]
        public GameObject Needle;
        float time =1, from, to;

        // will be used to pass new voltage value from voltage source
        public void NewReading(double _value)
        {
            if(_value > MaxAngle)
            {
                _value = MaxAngle;
            }
            else if (_value < MinAngle)
            {
                _value = MinAngle;
            }

            double NextRotationValue = MinAngle + (MaxAngle - MinAngle) * (_value - MinReadingValue) / (MaxreadingValue - MinReadingValue);

            from = (float) CurAngle;
            to = (float) NextRotationValue;
            time = 0;
        }
        public void update()
        {
            while(time < 0.99)
            {
                time += Time.deltaTime;
                CurAngle = Mathf.Lerp((float)from, (float)to, time);
                Needle.transform.eulerAngles = new Vector3(transform.eulerAngles.x, (float) CurAngle, transform.eulerAngles.z);
            }
        }
    }
}

