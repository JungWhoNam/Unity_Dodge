using UnityEngine;

public class VectorTest : MonoBehaviour
{
    public Transform[] pts;

    void Update()
    {
        // 첫 번째 점과 두 번째 점을 잇는 빨간색 선 그리기 (Scene 창에서만 확인 가능)
        // Debug.DrawLine(pts[0].position, pts[1].position, Color.red);

        // 첫 번째 점과 세 번째 점을 잇는 파란색 선 그리기 (Scene 창에서만 확인 가능)
        // Debug.DrawLine(pts[0].position, pts[2].position, Color.blue);


        // TODO 과제 #1:
        // 위의 Debug.DrawLine(시작점, 끝점, 색상) 대신,
        // Debug.DrawRay(시작점, 방향과 길이, 색상)을 사용하여 선을 그리세요. (Scene 창에서만 확인 가능)
        Vector3 dir0 = pts[1].position - pts[0].position;
        Debug.DrawRay(pts[0].position, dir0, Color.red);

        Vector3 dir1 = pts[2].position - pts[0].position;
        Debug.DrawRay(pts[0].position, dir1, Color.blue);


        // TODO 과제 #2:
        // 두 벡터를 모두 수직으로 통과하는 벡터를 그리고,
        // 해당 벡터의 크기가 2가 되도록 하세요.
        Vector3 normal = Vector3.Cross(dir0, dir1);
        normal = normal.normalized;

        Debug.DrawRay(pts[0].position, normal * 2, Color.green);
    }
}
