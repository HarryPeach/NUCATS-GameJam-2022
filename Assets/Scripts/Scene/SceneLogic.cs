using UnityEngine;

namespace Scene
{
    public class SceneLogic : MonoBehaviour
    {
        // The prefab to spawn on click
        [SerializeField] private GameObject spawnPrefab;
        
        private void Update()
        {
            if (!Input.GetMouseButtonUp(0)) return;
            if (Camera.main is null) return;
            
            Vector3 mousePos = Input.mousePosition;
            Vector3 objectPos = Camera.main.ScreenToWorldPoint(mousePos);
            objectPos.z = 0;
            Instantiate(spawnPrefab, objectPos, Quaternion.identity);
        }
    }
}
