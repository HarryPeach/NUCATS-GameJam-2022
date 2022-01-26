using Scene;
using UnityEngine;

namespace CameraControl
{
    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        // The speed at which the camera is dragged
        [SerializeField] private float dragSpeed = .2f;

        // The maximum size (zoom) the camera can be
        [SerializeField] private int maxCameraSize = 15;
        
        // The minimum size (zoom) the camera can be
        [SerializeField] private int minCameraSize = 1;
        
        // The origin the camera is dragged from
        private Vector3 _dragOrigin;

        private Camera _camera;

        private void Start()
        {
            _camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (SceneLogic.UIShown) return;
            DragCamera();
            ZoomCamera();
        }

        /// <summary>
        /// Allows the user to zoom the camera in and out of the level
        /// </summary>
        private void ZoomCamera()
        {
            // 1 = up / in
            // -1 = down / out
            
            // allow zooming out
            if (_camera.orthographicSize < maxCameraSize && Input.mouseScrollDelta.y < 0)
            {
                _camera.orthographicSize -= Input.mouseScrollDelta.y;
            }

            if (_camera.orthographicSize > minCameraSize && Input.mouseScrollDelta.y > 0)
            {
                _camera.orthographicSize -= Input.mouseScrollDelta.y;
            }
            // if (_camera.orthographicSize > minCameraSize && _camera.orthographicSize < maxCameraSize)
            // {
                // _camera.orthographicSize -= Input.mouseScrollDelta.y;
            // }
        }

        /// <summary>
        /// Allows the user to drag the camera across the level
        /// </summary>
        private void DragCamera()
        {
            if (Input.GetMouseButtonDown(2))
            {
                _dragOrigin = Input.mousePosition;
                return;
            }
 
            if (!Input.GetMouseButton(2)) return;
 
            Vector3 pos = _camera.ScreenToViewportPoint(Input.mousePosition - _dragOrigin);
            Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);
 
            transform.Translate(move, Space.World);
        }
    }
}
