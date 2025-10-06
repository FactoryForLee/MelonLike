using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField] private Poolobj prefab;

    private Queue<Poolobj> pool = new Queue<Poolobj>();

    public Poolobj GetObject()
    {
        Poolobj obj;
        if (pool.Count == 0)
            obj = Instantiate(prefab);

        else//TODO: 풀링 사용할 때 버그 발생 null ref 
            obj = pool.Dequeue();
        

        obj.gameObject.SetActive(false);
        obj.OnReturnToPool.AddListener(ReturnToPool);
        return obj;
    }

    protected void ReturnToPool(Poolobj obj)
    {
        obj.transform.position = Vector2.zero;
        obj.OnReturnToPool.RemoveListener(ReturnToPool);
        pool.Enqueue(obj);
    }
}