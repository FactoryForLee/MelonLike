using InGameDefine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InGameManager : Singleton<InGameManager>
{
    public Dictionary<EBallColor, ObjectPooling> BallPools => ballPools;

    private Dictionary<EBallColor, ObjectPooling> ballPools = new Dictionary<EBallColor, ObjectPooling>();
    [SerializeField] private InGameRuleSO ruleData;


    protected override void Init()
    {
        for (int i = 0; i < (int)EBallColor.Count; i++)
        {
            GameObject eachPool = new GameObject();
            ballPools.Add((EBallColor)i, eachPool.AddComponent<ObjectPooling>());
            eachPool.transform.parent = transform;
            eachPool.transform.localPosition = Vector3.zero;
        }
    }
}
