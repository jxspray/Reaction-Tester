using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReactionTester : MonoBehaviour
{
    public enum GameState
    {
        Waiting,
        Ready,
        Click,
        Result,
        GameOver
    }

    [Header("UI References")]
    public Text titleText;
    public Text instructionText;
    public Text resultText;
    public Text scoreText;
    public Text bestScoreText;
    public Button startButton;
    public Button resetButton;
    public Image backgroundImage;
    public Image clickArea;

    [Header("Game Settings")]
    public float minWaitTime = 1f;
    public float maxWaitTime = 4f;
    public int maxAttempts = 5;

    [Header("Colors")]
    public Color waitingColor = new Color(0.2f, 0.2f, 0.2f);
    public Color readyColor = new Color(1f, 0.8f, 0.2f);
    public Color clickColor = new Color(0.2f, 0.8f, 0.3f);
    public Color tooEarlyColor = new Color(0.8f, 0.2f, 0.2f);

    private GameState currentState;
    private float reactionTime;
    private float startTime;
    private List<float> reactionTimes = new List<float>();
    private int currentAttempt;
    private float bestTime = float.MaxValue;

    void Start()
    {
        currentState = GameState.Waiting;
        currentAttempt = 0;
        LoadBestScore();
        UpdateUI();
        startButton.onClick.AddListener(StartGame);
        resetButton.onClick.AddListener(ResetGame);
    }

    void Update()
    {
        if (currentState == GameState.Click)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                RecordReaction();
            }
        }
        else if (currentState == GameState.Ready)
        {
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            {
                TooEarly();
            }
        }
    }

    public void StartGame()
    {
        currentAttempt = 0;
        reactionTimes.Clear();
        StartNextAttempt();
    }

    private void StartNextAttempt()
    {
        currentAttempt++;
        SetState(GameState.Waiting);
        StartCoroutine(WaitForClick());
    }

    private IEnumerator WaitForClick()
    {
        yield return new WaitForSeconds(0.5f);
        SetState(GameState.Ready);

        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        if (currentState == GameState.Ready)
        {
            SetState(GameState.Click);
            startTime = Time.time;
        }
    }

    private void RecordReaction()
    {
        reactionTime = Time.time - startTime;
        reactionTimes.Add(reactionTime);
        
        if (reactionTime < bestTime)
        {
            bestTime = reactionTime;
            SaveBestScore();
        }

        SetState(GameState.Result);

        if (currentAttempt >= maxAttempts)
        {
            StartCoroutine(ShowGameOver());
        }
        else
        {
            StartCoroutine(WaitForNextAttempt());
        }
    }

    private void TooEarly()
    {
        StopAllCoroutines();
        reactionTime = -1;
        reactionTimes.Add(reactionTime);
        SetState(GameState.Result);

        if (currentAttempt >= maxAttempts)
        {
            StartCoroutine(ShowGameOver());
        }
        else
        {
            StartCoroutine(WaitForNextAttempt());
        }
    }

    private IEnumerator WaitForNextAttempt()
    {
        yield return new WaitForSeconds(2f);
        StartNextAttempt();
    }

    private IEnumerator ShowGameOver()
    {
        yield return new WaitForSeconds(1f);
        SetState(GameState.GameOver);
    }

    private void SetState(GameState newState)
    {
        currentState = newState;
        UpdateUI();
    }

    private void UpdateUI()
    {
        switch (currentState)
        {
            case GameState.Waiting:
                backgroundImage.color = waitingColor;
                titleText.text = "反应力测试";
                instructionText.text = $"第 {currentAttempt}/{maxAttempts} 次尝试";
                resultText.text = "";
                startButton.gameObject.SetActive(false);
                resetButton.gameObject.SetActive(false);
                clickArea.gameObject.SetActive(false);
                break;

            case GameState.Ready:
                backgroundImage.color = readyColor;
                titleText.text = "准备...";
                instructionText.text = "等待绿色！";
                resultText.text = "";
                clickArea.gameObject.SetActive(true);
                break;

            case GameState.Click:
                backgroundImage.color = clickColor;
                titleText.text = "点击！";
                instructionText.text = "现在点击！";
                resultText.text = "";
                break;

            case GameState.Result:
                if (reactionTime < 0)
                {
                    backgroundImage.color = tooEarlyColor;
                    titleText.text = "太快了！";
                    instructionText.text = "请等待绿色出现";
                    resultText.text = "无效";
                }
                else
                {
                    backgroundImage.color = clickColor;
                    titleText.text = "不错！";
                    instructionText.text = $"第 {currentAttempt}/{maxAttempts} 次";
                    resultText.text = $"{(reactionTime * 1000):F0} ms";
                }
                clickArea.gameObject.SetActive(false);
                break;

            case GameState.GameOver:
                backgroundImage.color = waitingColor;
                titleText.text = "游戏结束！";
                instructionText.text = GetGameSummary();
                resultText.text = "";
                startButton.gameObject.SetActive(true);
                resetButton.gameObject.SetActive(true);
                clickArea.gameObject.SetActive(false);
                break;
        }

        UpdateScoreDisplay();
    }

    private string GetGameSummary()
    {
        float total = 0;
        int validCount = 0;
        float min = float.MaxValue;
        float max = 0;

        foreach (float time in reactionTimes)
        {
            if (time > 0)
            {
                total += time;
                validCount++;
                if (time < min) min = time;
                if (time > max) max = time;
            }
        }

        if (validCount == 0)
        {
            return "没有有效的成绩";
        }

        float avg = total / validCount;
        return $"平均: {(avg * 1000):F0}ms | 最好: {(min * 1000):F0}ms | 最差: {(max * 1000):F0}ms";
    }

    private void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            string scores = "";
            for (int i = 0; i < reactionTimes.Count; i++)
            {
                string timeStr = reactionTimes[i] < 0 ? "太快" : $"{(reactionTimes[i] * 1000):F0}ms";
                scores += $"第{i + 1}次: {timeStr}\n";
            }
            scoreText.text = scores;
        }

        if (bestScoreText != null && bestTime != float.MaxValue)
        {
            bestScoreText.text = $"历史最佳: {(bestTime * 1000):F0} ms";
        }
    }

    public void ResetGame()
    {
        StopAllCoroutines();
        currentAttempt = 0;
        reactionTimes.Clear();
        currentState = GameState.Waiting;
        UpdateUI();
    }

    private void SaveBestScore()
    {
        PlayerPrefs.SetFloat("BestReactionTime", bestTime);
        PlayerPrefs.Save();
    }

    private void LoadBestScore()
    {
        if (PlayerPrefs.HasKey("BestReactionTime"))
        {
            bestTime = PlayerPrefs.GetFloat("BestReactionTime");
        }
    }
}
