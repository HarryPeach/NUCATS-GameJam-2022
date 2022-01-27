using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Audio
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioSource musicSource;

        public static SoundManager Inst = null;

        private void Awake()
        {
            if (Inst == null)
            {
                Inst = this;
                PlayMusic();
            }else if (Inst != this)
            {
                Destroy(gameObject);
            }
            
            DontDestroyOnLoad(gameObject);
        }

        public void Play(AudioClip clip)
        {
            float pitch = Random.Range(0.8f, 1.2f);
            effectsSource.clip = clip;
            effectsSource.pitch = pitch;
            effectsSource.Play();
        }
        
        private void PlayMusic()
        {
            musicSource.Play();
        }
    }
}
