using Scene;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class CompleteUILogic : MonoBehaviour
    {
        // The root element of the UI
        private VisualElement _root;
        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _root.visible = false;
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
