using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnerControl : MonoBehaviour
{
    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            SpawnAtMousePosition();
        }
    }

    void SpawnAtMousePosition()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        Vector3 mousePos3D = new Vector3(mousePosition.x, mousePosition.y, 10f);
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos3D);

        if (PoolManager.Instance != null)
        {
            GameObject obj = PoolManager.Instance.GetObject();
            obj.transform.position = worldPos;
        }
        else
        {
            Debug.LogWarning("PoolManager não encontrado na cena!");
        }
    }
}