using System;
using Scene;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
    public class TipUILogic : MonoBehaviour
    {
        // The tip to be shown to the user
        [SerializeField] private string tip;
        
        // The root element of the UI
        private VisualElement _root;
        // The button to close the tip and start the level
        private Button _closeButton;
        // The label shown to the user when the level begins
        private Label _tipLabel;

        private void Start()
        {
            _root = GetComponent<UIDocument>().rootVisualElement;
            _closeButton = _root.Q<Button>("closeButton");
            _tipLabel = _root.Q<Label>("tipLabel");

            _tipLabel.text = tip;

            _closeButton.clicked += CloseButtonPressed;
        }

        /// <summary>
        /// Closes the tip UI, and begins user interaction with the game
        /// </summary>
        private void CloseButtonPressed()
        {
            _root.visible = false;
            SceneLogic.UIShown = false;
        }
    }
}
