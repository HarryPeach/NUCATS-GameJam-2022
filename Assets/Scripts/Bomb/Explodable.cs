using System;
using Audio;
using Projectile;
using UnityEngine;

namespace Bomb
{
	// [RequireComponent(typeof(ParticleSystem))]
	public class Explodable : MonoBehaviour
	{
		[SerializeField] private GameObject projectilePrefab;
		[SerializeField] private int spread = 8;
		[SerializeField] private AudioClip explosionSound;

		private ParticleSystem _particleSystem;

		private void Awake()
		{
			_particleSystem = GetComponent<ParticleSystem>();
		}

		public void Explode()
		{
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
					((ProjectileMovement) projMovementComponent).movementDirection = direction;
				}
				Instantiate(projectilePrefab, transform.position, Quaternion.identity);
			}
			
			SoundManager.Inst.Play(explosionSound);
			_particleSystem.Play();
			
			// Done this way so that the particle system isn't destroyed before it's finished
			GetComponent<SpriteRenderer>().enabled = false;
			Destroy(gameObject, 1f);
		}
	}
}