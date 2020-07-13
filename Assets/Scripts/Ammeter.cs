using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electrical {
    public class Ammeter : MonoBehaviour
    {
        private float current, resistance;
        public Terminal pterm, nterm;

        public void setCurrent(float _current)
        {
            this.current = _current;
            GetComponent<AmmeterUI>().SetUI(_current);
        }

    }
}
