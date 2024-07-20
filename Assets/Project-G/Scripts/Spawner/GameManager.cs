using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 종료 버튼을 누를 때 호출할 메소드
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}