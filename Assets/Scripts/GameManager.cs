using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ����� Ȱ��ȭ �� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ

    private float surviveTime; // ���� �ð�
    private bool isGameover; // ���� ���� ����

    void Start()
    {
        // ���� �ð��� ���� ���� ���¸� �ʱ�ȭ
        surviveTime = 0;
        isGameover = false;
    }

    void Update()
    {
        // ���� ������ �ƴ� ����
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� ���� ǥ��
            timeText.text = "Time: " + (int)surviveTime;
        }
    }

    // ���� ������ ���� ���� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���� ���� ���·� ��ȯ
        isGameover = true;
        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);
    }
}