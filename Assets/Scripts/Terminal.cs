using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Electrical {
    public class Terminal : MonoBehaviour
    {
        char polarity = 'n';
        bool traversed = false;
        public GameObject connectTo;
        public List<GameObject> connTo;

        public void setPol(char p)
        {
            polarity = 'p';
        }

        public char getPol()
        {
            return polarity;
        }

        public bool Traveresed
        {
            get
            {
                return traversed;
            }

            set
            {
                Traveresed = value;
            }
        }

        public void setConnectTo(GameObject obj)
        {
            this.connectTo = obj;
        }

        public int numberConnections()
        {
            return connTo.Count;
        }

        public GameObject connectedTo()
            {
                Debug.Log("connect to : " + connectTo);
                connectTo.GetComponent<Terminal>().traversed =true;
                return connectTo.transform.parent.gameObject;
            }
        
        public GameObject connectedTo(int index)
        {
            connTo[index].GetComponent<Terminal>().traversed = true;
            return connTo[index].transform.parent.gameObject;
        }
    }
}

