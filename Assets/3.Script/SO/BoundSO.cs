using UnityEngine;

[CreateAssetMenu(fileName = "BoundSO", menuName = "Scriptable Objects/Environment/BoundSO")]
public class BoundSO : ScriptableObject
{
    public float Radius => radius;
    public int PointCount => pointCount;

    [SerializeField] private float radius = 5f; // 원의 반지름
    [SerializeField] private int pointCount = 50; // 원을 구성할 점의 개수 (많을수록 부드러움)
}
