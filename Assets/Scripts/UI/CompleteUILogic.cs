using Scene;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class CompleteUILogic : MonoBehaviour
    {
        // The scene to load as the next level
        [SerializeField] private string sceneToLoad;
        // The root element of the UI
        private VisualElement _root;
        // The button to open the next level
        private Button _nextButton;
        
        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;

            _nextButton = _root.Q<Button>("nextButton");

            _nextButton.clicked += nextLevel;
            _root.visible = false;
        }

        /// <summary>
        ///  Loads the next level
        /// </summary>
        private void nextLevel()
        {
            Debug.Log("Next Level");
        }

        /// <summary>
        ///  Shows the "Level Complete" screen
        /// </summary>
        public void ShowScreen()
        {
            _root.visible = true;
            SceneLogic.UIShown = true;
        }
    }
}
