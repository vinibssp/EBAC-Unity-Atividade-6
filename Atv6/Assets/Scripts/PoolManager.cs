using UnityEngine;
using UnityEngine.Pool;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] private GameObject prefab;
    [SerializeField] private int defaultCapacity = 10;
    [SerializeField] private int maxPoolSize = 20;

    private IObjectPool<GameObject> pool;

    private void Awake()
    {
        Instance = this;

        pool = new ObjectPool<GameObject>(
            CreatePooledItem,
            OnTakeFromPool,
            OnReturnedToPool,
            OnDestroyPoolObject,
            true,
            defaultCapacity,
            maxPoolSize
        );
    }

    private GameObject CreatePooledItem()
    {
        return Instantiate(prefab);
    }

    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject obj)
    {
        Destroy(obj);
    }

    public GameObject GetObject()
    {
        return pool.Get();
    }

    public void ReturnObject(GameObject obj)
    {
        pool.Release(obj);
    }
}