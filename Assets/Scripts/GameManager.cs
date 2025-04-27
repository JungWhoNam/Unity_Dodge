using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� ���� ���̺귯��
using TMPro; // TextMeshPro ���̺귯��

public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���ӿ����� Ȱ��ȭ �� �ؽ�Ʈ ���� ������Ʈ
    public TMP_Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public TMP_Text recordText; // �ְ� ����� ǥ���� �ؽ�Ʈ ������Ʈ
    public TMP_Text hpText; // HP ǥ���� �ؽ�Ʈ ������Ʈ

    public PlayerController playerController;

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
        hpText.text = "HP: " + playerController.GetHealth().ToString();

        // ���� ������ �ƴ� ����
        if (!isGameover)
        {
            // ���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� ���� ǥ��
            timeText.text = "Time: " + (int)surviveTime;

            if (PlayerPrefs.GetFloat("BestTime") < surviveTime)
            {
                timeText.text += " (NEW)";
            }
        }
        else
        {
            // ���� ������ ���¿��� Ű���� RŰ�� ���� ���
            if (Input.GetKeyDown(KeyCode.R))
            {
                // SampleScene ���� �ε�
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
    // ���� ������ ���� ���� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        // ���� ���¸� ���� ���� ���·� ��ȯ
        isGameover = true;
        // ���� ���� �ؽ�Ʈ ���� ������Ʈ�� Ȱ��ȭ
        gameoverText.SetActive(true);

        // BestTime Ű�� �����, ���������� �ְ� ��� ��������
        float bestTime = PlayerPrefs.GetFloat("BestTime");

        // ���������� �ְ� ��Ϻ��� ���� ���� �ð��� �� ũ�ٸ�
        if (surviveTime > bestTime)
        {
            // �ְ� ����� ���� ���� ���� �ð��� ������ ���� 
            bestTime = surviveTime;
            // ����� �ְ� ����� BestTime Ű�� ����
            PlayerPrefs.SetFloat("BestTime", bestTime);
        }

        // �ְ� ����� recordText �ؽ�Ʈ ������Ʈ�� ���� ǥ��
        recordText.text = "Best Time: " + (int)bestTime;
    }
}