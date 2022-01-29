using Audio;
using Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class GameOverUILogic : MonoBehaviour
    {
        // The sound to play when a level is completed
        [SerializeField] private AudioClip completeSound;
        // The root element of the UI
        private VisualElement _root;

        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _root.visible = false;
        }
        
        /// <summary>
        ///  Shows the "Game Over" screen
        /// </summary>
        public void ShowScreen()
        {
            _root.visible = true;
            SceneLogic.UIShown = true;
            SoundManager.Inst.Play(completeSound);
        }
    }
}
