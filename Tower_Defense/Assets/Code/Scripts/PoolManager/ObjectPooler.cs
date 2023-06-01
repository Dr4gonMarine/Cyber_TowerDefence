using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [Header("------Prefab da Pool------")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    public string poolName{get => prefab.name;}
    private List<GameObject> _pool;
    private GameObject _poolContainer;

    static Vector3 _positionSpawner;

    void Awake()
    {
        _pool = new List<GameObject>();
        _poolContainer = new GameObject($"Pool - {prefab.name}");
        CreatePooler();
        _positionSpawner = transform.position;
    }

    void CreatePooler()
    {
        for (int i = 0; i < poolSize; i++)
        {
            _pool.Add(CreateInstace());
        }
    }

    GameObject CreateInstace()
    {
        GameObject newInstace = Instantiate(prefab);
        newInstace.transform.SetParent(_poolContainer.transform);
        newInstace.transform.position = transform.position;
        newInstace.SetActive(false);
        return newInstace;
    }

    public GameObject GetInstaceFromPool()
    {
        for (int i = 0; i < _pool.Count; i++)
        {
            if (!_pool[i].activeInHierarchy)
            {
                return _pool[i];
            }
        }
        return CreateInstace();
    }

    public static void RetunToPool(GameObject instance)
    {
        instance.SetActive(false);
        //instance.transform.position = _positionSpawner;
    }

    public static IEnumerator ReturnToPoolWithDelay(GameObject instace, float delay)
    {
        yield return new WaitForSeconds(delay);
        instace.SetActive(false);
    }
}
