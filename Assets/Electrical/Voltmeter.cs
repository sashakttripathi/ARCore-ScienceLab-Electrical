using UnityEngine;

namespace Electrical {
    public class Voltmeter : MonoBehaviour
    {
        private float voltage;
        public Terminal pterm, nterm;

        public void SetVoltage(float _voltage)
        {
            this.voltage = _voltage;
            GetComponent<VoltmeterUI>().SetUI(_voltage);
        }

        public float GetVoltage()
        {
            return this.voltage;
        }

        private void Start()
        {
            initilializeTerminals();
        }

        public void initilializeTerminals()
        {
            pterm.setPol('p');
            nterm.setPol('n');
        }


    }
}