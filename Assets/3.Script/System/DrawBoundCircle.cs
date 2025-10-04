using UnityEngine;
using UnityEditor;

[RequireComponent(typeof(EdgeCollider2D))]
public class DrawBoundCircle : MonoBehaviour
{
    // 인스펙터 창에서 조절할 수 있는 변수들

    [SerializeField] private BoundSO boundData;

    // 컴포넌트 위에 우클릭 메뉴를 추가해주는 편리한 기능입니다.

    public void GenerateCircle()
    {
        EdgeCollider2D edgeCollider = GetComponent<EdgeCollider2D>();

        // pointCount + 1 만큼의 배열을 생성 (+1은 루프를 닫기 위함)
        Vector2[] points = new Vector2[boundData.PointCount + 1];

        for (int i = 0; i < boundData.PointCount; i++)
        {
            // 360도를 pointCount 만큼 나눔
            float angle = (float)i / boundData.PointCount * 360 * Mathf.Deg2Rad;

            // 삼각함수를 이용해 원 위의 점 좌표를 계산
            float x = Mathf.Cos(angle) * boundData.Radius;
            float y = Mathf.Sin(angle) * boundData.Radius;

            points[i] = new Vector2(x, y);
        }

        // 마지막 점을 첫 번째 점과 똑같이 설정하여 경계선을 닫아줍니다. (매우 중요)
        points[boundData.PointCount] = points[0];

        // 계산된 점들을 EdgeCollider2D에 적용
        edgeCollider.points = points;
    }
}



// EdgeCollider2D 컴포넌트가 반드시 필요하다고 명시합니다.
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