using UnityEngine;

namespace Electrical {
    public class Resistor : MonoBehaviour
    {
        float current, resistance;
        public Terminal t1, t2;

        public float Current
        {
            set { this.current = value; }
            get { return this.current; }
        }

        public float getRes()
        {
            return this.resistance;
        }

        public void setres(float r)
        {
            this.resistance = r;
        }
    }
}