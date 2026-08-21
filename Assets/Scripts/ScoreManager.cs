using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] public TMP_Text scoreInGameText;
    [SerializeField] public TMP_Text scoreInMenuText;

    static int[] scores = new int[3];

    int currentScore = 0;

    void Awake()
    {
        LoadScores();
    }

    public void ChangeScore(int value)
    {
        currentScore += value;
    }

    public void ScoreInGame()
    {
        scoreInGameText.text = "Score Table: " + currentScore;

        // Find where the new score belongs
        for (int i = 0; i < scores.Length; i++)
        {
            if (currentScore > scores[i])
            {
                // Move all lower scores one position down
                for (int j = scores.Length - 1; j > i; j--)
                {
                    scores[j] = scores[j - 1];
                }

                // Insert the new score
                scores[i] = currentScore;

                // Save the new leaderboard
                SaveScores();

                return;
            }
        }
    }
void Update()
    {
        if (scoreInGameText)
            ScoreInGame();
        if (scoreInMenuText)
            ScoreInMenu();
    }
    public void ScoreInMenu()
    {
        scoreInMenuText.text = "Highscores:\n";

        for (int i = 0; i < scores.Length; i++)
        {
            scoreInMenuText.text += $"{i + 1}. {scores[i]}\n";
        }
    }

    void SaveScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            PlayerPrefs.SetInt("Score_" + i, scores[i]);
        }

        PlayerPrefs.Save();
    }

    void LoadScores()
    {
        for (int i = 0; i < scores.Length; i++)
        {
            scores[i] = PlayerPrefs.GetInt("Score_" + i, 0);
        }
    }
}