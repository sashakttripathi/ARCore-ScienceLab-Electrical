using UnityEngine;

namespace Electrical { 
    public class MeterBridge : MonoBehaviour
    {
        float unknownRes, resRod, jockeyPos, inverseRes;
        public Terminal mainP, mainN;
        public Terminal GalP, GalN, resP, resN, boxP, boxN;

        public float ResRod
        {
            get{ return resRod; }
            set{ resRod = value; }
        }

        public float calcJockeyPos()
        {
            float wireLength = Mathf.Abs(mainN.gameObject.transform.position.z - mainP.gameObject.transform.position.z);
            jockeyPos = Mathf.Abs((mainP.gameObject.transform.transform.position.z - GalP.gameObject.transform.position.z)*100/wireLength);
            return jockeyPos;
        }

        public float getResP()
        {
            for(int i=0; i < resP.numberConnections(); i++)
            {
                if(resP.connectedTo(i).GetComponent<Resistor>().t1 == resP) // checks that is resP connected to the terminal which is connected to itself
                {
                    if(resP.connectedTo(i).GetComponent<Resistor>().t2 == resN)
                    {
                        inverseRes += 1 / resP.connectedTo(i).GetComponent<Resistor>().getRes();
                    }
                    else 
                    {
                        unknownRes += resP.connectedTo(i).GetComponent<Resistor>().t2.connectedTo(1).GetComponent<Resistor>().getRes(); 
                    }
                    
                }

                else if(resP.connectedTo(i).GetComponent<Resistor>().t2 == resP)
                {
                    if(resP.connectedTo(i).GetComponent<Resistor>().t1 == resN)
                    {
                        inverseRes += 1 / (resP.connectedTo(i).GetComponent<Resistor>().getRes());
                    }

                    else 
                    {
                        unknownRes += resP.GetComponent<Resistor>().t1.connectedTo(1).GetComponent<Resistor>().getRes();
                    }
                }
            }
            if(unknownRes == 0 && inverseRes != 0)
            {
                unknownRes = 1/inverseRes;
            }

            return unknownRes;
        }

        public float getResQ()
        {
            return boxP.connectedTo(0).GetComponent<Resistor>().getRes();
        }

        public float getResR()
        {
            return (resRod / 100) * (calcJockeyPos());
        }

        public float getResS()
        {
            return (resRod / 100) * (calcJockeyPos());
        }

        public void Start()
        {
            mainP.setPol('+');
            mainN.setPol('-');
        }

        public int getCurrent()
        {
            if(getResP()/getResR() == getResQ()/getResS())
            {
                return 0;
            }

            else if(getResP()/getResR() < getResQ()/getResS())
            {
                return -1;      // Needs to be changed to show continious change in current in galvanometer
            }
            else
            {
                return 1;       // Needs to be changed to show continious change in current in galvanometer
            }
        }
    }
}