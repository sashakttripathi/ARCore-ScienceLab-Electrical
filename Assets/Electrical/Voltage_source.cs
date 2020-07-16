using UnityEngine;

namespace Electrical {
    public class Voltage_source : MonoBehaviour 
    {
        bool isOn;
        float volt =2;
        public Terminal tplus, tminus;

        public float getVolt()
        {
            return volt;
        }

        public  void Start()
        {
            tplus.setPol('+');
            tminus.setPol('-');
        }

        public void turnOn()
        {
            isOn = true;
        }

        public void turnoff()
        {
            isOn = false;
        }

    }
}