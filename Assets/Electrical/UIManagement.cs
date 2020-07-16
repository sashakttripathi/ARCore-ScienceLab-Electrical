using UnityEngine;
using UnityEngine.UI;

namespace Electrical{
    public class UIManagement : MonoBehaviour
    {
        GameObject toDisable;
        public SVGImage image;
        bool isOn = false;

        public GameObject VoltageSour;
        bool volOn = false;
        Needle needle;

        public void EnableMoveManager(string name)
        {
            GameObject.Find(name).GetComponent<MoveManager>().enabled = true;
        }

        public void DisableMoveManager(string name)
        {
            GameObject.Find(name).GetComponent<MoveManager>().enabled = false;
        }

        public void DisableArrows()
        {
            GameObject[] _apparatuses = GameObject.FindGameObjectsWithTag("Appratus");
            foreach(var x in _apparatuses)
            {
                x.GetComponent<TapUIManager>().enabled = true;
                x.GetComponentInChildren<Arrow>().gameObject.GetComponent<Renderer>().enabled = false;
            }
        }

        

    }
}