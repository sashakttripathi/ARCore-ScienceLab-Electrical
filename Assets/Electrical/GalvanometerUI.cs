using UnityEngine;
using TMPro;

namespace Electrical {

    public class GalvanometerUI : MonoBehaviour
    {
        public TextMeshProUGUI valuePlate;
        private Galvanometer galvanometerInstance;
        private Needle needle;
        public GameObject ARMain;
        public GameObject canvas;

        public float maxAngleMagnitude = 40f;
        public float maxCurrentMagnitude = 10f;


        private void Start()
        {
            galvanometerInstance = GetComponent<Galvanometer>();
            needle = FindObjectOfType<Needle>();
            needle.SetNeedle(0f);
        }

        void SetPlate(float current)
        {
            valuePlate.text = current.ToString() + 'A';
        }

        public void SetUI(float _current)
        {
            float current = (float) Mathf.Round(_current * 100f) /100f ;
            SetPlate(current);

            current = Mathf.Clamp(current, -maxCurrentMagnitude, maxCurrentMagnitude);
            float angle = (float) current/maxCurrentMagnitude * maxAngleMagnitude;
            needle.SetNeedle(angle);
        }

    }
}


