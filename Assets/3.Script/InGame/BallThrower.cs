using InGameDefine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BallThrower : MonoBehaviour
{
    //Preference=======================
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private TrajectoryLine lineDrawer;

    [SerializeField] private UnityEvent<Ball> OnBallChanged;

    public Ball ball { get; private set; }

    //=================================


    //Project Variables================
    public Vector2 ballSpawnPos { get; private set; }

    private Vector2 throwDir;
    private bool isTouchStarted = false;
    //=================================

    private void OnEnable()
    {
        ball = GetComponent<Ball>();
        //ReloadBall();
        UserInput.touchPressAction.started += TouchStarted;
        UserInput.touchPositionAction.performed += TouchPerformed;
        UserInput.touchPressAction.canceled += TouchCanceled;
        ballSpawnPos = (Vector2)ballSpawnPoint.position;
        Debug.Log("바인딩 완료");
    }

    private void OnDisable()
    {
        UserInput.touchPressAction.started -= TouchStarted;
        UserInput.touchPressAction.performed -= TouchPerformed;
        UserInput.touchPressAction.canceled -= TouchCanceled;
    }

    private void TouchStarted(InputAction.CallbackContext context)
    {
        lineDrawer.StartDraw();
        isTouchStarted = true;
        Debug.Log("터치 시작");
        throwDir = Vector2.zero;
    }

    private void TouchPerformed(InputAction.CallbackContext context)
    {
        if (isTouchStarted)
        {
            Vector2 performedTouchPos = UserInput.GetConvertedTouchPos();

            throwDir = ballSpawnPos - performedTouchPos;
            float sqrMag = throwDir.sqrMagnitude;
            lineDrawer.Draw(sqrMag, performedTouchPos, throwDir);
        }
    }

    private void TouchCanceled(InputAction.CallbackContext context)
    {
        //dir의 magnitude < 0.1f면 쏘지 않기
        //else 쏘기
        lineDrawer.StopDraw();
        isTouchStarted = false;

        if(throwDir.sqrMagnitude > 1.0f)
        {
            ThrowBall();
            ReloadBall();
        }
    }

    private void ThrowBall()
    {
        ball.transform.position = ballSpawnPoint.position;
        ball.gameObject.SetActive(true);
        Rigidbody2D ballrb = ball.GetComponent<Rigidbody2D>();
        ballrb.AddForce(throwDir);
    }

    private void ReloadBall()
    {
        Ball newBall = (Ball)InGameManager.Instance.BallPools[(EBallColor)Random.Range(0, (int)EBallColor.YellowOrange)].GetObject();
        OnBallChanged?.Invoke(ball);
    }
}
