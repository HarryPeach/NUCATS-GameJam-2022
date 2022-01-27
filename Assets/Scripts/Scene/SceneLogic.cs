using System.Collections.Generic;
using System.Linq;
using Audio;
using Finish_Object;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

namespace Scene
{
    public class SceneLogic : MonoBehaviour
    {
        // The prefab to spawn on click
        [SerializeField] private GameObject spawnPrefab;
        // The max amount of bombs allowed for the level
        [SerializeField] private int bombMax = 99;
        // Amount of flags required to complete a level
        [SerializeField] private List<GameObject> flags;
        // The screen to show when the level is over
        [SerializeField] private UIDocument completeScreen;
        // The font to use when drawing text
        [SerializeField] private GUIStyle guiStyle;


        // The amount of bombs that have been placed
        private int _bombsPlaced = 0;

        // Whether a UI screen is currently being shown
        // This is a hacky way to disable click-throughs when UI is visible
        public static bool UIShown = true;

        private void Update()
        {
            if (UIShown) return;
            
            if (Input.GetKeyUp(KeyCode.R))
            {
                flags.Clear();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            
            CheckFlags();
            
            if (!Input.GetMouseButtonUp(0)) return;
            PlaceBomb();
        }

        /// <summary>
        /// Checks whether the required flags for the level to be complete have been activated
        /// </summary>
        private void CheckFlags()
        {
            int count = flags.Select(flag => flag.GetComponent<FinishLogic>())
                .Count(fl => fl.activated);
            if (count != flags.Count) return;
            
            UIShown = true;
            completeScreen.GetComponent<CompleteUILogic>().ShowScreen();
        }

        /// <summary>
        /// Places a bomb at the current position of the cursor relative to the world space
        /// </summary>
        private void PlaceBomb()
        {
            if (Camera.main is null) return;
            if (_bombsPlaced == bombMax) return;

            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            
            // Don't let bombs be placed anywhere apart from the base tilemap
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider == null) return;
            if (hit.collider.gameObject.name != "Tilemap_Base") return;

            objectPos.z = 0;
            Instantiate(spawnPrefab, objectPos, Quaternion.identity);
            _bombsPlaced++;
        }
        
        private void OnGUI()
        {
            GUI.Label(
                new Rect(10, 10, 200, 20),
                $"Bombs: ({_bombsPlaced}/{bombMax})", guiStyle);
            GUI.Label(
                new Rect(10, Screen.height - 20, 200, 20), 
                "Press R to reset the level", guiStyle);
        }
    }
}
