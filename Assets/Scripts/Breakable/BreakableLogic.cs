using UnityEngine;

namespace Breakable
{
    public class BreakableLogic : MonoBehaviour
    {
        [SerializeField] private int hitsLeft = 1;

        /// <summary>
        /// Called when the breakable object is hit by a projectile
        /// </summary>
        public void Attack()
        {
            hitsLeft--;

            if (hitsLeft == 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
