using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� ���� ��ư�� ���� �� ȣ���� �޼ҵ�
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // ������ ��忡���� play ��带 �����մϴ�.
#else
        Application.Quit(); // ����� ���ø����̼ǿ����� ���ø����̼��� �����մϴ�.
#endif
    }
}