using UnityEngine;

namespace Electrical {
    public class TouchApparatus :MonoBehaviour
    {
        public GameObject canvas;

        void Update()
        {
            if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);

                if(Physics.Raycast(ray, out hit))
                {
                    if(hit.transform != null)
                    {
                        canvas.SetActive(true);
                    }
                }
            }
        }
    }
}