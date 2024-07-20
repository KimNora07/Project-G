using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 종료 버튼을 누를 때 호출할 메소드
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터 모드에서는 play 모드를 중지합니다.
#else
        Application.Quit(); // 빌드된 애플리케이션에서는 애플리케이션을 종료합니다.
#endif
    }
}