using UnityEngine;

namespace Electrical {
    public class Resistance_Box : MonoBehaviour
    {
         int resistance;
         float current;
         public Terminal t1, t2;
         bool isConnected;

         [SerializeField]
         ResValue[] key;

         void Start()
         {
             t1.setPol('n'); // There should be some problem here in the terminal initialization
             t2.setPol('n');
         }

         public float Current
         {
             get { return this.current; }
             set { this.current = value; }
         }

         public void calculateResistance()
         {
             resistance = 0;
             for(int i = 0; i<key.Length; i++)
             {
                if(!key[i].currentstate())
                {
                    resistance += key[i].resistance();
                }
             }
         }

         public float getResistance()
         {
             calculateResistance();
             return resistance;
         }

         public bool isActive()
         {
             return isConnected;
         }

    }
}