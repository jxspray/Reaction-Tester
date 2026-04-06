using UnityEngine;
using UnityEngine.UI;

public class SceneSetup : MonoBehaviour
{
    public static SceneSetup Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetupScene()
    {
        SetupCamera();
        SetupCanvas();
        SetupUI();
    }

    private void SetupCamera()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            GameObject cameraObj = new GameObject("Main Camera");
            mainCamera = cameraObj.AddComponent<Camera>();
            cameraObj.tag = "MainCamera";
        }

        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 5;
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = new Color(0.192f, 0.302f, 0.475f);
        mainCamera.transform.position = new Vector3(0, 0, -10);
    }

    private void SetupCanvas()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null)
        {
            GameObject canvasObj = new GameObject("Canvas");
            canvas = canvasObj.AddComponent<Canvas>();
            canvasObj.AddComponent<CanvasScaler>();
            canvasObj.AddComponent<GraphicRaycaster>();
        }

        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        CanvasScaler scaler = canvas.GetComponent<CanvasScaler>();
        if (scaler != null)
        {
            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.referenceResolution = new Vector2(1920, 1080);
            scaler.matchWidthOrHeight = 0.5f;
        }
    }

    private void SetupUI()
    {
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas == null) return;

        CreateBackground(canvas.transform);
        CreateTitleText(canvas.transform);
        CreateInstructionText(canvas.transform);
        CreateResultText(canvas.transform);
        CreateScoreText(canvas.transform);
        CreateBestScoreText(canvas.transform);
        CreateStartButton(canvas.transform);
        CreateResetButton(canvas.transform);
        CreateClickArea(canvas.transform);
    }

    private void CreateBackground(Transform parent)
    {
        if (parent.Find("Background") != null) return;

        GameObject bgObj = new GameObject("Background");
        bgObj.transform.SetParent(parent, false);

        Image image = bgObj.AddComponent<Image>();
        image.color = new Color(0.2f, 0.2f, 0.2f);

        RectTransform rect = bgObj.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;
    }

    private void CreateTitleText(Transform parent)
    {
        if (parent.Find("TitleText") != null) return;

        GameObject textObj = new GameObject("TitleText");
        textObj.transform.SetParent(parent, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "反应力测试";
        text.fontSize = 60;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, 300);
        rect.sizeDelta = new Vector2(600, 100);
    }

    private void CreateInstructionText(Transform parent)
    {
        if (parent.Find("InstructionText") != null) return;

        GameObject textObj = new GameObject("InstructionText");
        textObj.transform.SetParent(parent, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "点击开始按钮开始测试";
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, 150);
        rect.sizeDelta = new Vector2(600, 60);
    }

    private void CreateResultText(Transform parent)
    {
        if (parent.Find("ResultText") != null) return;

        GameObject textObj = new GameObject("ResultText");
        textObj.transform.SetParent(parent, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "";
        text.fontSize = 100;
        text.fontStyle = FontStyle.Bold;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, 0);
        rect.sizeDelta = new Vector2(600, 150);
    }

    private void CreateScoreText(Transform parent)
    {
        if (parent.Find("ScoreText") != null) return;

        GameObject textObj = new GameObject("ScoreText");
        textObj.transform.SetParent(parent, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "";
        text.fontSize = 24;
        text.alignment = TextAnchor.UpperLeft;
        text.color = Color.white;

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0, 0.5f);
        rect.anchorMax = new Vector2(0, 0.5f);
        rect.anchoredPosition = new Vector2(100, 0);
        rect.sizeDelta = new Vector2(300, 400);
    }

    private void CreateBestScoreText(Transform parent)
    {
        if (parent.Find("BestScoreText") != null) return;

        GameObject textObj = new GameObject("BestScoreText");
        textObj.transform.SetParent(parent, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "";
        text.fontSize = 28;
        text.fontStyle = FontStyle.Bold;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = new Color(1, 0.843f, 0);

        RectTransform rect = textObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, -400);
        rect.sizeDelta = new Vector2(600, 50);
    }

    private void CreateStartButton(Transform parent)
    {
        if (parent.Find("StartButton") != null) return;

        GameObject buttonObj = new GameObject("StartButton");
        buttonObj.transform.SetParent(parent, false);

        Image image = buttonObj.AddComponent<Image>();
        image.color = new Color(0.2f, 0.6f, 0.2f);
        image.type = Image.Type.Sliced;

        Button button = buttonObj.AddComponent<Button>();
        button.targetGraphic = image;

        RectTransform rect = buttonObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, -200);
        rect.sizeDelta = new Vector2(250, 80);

        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "开始";
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;
    }

    private void CreateResetButton(Transform parent)
    {
        if (parent.Find("ResetButton") != null) return;

        GameObject buttonObj = new GameObject("ResetButton");
        buttonObj.transform.SetParent(parent, false);

        Image image = buttonObj.AddComponent<Image>();
        image.color = new Color(0.6f, 0.2f, 0.2f);
        image.type = Image.Type.Sliced;

        Button button = buttonObj.AddComponent<Button>();
        button.targetGraphic = image;

        RectTransform rect = buttonObj.GetComponent<RectTransform>();
        rect.anchorMin = new Vector2(0.5f, 0.5f);
        rect.anchorMax = new Vector2(0.5f, 0.5f);
        rect.anchoredPosition = new Vector2(0, -300);
        rect.sizeDelta = new Vector2(250, 80);

        GameObject textObj = new GameObject("Text");
        textObj.transform.SetParent(buttonObj.transform, false);

        Text text = textObj.AddComponent<Text>();
        text.text = "重置";
        text.fontSize = 36;
        text.alignment = TextAnchor.MiddleCenter;
        text.color = Color.white;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = Vector2.zero;
    }

    private void CreateClickArea(Transform parent)
    {
        if (parent.Find("ClickArea") != null) return;

        GameObject areaObj = new GameObject("ClickArea");
        areaObj.transform.SetParent(parent, false);
        areaObj.SetActive(false);

        Image image = areaObj.AddComponent<Image>();
        image.color = new Color(1, 1, 1, 0.05f);

        RectTransform rect = areaObj.GetComponent<RectTransform>();
        rect.anchorMin = Vector2.zero;
        rect.anchorMax = Vector2.one;
        rect.sizeDelta = Vector2.zero;
    }
}
