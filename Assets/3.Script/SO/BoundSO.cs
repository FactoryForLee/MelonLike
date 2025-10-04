using UnityEngine;

[CreateAssetMenu(fileName = "BoundSO", menuName = "Scriptable Objects/Environment/BoundSO")]
public class BoundSO : ScriptableObject
{
    public float Radius => radius;
    public int PointCount => pointCount;

    [SerializeField] private float radius = 5f; // ���� ������
    [SerializeField] private int pointCount = 50; // ���� ������ ���� ���� (�������� �ε巯��)
}
