using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPooling<T> : MonoBehaviour where T : Poolobj
{
    [SerializeField] private GameObject prefab;

    private Queue<T> pool = new Queue<T>();

    protected T GetObject()
    {
        T obj;
        if (pool.Count == 0)
            obj = Instantiate(prefab) as T;

        else
        {//TODO: 풀링 사용할 때 버그 발생 null ref
            obj = pool.Dequeue();
            obj.gameObject.SetActive(true);
        }

        obj.OnReturnToPool.AddListener(ReturnToPool);
        return obj;
    }

    protected void ReturnToPool(Poolobj obj)
    {
        obj.transform.position = Vector2.zero;
        obj.OnReturnToPool.RemoveListener(ReturnToPool);
        pool.Enqueue((T)(obj));
    }
}

public class Poolobj : MonoBehaviour
{
    public UnityEvent<Poolobj> OnReturnToPool;

    protected void OnDisable()
    {
        OnReturnToPool?.Invoke(this);
    }
}