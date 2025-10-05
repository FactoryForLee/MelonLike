using UnityEngine;
using InGameDefine;

public class Ball : Poolobj
{
    //ref======================
    [SerializeField] private Rigidbody2D rb;
    //=====================================


    //Variables============================
    public float Weight => weight;
    public float Gravity => gravity;
    public EBallColor Color => color;

    [SerializeField] private float weight;
    [SerializeField] private float gravity;
    [SerializeField] private EBallColor color;
    //=====================================

    private void Awake()
    {
        rb.mass = Weight;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if ((col.gameObject.layer ^ gameObject.layer) == 0 &&
            TryGetComponent(out Ball ball) &&
            ball.color == color)
        {
            if(ball.color >= EBallColor.Count - 1)
            {
                gameObject.SetActive(false);
                ball.gameObject.SetActive(true);
            }

            else
            {
                Vector2 middlePos = col.transform.position + transform.position * 0.5f;

            }
        }
    }
}
