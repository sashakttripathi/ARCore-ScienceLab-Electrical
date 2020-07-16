using UnityEngine;
using TMPro;

namespace Electrical {
    public class VoltmeterUI : MonoBehaviour
    {
        public TextMeshProUGUI valuePlate;
        private Voltmeter voltmeterInstance;
        private Needle needle;
        public GameObject ARMain;
        public GameObject canvas;

        public float maxAngleMagnitude = 40f;
        public float maxVoltageMagnitude = 40f;

        private void Start()
        {
            voltmeterInstance = GetComponent<Voltmeter>();
            needle = FindObjectOfType<Needle>();
            needle.SetNeedle(40f);
        }

        void SetPlate(float _voltage)
        {
            valuePlate.text = _voltage.ToString() + "V";
        }

        public void SetUI(float _voltage)
        {
            float voltage = (float) Mathf.Round(_voltage * 100) / 100;
            SetPlate(voltage);
            voltage = Mathf.Clamp(voltage, -maxVoltageMagnitude, maxVoltageMagnitude);
            float angle = voltage/(maxVoltageMagnitude) * maxAngleMagnitude * 2f - maxVoltageMagnitude;
            needle.SetNeedle(angle); 

        }

    }
}