using UnityEngine;
using UnityEngine.UI;

namespace Electrical {
    public class ResistanceBoxPinManager : MonoBehaviour
    {
        string tagname;
        Toggle _toggle;
        ResValue _resValue;

        void Start()
        {
            _toggle = this.gameObject.GetComponent<Toggle>();
        }

        GameObject returnRB()
        {
            GameObject[] rblist = GameObject.FindGameObjectsWithTag(tagname);
            foreach(var x in rblist)
            {
                if(x.name == this.gameObject.name && x != this.gameObject)
                {
                    return x;
                }
            }
            Debug.Log("RB reference was not found, returned null");
            return null;
        }

        public void manageResistance(string _tagname)
        {
            tagname = _tagname;
            GameObject rb = returnRB();

            if(_resValue == null)
            {
                _resValue = rb.GetComponent<ResValue>();
            }

            if(rb == null)
            {
                return;
            }

            if(_toggle.isOn)
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y + 1/27f, rb.transform.position.z);
            }
            else
            {
                rb.transform.position = new Vector3(rb.transform.position.x, rb.transform.position.y - 1/27f, rb.transform.position.z);
            }
            _resValue.setState();
        }
    }
}