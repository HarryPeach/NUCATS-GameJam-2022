using UnityEngine;

namespace Movers
{
    public class MoverLogic : MonoBehaviour
    {
        // The position that the mover starts in
        [SerializeField] private Vector3 startPos;

        // The position that the mover ends in
        [SerializeField] private Vector3 endPos;

        // The speed at which the mover moves
        [SerializeField] private float speed = 1f;
        
        // Represents the current direction the object is moving in
        private bool _direction = false;

        private void Update()
        {
            float step = speed * Time.deltaTime;

            if (transform.position == startPos || transform.position == endPos)
            {
                _direction = !_direction;
            }

            transform.position = Vector3.MoveTowards(transform.position, _direction ? endPos : startPos, step);
        }
    }
}
