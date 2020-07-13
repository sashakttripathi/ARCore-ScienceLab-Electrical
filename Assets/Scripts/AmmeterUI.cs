using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Electrical {
    public class AmmeterUI : MonoBehaviour
    {
           public TextMeshProUGUI valuePlate;
           private Ammeter ammeterInstance;
           private Needle needle;
           public GameObject ARMain;
           public GameObject Canvas;

           public float maxAngleMagnitude = 40f;
           public float maxCurrentMagnitude = 20f;

           private void start()
           {
               ammeterInstance = GetComponent<Ammeter>();
               needle = GameObject.FindGameObjectsWithTag("AmmeterNeedle").GetComponent<needle>();
               Debug.Log("Needle : "+needle);
               needle.setNeedle(40f);
           }
    }

}