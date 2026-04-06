using UnityEngine;
using UnityEngine.UI;

public class AutoSetup : MonoBehaviour
{
    void Start()
    {
        SceneSetup.Instance.SetupScene();
        ConnectReactionTester();
    }

    void ConnectReactionTester()
    {
        ReactionTester tester = FindObjectOfType<ReactionTester>();
        if (tester == null)
        {
            GameObject testerObj = new GameObject("GameManager");
            tester = testerObj.AddComponent<ReactionTester>();
        }

        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) return;

        tester.titleText = FindTextByName(canvas.transform, "TitleText");
        tester.instructionText = FindTextByName(canvas.transform, "InstructionText");
        tester.resultText = FindTextByName(canvas.transform, "ResultText");
        tester.scoreText = FindTextByName(canvas.transform, "ScoreText");
        tester.bestScoreText = FindTextByName(canvas.transform, "BestScoreText");
        tester.startButton = FindButtonByName(canvas.transform, "StartButton");
        tester.resetButton = FindButtonByName(canvas.transform, "ResetButton");
        tester.backgroundImage = FindImageByName(canvas.transform, "Background");
        tester.clickArea = FindImageByName(canvas.transform, "ClickArea");
    }

    Text FindTextByName(Transform parent, string name)
    {
        Transform child = parent.Find(name);
        if (child != null)
        {
            return child.GetComponent<Text>();
        }
        return null;
    }

    Button FindButtonByName(Transform parent, string name)
    {
        Transform child = parent.Find(name);
        if (child != null)
        {
            return child.GetComponent<Button>();
        }
        return null;
    }

    Image FindImageByName(Transform parent, string name)
    {
        Transform child = parent.Find(name);
        if (child != null)
        {
            return child.GetComponent<Image>();
        }
        return null;
    }
}
