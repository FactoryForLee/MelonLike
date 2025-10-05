using UnityEngine;

[CreateAssetMenu(fileName = "InGameRuleSO", menuName = "Scriptable Objects/Environment/InGameRuleSO")]
public class InGameRuleSO : ScriptableObject
{
    public Vector3 PoolPos => poolPos;

    [SerializeField] private Vector3 poolPos;
}
