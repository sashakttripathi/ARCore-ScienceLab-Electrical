using UnityEngine;

namespace Electrical {
    public class Rheostat : MonoBehaviour
    {
        float minResistance = 0.5f, maxResistance = 12000f;
        private bool isActive = false; // Try printing differnent values for unassigned variables
        private float voltage, current, resistance;
        public Terminal t1, t2, t3;
        private GameObject wiper;

        public float Current
        {
            get{ return this.current; }
            set{ current = value; }
        }

        public void setVoltage(float _voltage)
        {
            this.voltage = _voltage;
        }

        public float getVoltage()
        {
            return this.voltage;
        }

        public void findResistance()
        {
            float x = wiper.transform.localPosition.x;
            resistance = minResistance + ((maxResistance-minResistance)/(-6f)) * (x -3f);
            Debug.Log("Resistance is:" + resistance.ToString());
        }

        public void setResistance(float _resistance)
        {
            this.resistance = _resistance;
        }

        public float getResistance()
        {
            findResistance();
            return resistance;
        } 

        public bool getActiveState()
        {
            return isActive;
        }

        public void setActiveState(bool state)
        {
            if(!isActive && state)
            {
                isActive = state;
                //updateRheostat();
            }

            else if (isActive && !state)
            {
                isActive = false;
            } 
        }

        void Start()
        {
            voltage = 0f;
            wiper = gameObject.transform.Find("wiper").gameObject;
            if(!t1 || !t2 || !t3 || !wiper)
            {
                Debug.Log("One of the terminals is not connected");
            }

            t1.setPol('n'); // There might be some error here due to wrong initialization
            t2.setPol('n');
            t3.setPol('n');
        }



    }
}
