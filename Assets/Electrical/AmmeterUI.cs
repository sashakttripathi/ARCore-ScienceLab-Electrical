using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Electrical{
    public class AmmeterUI : MonoBehaviour
    {
           public TextMeshProUGUI valuePlate;
           private Ammeter ammeterInstance;
           private Needle needle;
           public GameObject ARMain;
           public GameObject Canvas;

           public float maxAngleMagnitude = 40f;
           public float maxCurrentMagnitude = 20f;

           private void Start()
           {
               ammeterInstance = GetComponent<Ammeter>();
               needle = GameObject.FindGameObjectWithTag("AmmeterNeedle").GetComponent<Needle>();
               Debug.Log("Needle : "+needle);
               needle.SetNeedle(40f);
           }

           public void SetPlate(float current)
           {
                valuePlate.text = current.ToString() + "A"; 
           }

           public void SetUI(float _current)
           {
               Debug.Log("Current Value: " + _current);
               float current = (float) Mathf.Round(_current*100) / 100f;
               SetPlate(current);

               current = Mathf.Clamp(current, -maxCurrentMagnitude, maxCurrentMagnitude); // value restricted between these 2
               float angle = (float) current / maxCurrentMagnitude * maxAngleMagnitude *2 - maxAngleMagnitude;
               Debug.Log("Angle : " + angle);
               needle.SetNeedle(angle);
           }
    }


}
