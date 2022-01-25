using UnityEngine;

namespace CameraControl
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        // The speed at which the camera is dragged
        [SerializeField] private float dragSpeed = .2f;
        
        // The origin the camera is dragged from
        private Vector3 _dragOrigin;
        
        private void Update()
        {
            if (Camera.main is null) return;
            if (Input.GetMouseButtonDown(2))
            {
                _dragOrigin = Input.mousePosition;
                return;
            }
 
            if (!Input.GetMouseButton(2)) return;
 
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - _dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
 
            transform.Translate(move, Space.World);
        }
    }
}
