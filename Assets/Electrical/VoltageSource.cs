using UnityEngine;
using UnityEngine.UI;

namespace Electrical {
    public class VoltageSource : MonoBehaviour
    {
        float minVoltage = 0f, maxVoltage = 12f;
        private bool isActive = false;

        private float voltage;
        public Terminal tplus, tminus;

        public Text voltageTextDisplay;
        public Material offLightMaterial, onLightMaterial;
        private GameObject switchButton, switchBulb, knob;

        void Start()
        {
            switchButton = gameObject.transform.Find("switch").gameObject;
            switchBulb = gameObject.transform.Find("on_light_bulb").gameObject;
            knob = gameObject.transform.Find("knob_body").gameObject;

            voltage = minVoltage;
            tplus.setPol('+');
            tminus.setPol('-');

            if(!switchBulb || !switchButton || !knob || !voltageTextDisplay || !tplus || !tminus)
            {
                Debug.Log("Voltage Source Components: One of the components are not linked");
            }
        }

        public bool activeState()
        {
            return isActive;
        }

        public void setActiveState(bool state)
        {
            if(state)
            {
                isActive = true;
                switchButton.transform.Rotate(Vector3.forward*38f);
                switchButton.GetComponent<Renderer>().sharedMaterial = onLightMaterial;
                voltageTextDisplay.text = voltage.ToString();
                voltageTextDisplay.text = "ON";
            }

            else
            {
                isActive = false;
                switchButton.transform.Rotate(Vector3.forward*-38f);
                switchButton.GetComponent<Renderer>().sharedMaterial = offLightMaterial;
                // voltageTextDisplay.text = voltage.ToString();
                voltageTextDisplay.text = "OFF";

            }
        }

        public void setVoltage(float _voltage)
        {
            this.voltage = _voltage;
        }

        void updateVoltage()
        {
            float degreeToRotate = voltage*240/(maxVoltage-minVoltage);
            knob.transform.localRotation = Quaternion.Euler(0, 0, degreeToRotate-120f);
        }


    }
}