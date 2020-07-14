using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrical {
    public class connections : MonoBehaviour
    {
        public GameObject circuit;
        [SerializeField] GameObject wire; // A gameobject which will spawn in with rest of apparatus
        GameObject lr;
        [SerializeField] Text text1, text2;
        bool waitingForSecondObject = false; // boolean indicating that a second terminal needs to be selected in order to form a connection
        // after the first terminal has been selected
        GameObject firstObject, secondObject=null; // the 2 terminals the user is trying to connect

        void update()
        {
            if(Input.touchCount>0)
            {
                if(!waitingForSecondObject)
                {
                    RaycastHit hit;
                    if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit) && hit.collider.gameObject.tag == "Terminal" && (secondObject == null || hit.collider != secondObject.GetComponent<Collider>()))
                    {
                        firstObject = hit.collider.gameObject;
                        waitingForSecondObject = true;
                    }

                }

                if(waitingForSecondObject)
                {
                    RaycastHit hit;
                    if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit) && hit.collider.gameObject.tag == "Terminal" && hit.collider != firstObject.GetComponent<Collider>())
                    {
                        secondObject = hit.collider.gameObject;
                        waitingForSecondObject = false;
                        firstObject.GetComponent<Terminal>().setConnectTo(secondObject);
                        secondObject.GetComponent<Terminal>().setConnectTo(firstObject);
                        Debug.Log("First Object: {firstObject}\n Second Object: {secondObject}\n");

                    }
                }
            }
        }

        // This creates the visual connection using the line renderer between the chosen terminals
        public void ConnectTheTerminals(GameObject firstObject, GameObject secondObject)
        {
            lr = GameObject.Instantiate(wire, firstObject.transform.parent);
            lr.GetComponent<LineRenderer>().SetPosition(0,firstObject.transform.position);
            lr.GetComponent<LineRenderer>().SetPosition(1,secondObject.transform.position);
        } 
    }
}
