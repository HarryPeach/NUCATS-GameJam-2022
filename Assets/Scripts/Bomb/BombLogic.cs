using System;
using Audio;
using Projectile;
using Unity.VisualScripting;
using UnityEngine;

namespace Bomb
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class BombLogic : Explodable
    {
        [SerializeField] private AudioClip placeSound;
        private void Start()
        {
            SoundManager.Inst.Play(placeSound);
        }
    }
}
