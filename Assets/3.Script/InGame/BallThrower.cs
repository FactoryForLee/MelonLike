using InGameDefine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class BallThrower : MonoBehaviour
{
    //Preference=======================
    [SerializeField] private Transform ballSpawnPoint;
    [SerializeField] private Transform arrow;
    [SerializeField] private TrajectoryLine lineDrawer;

    public Ball ball { get; private set; }

    //=================================


    //Project Variables================
    public Vector2 ballSpawnPos { get; private set; }
    //=================================

    private void OnEnable()
    {
        ball = GetComponent<Ball>();
        arrow.gameObject.SetActive(false);
        UserInput.touchPressAction.started += TouchStarted;
        UserInput.touchPositionAction.performed += TouchPerformed;
        UserInput.touchPressAction.canceled += TouchCanceled;
        ballSpawnPos = (Vector2)ballSpawnPoint.position;
        Debug.Log("���ε� �Ϸ�");
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
        lineDrawer.StartDraw();
        Debug.Log("��ġ ����");
    }

    private void TouchPerformed(InputAction.CallbackContext context)
    {
        if (arrow.gameObject.activeSelf)
        {
            Vector2 performedTouchPos = UserInput.GetConvertedTouchPos();

            Vector2 dir = ballSpawnPos - performedTouchPos;
            float sqrMag = dir.sqrMagnitude;
            lineDrawer.Draw(sqrMag, performedTouchPos);
        }
    }

    private void TouchCanceled(InputAction.CallbackContext context)
    {
        //dir�� magnitude < 0.1f�� ���� �ʱ�
        //else ���
        lineDrawer.StopDraw();
        arrow.gameObject.SetActive(false);
    }
}
