using UnityEngine;

namespace Electrical {
    public class Switch : MonoBehaviour
    {
        bool isConnected;
        public GameObject plug;

        private void connectDisconnect()
        {
            isConnected = !isConnected;

            if(isConnected)
            {
                plug.transform.localPosition = Vector3.MoveTowards(plug.transform.localPosition, new Vector3(plug.transform.localPosition.x, -3.5f, plug.transform.localPosition.z), Time.deltaTime * 20);
            }
            else
            {
                plug.transform.localPosition = Vector3.MoveTowards(plug.transform.localPosition, new Vector3(plug.transform.localPosition.x, -3.9f, plug.transform.localPosition.z), Time.deltaTime * 20);
            }
        }
    }
}