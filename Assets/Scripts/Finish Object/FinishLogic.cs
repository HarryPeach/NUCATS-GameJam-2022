using System;
using Scene;
using UnityEditor.Searcher;
using UnityEngine;

namespace Finish_Object
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class FinishLogic : MonoBehaviour
    {
        [SerializeField] private Sprite inactiveSprite;
        [SerializeField] private Sprite activeSprite;

        private SpriteRenderer _spriteRenderer;
        public bool activated;

        private void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.sprite = inactiveSprite;
        }
        
        /// <summary>
        /// Called when the finish object is hit by a projectile
        /// </summary>
        public void Attack()
        {
            if (activated) return;
            activated = true;
            _spriteRenderer.sprite = activeSprite;
        }
    }
}
