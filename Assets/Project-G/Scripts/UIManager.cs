using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public PlayerUi playerUi;

    [SerializeField] private TMP_Text score;
    [SerializeField] private CountingEffect countingEffect;
    [SerializeField]
    private ScaleEffect effectGameOver;
    [SerializeField]
    private FadeEffect effectResultGrade;
    [SerializeField]
    private TMP_Text textResultHighScore;
    [SerializeField] private TMP_Text highGrade;
    [SerializeField] private TMP_Text textResultGrade;
    [SerializeField] private TMP_Text textResultTalk;

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject endMenu;

    private void Awake()
    {
        Instance = this;
        highGrade.text = PlayerPrefs.GetString("HIGHGRADE");
    }

    public void GameStart()
    {
        GameManager.Instance.gameState = GameState.InGame;
        menu.SetActive(false);
    }

    public void GameOver()
    {
        int currentscore = playerUi.score;

        GameManager.Instance.gameState = GameState.End;
        endMenu.SetActive(true);

        CalculateHighScore(currentscore);

        CalculateGradeAndTalk(currentscore);

        effectGameOver.Play(50, 100);

        countingEffect.Play(0, playerUi.score);

        countingEffect.Play(0, currentscore, effectResultGrade.FadeIn);

    }

    private void CalculateHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        // �ְ� �������� ���� ������ ȹ������ ��
        if (score > highScore)
        {
            // �ְ� ���� ����
            PlayerPrefs.SetInt("HIGHSCORE", score);

            this.textResultHighScore.text = score.ToString();
        }
        else
        {
            this.textResultHighScore.text = highScore.ToString();
        }
    }

    public void CalculateGradeAndTalk(int score)
    {
        if (score < 1000)
        {
            textResultGrade.text = "F";
            textResultTalk.text = "�� ��\n����غ��ô�!";
        }
        else if (score < 2000)
        {
            textResultGrade.text = "D";
            textResultTalk.text = "�ƽ��׿�!";
        }
        else if (score < 3000)
        {
            textResultGrade.text = "C";
            textResultTalk.text = "�����ϴ� �����\n���Դϴ�!";
        }
        else if (score < 4500)
        {
            textResultGrade.text = "B";
            textResultTalk.text = "A�� ����\n�ʾҽ��ϴ�!";
        }
        else
        {
            textResultGrade.text = "A";
            textResultTalk.text = "A��� �޼�";
        }
    }
        public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
