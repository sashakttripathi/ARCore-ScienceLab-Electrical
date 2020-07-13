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