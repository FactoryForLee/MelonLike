using UnityEngine;
using UnityEngine.Events;

public class Poolobj : MonoBehaviour
{
    public UnityEvent<Poolobj> OnReturnToPool;

    protected void OnDisable()
    {
        OnReturnToPool?.Invoke(this);
    }
}
