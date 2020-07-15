using UnityEngine;

namespace Electrical {

    public class Galvanometer : MonoBehaviour
    {
        private float current;
        public Terminal pterm, nterm;

        public void SetCurrent(float _current)
        {
            this.current = _current;
            GetComponent<GalvanometerUI>().SetUI(current);
        }

        public float GetCurrent()
        {
            return this.current;
        }

        private void Start()
        {
            initializeTerminal();
        }

        private void initializeTerminal()
        {
            pterm.setPol('p');
            nterm.setPol('n');
        }
    }

}
