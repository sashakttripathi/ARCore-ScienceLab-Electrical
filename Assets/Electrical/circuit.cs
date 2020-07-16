using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Electrical {
    public class circuit : MonoBehaviour
    {
        [SerializeField]Text text, text1, text2;
        // public GameObject canvas1, canvas2, close_connection, stop_circuit; // Buttons
        public GameObject planeDetection; // for detecting the plane

        List<GameObject> comps; // contains all the components present in the scene
        List<components> incircuit; //contains the list of all components present in the circuit
        bool isCircuitConnected = false; 
        int isCurrentFlowing = 0;
        float toatalRes = 0, current = 0;
        [SerializeField]GameObject connections; // Connections object is attached here
        GameObject VoltageSource = null;

        Ammeter _ammter;
        VoltageSource _volatgesource;
        Voltmeter _voltmeter;
        Rheostat _rheostat;
        TouchApparatus _plugkey;
        MeterBridge _meterBridge;
        Resistance_Box _resistanceBox;
        Galvanometer _galvanometer;

        NeedleRotation needle;
        public bool isMoving = true;
        private bool isVoltageSourceOn = false, isConnectionOn = false;

        public void Start()
        {
            planeDetection.SetActive(false);
            incircuit = new List<components>();
        }

        public void Update()
        {
            // Currently Empty
        }

        void startPlaceObjects()
        {
            planeDetection.SetActive(true);
        }

        void stopPlaceObjects()
        {
            planeDetection.SetActive(false);
        }

        void setVoltageSource(GameObject vs)
        {
            VoltageSource = vs;
        }

        public void stopConnections()
            {
                connections.SetActive(false);
            }
        
        public void makeConnection()
        {
            isConnectionOn = !isConnectionOn;
            if(!isConnectionOn)
            {
                stopConnections();
                return;
            }
            isMoving = false;
            connections.SetActive(true);
        }

        void setInCircuit(float _current)
        {
            text1.text = "Starting Switch";
            if(_ammter != null)
            {
                _ammter.Current = _current;
                _ammter.setCurrent(_current);
                Debug.Log("Ammeter current value: " + _current);
            }

            if(_galvanometer != null)
            {
                _galvanometer.SetCurrent(_current);
                Debug.Log("Galvanometer current is: " + _current);
            }

        }

        void calculateResistance()
        {
            if(_ammter != null)
            {
                toatalRes += _ammter.getRes();
            }

            if(_rheostat != null)
            {
                toatalRes += _rheostat.getResistance();
            }

            current = (VoltageSource.GetComponent<Voltage_source>().getVolt()) / toatalRes;
            Debug.Log(" resistance: " + toatalRes + " current : " + current);
            PlayerPrefs.SetFloat("current", current);

        }

        void stopCircuit()
        {
            isCurrentFlowing = 0;
            PlayerPrefs.SetInt("isCurrentFlowing", isCurrentFlowing);
            PlayerPrefs.SetFloat("current", 0f);
        }

        public bool traverse(GameObject loopObj)
        {
            loopObj = GameObject.Find("voltage_source");

            if(loopObj == null)
            {
                print("voltage source null");
                return false;
            }

            do
            {
                Transform term = null;
                foreach(Transform child in loopObj.transform)  // To find terminal in circuit
                {
                    if(child.gameObject.tag == "Terminal" && !child.GetComponent<Terminal>().Traveresed)
                    {
                        print("terminal assigned " + child.GetComponent<Terminal>().getPol());
                        term = child;
                    }
                } 
                if(term == null)
                {
                    print("Terminal null exception");
                    return false;
                }

                term.gameObject.GetComponent<Terminal>().Traveresed = true;
                loopObj = term.gameObject.GetComponent<Terminal>().connectedTo();

                if(loopObj == null)
                {
                    return false;
                }

                else
                {
                    Debug.Log("In else");
                    Debug.Log("loopObj : " + loopObj);
                    switch(loopObj.name)
                    {
                        case "Ammeterprefab" :
                            _ammter = loopObj.GetComponent<Ammeter>();
                            break;
                        case "voltage_source" :
                            _volatgesource = loopObj.GetComponent<VoltageSource>(); // This maybe a problem as there is another voltage_source used
                            break;
                        case "Voltmeterprefab" :
                            _voltmeter = loopObj.GetComponent<Voltmeter>();
                            break;
                        case "rheostat" :
                            _rheostat = loopObj.GetComponent<Rheostat>();
                            break;
                        case "plugKey" :
                            _plugkey = loopObj.GetComponent<TouchApparatus>();
                            break;
                        case "Meter Bridge" :
                            _meterBridge = loopObj.GetComponent<MeterBridge>();
                            break;
                        case "Resistance_Box Variant" :
                            _resistanceBox = loopObj.GetComponent<Resistance_Box>();
                            break;
                        case "Galvanometerprefab" :
                            _galvanometer = loopObj.GetComponent<Galvanometer>();
                            break;
                        default:
                            Debug.Log("Traverse function default case");
                            break; 
                    }
                    Debug.Log("Component added");
                }

            }while(loopObj.name != "voltage_source");
            return true;
        }

        
        public void startCircuit()
        {
            isVoltageSourceOn =! isVoltageSourceOn;
            if(!isVoltageSourceOn)
            {
                stopCircuit();
                return;
            }
            if(traverse(VoltageSource))
            {
                isCircuitConnected = true;
                isCurrentFlowing = 1;
                PlayerPrefs.SetInt("isCurrentFlowing", isCurrentFlowing);
                Debug.Log(" current is flowing");
                calculateResistance();
                setInCircuit(current);
                print(current);
            }
        }
    
    }

    public class components : MonoBehaviour
    {
        public GameObject component;
        public Component Type;
    }

    public enum typecomp
    {
        VoltageSource, Voltmeter, Ammeter, Rheostat, TouchApparatus
    }

}

