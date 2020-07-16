using UnityEngine;
using UnityEngine.UI;

namespace Electrical {
    public class RheostatWiper : MonoBehaviour
    {
        public Rheostat rheostat;
        public Slider rheostatSlider;

        void Start()
        {
            rheostatSlider = GameObject.FindGameObjectWithTag("rheostatSlider").GetComponent<Slider>();
        }

        void FixedUpdate()
        {
            float v = rheostatSlider.value * 6;
            Vector3 pos  = transform.localPosition;
            transform.localPosition = new Vector3(3f-v, pos.y, pos.z);
            rheostat.findResistance(); // Decreases the performance of the application. Use callback instead.
        }
    }
}
