using UnityEngine;
using UnityEngine.UI;

namespace Electrical{
    public class JockeyManager : MonoBehaviour
    {
        private GameObject Jockey;

        public void ChangeValue(Slider slider)
        {
            if(Jockey == null)
            {
                Jockey = GameObject.Find("Jockey");
            }

            float v = slider.value;
            v = v * 4.6f;
            v = v - 2.3f;

            Vector3 pos = Jockey.transform.localPosition;
            pos.z = v;
            Jockey.transform.localPosition = pos;
        }
    }
}



