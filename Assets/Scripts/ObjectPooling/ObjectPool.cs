using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> : IPool<T> where T : MonoBehaviour, IPoolable<T>
{
    private Stack<T> _objectPool;
    private T _prefab;
    private Action<T> OnPull;
    private Action<T> OnPush;
    private int PooledCount 
    {
        get
        {
            return _objectPool.Count;
        }
    }
    public ObjectPool(T prefab, int poolSize, Action<T> onPull, Action<T> onPush)
    {
        _prefab = prefab;
        OnPull = onPull;
        OnPush = onPush;
        _objectPool = new Stack<T>();
        CreatePool(poolSize);
    }
    private void CreatePool(int poolSize)
    {
        T poolObject;
        for (int i = 0; i < poolSize; i++)
        {
            poolObject = GameObject.Instantiate(_prefab);
            _objectPool.Push(poolObject);
            poolObject.gameObject.SetActive(false);
            poolObject.Initialize(Push);
        }
    }
    public T Pull()
    {
        T poolObject;
        if(PooledCount > 0)
        {
            poolObject = _objectPool.Pop();
            poolObject.gameObject.SetActive(true);
        }
        else
        {
            poolObject = GameObject.Instantiate(_prefab);
            poolObject.Initialize(Push);
        }
        OnPull?.Invoke(poolObject);
        return poolObject;
    }
    public void Push(T poolObject)
    {
        OnPush?.Invoke(poolObject);
        _objectPool.Push(poolObject);
    }
}