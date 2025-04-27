// from wlsdn629.tistory.com/entry/유니티-PlayerPrefs-초기화하는-방법

using UnityEngine;
using UnityEditor;

public class ResetPlayerPrefs : MonoBehaviour
{
    [MenuItem("Window/PlayerPrefs 초기화")]
    private static void ResetPrefs()
    {
        PlayerPrefs.DeleteAll();
        Debug.Log("PlayerPrefs has been reset.");
    }
}