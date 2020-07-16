using UnityEngine;


namespace Electrical{
    public class Ammeter : MonoBehaviour
    {
        private float current, resistance; // The 2 properties of an ammeter
        public Terminal pterm, nterm; //The 2 terminals of an ammeter

        public void Start()
        {
            initializeterminals();
        }

        public void setCurrent(float _current)
        {
            this.current = _current;
            GetComponent<AmmeterUI>().SetUI(_current);
        }

        public float getCurrent()
        {
            return current;
        }

        public void initializeterminals()
        {
            pterm.setPol('p');
            nterm.setPol('n');
        }

        public float Current //Another variable defined for current
        {
            get {return current; }
            set {this.current = value; }
        }

        public float getRes()
        {
            return resistance;
        }

        public int calculateCurrent() //Dont know why
        {
            return 0;
        }

    }

}



