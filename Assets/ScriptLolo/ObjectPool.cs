using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public GameObject prefab;
        public int size = 10;
        [HideInInspector] public List<GameObject> objects = new List<GameObject>();
    }

    public static ObjectPool Instance; //hacemos el singleton

    [SerializeField] private Pool[] pools;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            InitializePools();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializePools()
    {
        foreach (var pool in pools)
        {
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.parent = transform;
                pool.objects.Add(obj);
            }
        }
    }
    public GameObject GetObject(GameObject prefab)
    {
        Pool pool = GetPool(prefab);
        if (pool == null)
        {
            // Crear un nuevo pool dinámicamente si no existe
            pool = new Pool { prefab = prefab, size = 0 };
            pool.objects = new List<GameObject>();
            pools = AddPoolToArray(pools, pool);
        }

        foreach (var obj in pool.objects)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        // No hay objetos disponibles, instanciar uno nuevo
        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(true);
        newObj.transform.parent = transform;
        pool.objects.Add(newObj);
        if (pool.objects.Count >= 5)
        {
            Debug.LogWarning($"?? Pool para {prefab.name} está creciendo demasiado. Usando más de 100 instancias.");
        }
        return newObj;
    }
    private Pool GetPool(GameObject prefab)
    {
        foreach (var pool in pools)
        {
            if (pool.prefab == prefab)
                return pool;
        }
        return null;
    }

    private Pool[] AddPoolToArray(Pool[] original, Pool newPool)
    {
        List<Pool> list = new List<Pool>(original);
        list.Add(newPool);
        return list.ToArray();
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
    public GameObject GetFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        GameObject obj = GetObject(prefab);
        obj.transform.position = position;
        obj.transform.rotation = rotation;
        return obj;
    }
}


