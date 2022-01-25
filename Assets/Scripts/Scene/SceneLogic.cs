using UnityEngine;

namespace Scene
{
    public class SceneLogic : MonoBehaviour
    {
        // The prefab to spawn on click
        [SerializeField] private GameObject spawnPrefab;
        // The max amount of bombs allowed for the level
        [SerializeField] private int bombMax;

        // The amount of bombs that have been placed
        private int _bombsPlaced = 0;
        
        private void Update()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            PlaceBomb();
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
            objectPos.z = 0;
            Instantiate(spawnPrefab, objectPos, Quaternion.identity);
            _bombsPlaced++;
        }
        
        private void OnGUI()
        {
            GUI.Label(
                new Rect(10, 10, 100, 20),
                $"Bombs: ({_bombsPlaced}/{bombMax})");
        }
    }
}
