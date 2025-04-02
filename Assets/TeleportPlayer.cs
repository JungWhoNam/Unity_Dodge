using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // 충돌한 상대방 게임 오브젝트가 Player 태그를 가진 경우
        if (other.tag == "Player")
        {
            other.gameObject.transform.position = new Vector3(0, 1, 0);
        }
    }


}
