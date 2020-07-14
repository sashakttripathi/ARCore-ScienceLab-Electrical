using UnityEngine;

namespace Electrical {
    public class ResValue : MonoBehaviour
    {
        public int resValue;
        bool isActive = true;
        float moveSpeed = 5f;
        Vector3 initialPos, finalPos;
        float distMoved;

        [SerializeField]
        GameObject parentResistanceBox;

        public bool currentstate()
        {
            return isActive;
        }

        public int resistance()
        {
            return resValue;
        }

        public void setState()
        {
            isActive = !isActive;
            parentResistanceBox.gameObject.GetComponent<Resistance_Box>().calculateResistance(); // recalculating total resistance
        }

        private void Start()
        {
            initialPos = this.transform.position; // Dont know what this is for
            finalPos = initialPos + (-Vector3.forward*5f); // Dont know what this is for
        }
    }
}