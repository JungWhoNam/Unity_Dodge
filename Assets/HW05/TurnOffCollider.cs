using UnityEngine;

public class TrunOffCollider : MonoBehaviour
{
    // 스타터 코드
    // BoxCollider 컴포넌트를 담을 변수 (Inspector에서 할당 가능)
    public BoxCollider boxCollider;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { // 스페이스바가 눌리면 실행
            boxCollider.enabled = false; // BoxCollider를 비활성화 (충돌 감지 OFF)
            Debug.Log("BoxCollider가 비활성화되었습니다."); // 콘솔에 메시지 출력
        }
    }


    //// 방법 #1
    //public BoxCollider collider0;
    //public SphereCollider collider1;
    //public CapsuleCollider collider2;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        collider0.enabled = false;
    //        collider1.enabled = false;
    //        collider2.enabled = false;
    //    }
    //}

    //// 방법 #2 - 배열 사용
    //public Collider[] colliders;

    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        foreach (Collider c in colliders)
    //        {
    //            c.enabled = false;
    //        }
    //    }
    //}
}