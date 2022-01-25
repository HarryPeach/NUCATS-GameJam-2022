using System;
using Bomb;
using UnityEngine;

namespace Projectile
{
    public class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 0.05f;
        [SerializeField] public Vector3 movementDirection;
        private void FixedUpdate()
        {
            Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
            rb2d.MovePosition(transform.position + movementDirection * movementSpeed);
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            // Don't collide with other projectiles
            if (other.tag.Equals("Projectile")) return;
            
            // Make bombs explode on collision
            if (other.gameObject.TryGetComponent(typeof(BombLogic), out Component component))
            {
                ((BombLogic)component).Explode();
            }

            // Debug.Log($"Projectile collided with '{other.name}' and de-spawned.");
            Destroy(gameObject);
        }
    }
}
