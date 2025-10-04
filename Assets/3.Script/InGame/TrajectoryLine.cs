using System;
using System.Collections;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BallThrower ballThrower;
    [SerializeField] private BoundSO boundData;

    [Header("Variables")]
    [SerializeField] private int segmentCount;
    [SerializeField] private float widthScale = 0.05f;
    [SerializeField] private float vibeThreshold = 0.1f;
    [SerializeField] private float vibeClamp = 0.5f;


    private float lineMagnitude = 0.0f;
    private Vector3 originEndLinePos = Vector3.zero;

    private LineRenderer lineRenderer;
    private Coroutine coroutine;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public void StartDraw()
    {
        lineRenderer.positionCount = segmentCount;
        if(coroutine != null) StopCoroutine(coroutine);

        coroutine = StartCoroutine(Vibrate_Co());
    }

    public void Draw(float magnitude, Vector2 lineEndPos)
    {
        lineRenderer.SetPosition(0, ballThrower.ballSpawnPos);
        lineRenderer.SetPosition(1, lineEndPos);
        originEndLinePos = lineEndPos;
        lineRenderer.endWidth = widthScale * magnitude;
        lineMagnitude = magnitude;
    }

    public void StopDraw()
    {
        StopCoroutine(coroutine);
        lineRenderer.positionCount = 0;
        transform.position = Vector2.zero;
        lineMagnitude = 0.0f;
    }

    private IEnumerator Vibrate_Co()
    {
        while (true)
        {
            LineVibrate();
            yield return null;
        }
    }

    private void LineVibrate()
    {
        Vector3 newPos = Vector3.zero;
        newPos.x = UnityEngine.Random.Range(-vibeClamp, vibeClamp) * lineMagnitude * vibeThreshold;
        newPos.y = UnityEngine.Random.Range(-vibeClamp, vibeClamp) * lineMagnitude * vibeThreshold;
        newPos = lineRenderer.GetPosition(1) + newPos;
        newPos.x = Mathf.Clamp(newPos.x, originEndLinePos.x - vibeClamp, originEndLinePos.x + vibeClamp);
        newPos.y = Mathf.Clamp(newPos.y, originEndLinePos.y - vibeClamp, originEndLinePos.y + vibeClamp);
        lineRenderer.SetPosition(1, newPos);
    }
}
