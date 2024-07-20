using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private UIController uiController;
	[SerializeField]
	//private	GameObject		pattern01;

	// �÷��̾� ���� (�����ʰ� ��ƾ �ð�)
	public float CurrentScore { private set; get; } = 0;

	public bool IsGamePlay { private set; get; } = false;

	public void GameStart()
	{

	}

	public void GameExit()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.ExitPlaymode();
#else
		Application.Quit();
#endif
	}

	public void GameOver()
	{
		uiController.GameOver();
	}
}

