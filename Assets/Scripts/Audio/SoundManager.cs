using System;
using UnityEngine;

namespace Audio
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource effectsSource;

        public static SoundManager Inst = null;

        private void Awake()
        {
            if (Inst == null)
            {
                Inst = this;
            }else if (Inst != this)
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);
        }

        public void Play(AudioClip clip)
        {
            effectsSource.clip = clip;
            effectsSource.Play();
        }
    }
}
