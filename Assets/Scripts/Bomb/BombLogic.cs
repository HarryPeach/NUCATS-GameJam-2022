using Projectile;
using Unity.VisualScripting;
using UnityEngine;

namespace Bomb
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BombLogic : MonoBehaviour
    {
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private int spread = 8;
        
        public void Explode()
        {
            Debug.Log("Exploding!");
            
            // Disable collisions on the bomb so that projectiles don't immediately destroy
            GetComponent<BoxCollider2D>().enabled = false;

            for (int i = 0; i < spread; i++)
            {
                float angle = (360f / spread) * i;
                Vector3 direction = new(Mathf.Sin(Mathf.Deg2Rad * angle),
                    Mathf.Cos(Mathf.Deg2Rad * angle), 0);
                
                // TODO: Fix this to use TryGetComponent
                projectilePrefab.gameObject.GetComponent<ProjectileMovement>().movementDirection = direction;
                Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            }
            
            Destroy(gameObject);
        }
    }
}
