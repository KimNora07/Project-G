using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� ���� ��ư�� ���� �� ȣ���� �޼ҵ�
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}