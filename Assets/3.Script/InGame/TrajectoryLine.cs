using System;
using System.Collections;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BallThrower ballThrower;
    [SerializeField] private BoundSO boundData;
    [SerializeField] private Transform arrow;

    [Header("Variables")]
    [SerializeField] private int segmentCount;


    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void StartDraw()
    {
        lineRenderer.positionCount = segmentCount;
        arrow.gameObject.SetActive(true);
    }

    public void Draw(float magnitude, Vector2 lineEndPos, Vector2 dir)
    {
        arrow.position = ballThrower.ballSpawnPos + dir.normalized;
        arrow.up = dir;
        lineRenderer.SetPosition(0, ballThrower.ballSpawnPos);
        lineRenderer.SetPosition(1, lineEndPos);
    }

    public void StopDraw()
    {
        lineRenderer.positionCount = 0;
        transform.position = Vector2.zero;
        arrow.gameObject.SetActive(false);
    }
}
