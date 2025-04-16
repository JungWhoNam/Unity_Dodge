using UnityEngine;

public class VectorTest : MonoBehaviour
{
    public Transform[] pts;

    void Update()
    {
        // ù ��° ���� �� ��° ���� �մ� ������ �� �׸��� (Scene â������ Ȯ�� ����)
        // Debug.DrawLine(pts[0].position, pts[1].position, Color.red);

        // ù ��° ���� �� ��° ���� �մ� �Ķ��� �� �׸��� (Scene â������ Ȯ�� ����)
        // Debug.DrawLine(pts[0].position, pts[2].position, Color.blue);


        // TODO ���� #1:
        // ���� Debug.DrawLine(������, ����, ����) ���,
        // Debug.DrawRay(������, ����� ����, ����)�� ����Ͽ� ���� �׸�����. (Scene â������ Ȯ�� ����)
        Vector3 dir0 = pts[1].position - pts[0].position;
        Debug.DrawRay(pts[0].position, dir0, Color.red);

        Vector3 dir1 = pts[2].position - pts[0].position;
        Debug.DrawRay(pts[0].position, dir1, Color.blue);


        // TODO ���� #2:
        // �� ���͸� ��� �������� ����ϴ� ���͸� �׸���,
        // �ش� ������ ũ�Ⱑ 2�� �ǵ��� �ϼ���.
        Vector3 normal = Vector3.Cross(dir0, dir1);
        normal = normal.normalized;

        Debug.DrawRay(pts[0].position, normal * 2, Color.green);
    }
}
