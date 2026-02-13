using UnityEngine;

public class PooledItem : MonoBehaviour
{
    [SerializeField] private float timeToLive = 3f;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.Sleep();
        }

        Invoke(nameof(ReturnToPool), timeToLive);
    }

    private void ReturnToPool()
    {
        if (PoolManager.Instance != null)
        {
            PoolManager.Instance.ReturnObject(this.gameObject);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
}