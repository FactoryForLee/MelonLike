using InGameDefine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BallThrower : ObjectPooling<Poolobj>
{
    //Unity Components=================

    [SerializeField] private LineRenderer dotLine;
    [SerializeField] private Transform arrow;

    //=================================

    //Project Variables================
    [SerializeField]private EBallColor color;

    public Vector2 startedTouchPos { get; private set; }

    private List<Poolobj> allLines;
    //=================================

    private void OnEnable()
    {
        UserInput.touchPressAction.started += TouchStarted;
        UserInput.touchPositionAction.performed += TouchPerformed;
        UserInput.touchPressAction.canceled += TouchCanceled;

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
        arrow.gameObject.SetActive(true);
        startedTouchPos = context.ReadValue<Vector2>();
        Debug.Log("터치 시작");
    }

    private void TouchPerformed(InputAction.CallbackContext context)
    {
        if (arrow.gameObject.activeSelf)
        {
            Vector2 performedTouchPos = context.ReadValue<Vector2>();
            DrawLine(startedTouchPos, performedTouchPos);
        }
    }

    private void TouchCanceled(InputAction.CallbackContext context)
    {
        arrow.gameObject.SetActive(false);
        foreach(Poolobj line in allLines)
            line.gameObject.SetActive(false);
    }


    private void DrawLine(Vector2 startTouchPos,Vector2 curTouchPos)
    {
        /*
         * dir = cur - start;
         * dir 방향을 arrow 방향으로
         * dir의 반대 방향을 line 방향으로
         */

        Vector2 dir = curTouchPos - startTouchPos;
        arrow.forward = dir;


        DrawDot();
        dotLine.positionCount++;
        dotLine.SetPosition(dotLine.positionCount - 1, curTouchPos);
    }

    private void DrawDot()
    {
        Poolobj drawing = GetObject();
        dotLine = drawing.GetComponent<LineRenderer>();
        dotLine.startWidth = 0.15f;
        dotLine.endWidth = 0.15f;
    }


    //TODO[이준형]: 콜라이더 이용한 머지 구현 필요
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == gameObject.layer &&
    //        collision.GetComponent<Ball>().color == color)
    //    {
    //
    //    }
    //}

    private void MergeBalls(BallThrower otherBall)
    {

    }
}
