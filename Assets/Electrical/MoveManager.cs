using UnityEngine;

namespace Electrical {
    public class MoveManager : MonoBehaviour
    {
        public Vector3 startTransform;

        void Start()
        {
            startTransform = this.transform.position;
        }

        public void OnDrag()
        {
            if(enabled)
            {
                float planeY = this.transform.position.y;
                Transform draggingObject = transform;

                Plane plane = new Plane(Vector3.up, Vector3.up * planeY);

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                float distance;
                if(plane.Raycast(ray, out distance))
                {
                    draggingObject.position = ray.GetPoint(distance);
                }
                float xPos = Mathf.Clamp(draggingObject.position.x, startTransform.x -5f, startTransform.x +5f);
                float zPos = Mathf.Clamp(draggingObject.position.z, startTransform.z -5f, startTransform.z +5f);

                draggingObject.position = new Vector3(xPos, startTransform.y, zPos);
            }
        }
    }
}
