using Projectile;
using UnityEngine;

namespace Bomb
{
	public class Explodable : MonoBehaviour
	{
		[SerializeField] private GameObject projectilePrefab;
		[SerializeField] private int spread = 8;
		
		public void Explode()
		{
			Debug.Log("Exploding!");
            
			// Disable collisions on the explosive so that projectiles don't immediately destroy
			if (TryGetComponent(typeof(BoxCollider2D), out Component component))
			{
				((BoxCollider2D) component).enabled = false;
			}

			// Send out projectiles at equal angles
			for (int i = 0; i < spread; i++)
			{
				float angle = 360f / spread * i;
				Vector3 direction = new(Mathf.Sin(Mathf.Deg2Rad * angle),
					Mathf.Cos(Mathf.Deg2Rad * angle), 0);
				
				if (projectilePrefab.gameObject.TryGetComponent(typeof(ProjectileMovement),
					out Component projMovementComponent))
				{
					((ProjectileMovement)projMovementComponent).movementDirection = direction;
				}
				Instantiate(projectilePrefab, transform.position, Quaternion.identity);
			}
            
			Destroy(gameObject);
		}
	}
}