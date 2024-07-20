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

    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject endMenu;

    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        GameManager.Instance.gameState = GameState.InGame;
        menu.SetActive(false);
    }

    public void GameOver()
    {
        GameManager.Instance.gameState = GameState.End;
        endMenu.SetActive(true);

        CalculateHighScore(playerUi.score);

        countingEffect.Play(0, playerUi.score);
    }

    private void CalculateHighScore(int score)
    {
        int highScore = PlayerPrefs.GetInt("HIGHSCORE");

        // 최고 점수보다 높은 점수를 획득했을 때
        if (score > highScore)
        {
            // 최고 점수 갱신
            PlayerPrefs.SetInt("HIGHSCORE", score);

            this.score.text = score.ToString();
        }
        else
        {
            this.score.text = highScore.ToString();
        }
    }
}
