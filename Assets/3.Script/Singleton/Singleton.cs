using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;
    public static T Instance => instance;

    private void Awake()
    {
        if (instance == null)
        {

#if UNITY_EDITOR
            if (FindObjectsByType(typeof(T), FindObjectsSortMode.None).Length > 1)
                Debug.LogWarning($"���� {typeof(T)}�� ������ �����մϴ�!");
#endif

            instance = this as T;
            (instance as Singleton<T>).Init();
        }

        else
            Destroy(gameObject);
    }

    protected abstract void Init();
}