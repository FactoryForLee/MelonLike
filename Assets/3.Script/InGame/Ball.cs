using UnityEngine;

public class Ball : MonoBehaviour
{
    public float Weight => weight;
    public float Gravity => gravity;

    [SerializeField] private float weight;
    [SerializeField] private float gravity;
}
