using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Pool
{
    private GameObject _prefab = null;
    private IObjectPool<GameObject> _pool = null;

    private Transform _root = null;
    private Transform Root
    {
        get
        {
            if (_root == null)
            {
                GameObject go = new GameObject() { name = $"@{_prefab.name}_Pool" };
                _root = go.transform;
            }

            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    private GameObject OnCreate()
    {
        GameObject go = GameObject.Instantiate(_prefab);
        go.transform.SetParent(Root);
        go.name = _prefab.name;
        return go;
    }

    private void OnGet(GameObject go)
    {
        if (go != null)
            go.SetActive(true);
    }

    private void OnRelease(GameObject go)
    {
        if (go != null)
            go.SetActive(false);
    }

    private void OnDestroy(GameObject go)
    {
        if (go != null)
            GameObject.Destroy(go);
    }

    public void Push(GameObject go)
    {
        go.transform.SetParent(_root);

        if (go.activeSelf)
            _pool.Release(go);
    }

    public GameObject Pop()
    {
        return _pool.Get();
    }

    public void Clear()
    {
        _pool.Clear();
    }
}

public class PoolManager
{
    Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();

    private void CreatePool(GameObject original)
    {
        Pool pool = new Pool(original);
        _pools.Add(original.name, pool);
    }

    public GameObject Pop(GameObject prefab)
    {
        if (_pools.ContainsKey(prefab.name) == false)
        {
            CreatePool(prefab);
        }

        return _pools[prefab.name].Pop();
    }

    public bool Push(GameObject go)
    {
        if (_pools.ContainsKey(go.name) == false)
        {
            return false;
        }

        _pools[go.name].Push(go);

        return true;
    }

    public void Clear()
    {
        foreach (var pool in _pools.Values)
        {
            pool.Clear();
        }

        _pools.Clear();
    }
}
