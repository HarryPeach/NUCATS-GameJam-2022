using Audio;
using Scene;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace UI
{
    public class CompleteUILogic : MonoBehaviour
    {
        // The scene to load as the next level
        [SerializeField] private string sceneToLoad;
        // The sound to play when a level is completed
        [SerializeField] private AudioClip completeSound;
        // The root element of the UI
        private VisualElement _root;
        // The button to open the next level
        private Button _nextButton;
        
        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            _nextButton = _root.Q<Button>("nextButton");

            _nextButton.clicked += NextLevel;
            _root.visible = false;
        }

        /// <summary>
        ///  Loads the next level
        /// </summary>
        private void NextLevel()
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        /// <summary>
        ///  Shows the "Level Complete" screen
        /// </summary>
        public void ShowScreen()
        {
            _root.visible = true;
            SceneLogic.UIShown = true;
            SoundManager.Inst.Play(completeSound);
        }
    }
}
