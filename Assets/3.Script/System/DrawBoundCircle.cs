using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(EdgeCollider2D))]
public class DrawBoundCircle : MonoBehaviour
{
    // �ν����� â���� ������ �� �ִ� ������

    [SerializeField] private BoundSO boundData;

    // ������Ʈ ���� ��Ŭ�� �޴��� �߰����ִ� ���� ����Դϴ�.

    public void GenerateCircle()
    {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        // pointCount + 1 ��ŭ�� �迭�� ���� (+1�� ������ �ݱ� ����)
        Vector2[] points = new Vector2[boundData.PointCount + 1];

        for (int i = 0; i < boundData.PointCount; i++)
        {
            // 360���� pointCount ��ŭ ����
            float angle = (float)i / boundData.PointCount * 360 * Mathf.Deg2Rad;

            // �ﰢ�Լ��� �̿��� �� ���� �� ��ǥ�� ���
            float x = Mathf.Cos(angle) * boundData.Radius;
            float y = Mathf.Sin(angle) * boundData.Radius;

            points[i] = new Vector2(x, y);
        }

        // ������ ���� ù ��° ���� �Ȱ��� �����Ͽ� ��輱�� �ݾ��ݴϴ�. (�ſ� �߿�)
        points[boundData.PointCount] = points[0];

        // ���� ������ EdgeCollider2D�� ����
        edgeCollider.points = points;
    }
}



// EdgeCollider2D ������Ʈ�� �ݵ�� �ʿ��ϴٰ� ����մϴ�.
[CustomEditor(typeof(DrawBoundCircle))]
public class CircleWallGenerator : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.Space();

        DrawBoundCircle drawer = (DrawBoundCircle)target;

        if (GUILayout.Button("Generate Circle"))
            drawer.GenerateCircle();
    }
}