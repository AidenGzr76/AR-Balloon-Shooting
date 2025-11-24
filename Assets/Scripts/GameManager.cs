using UnityEngine;
using UnityEngine.UI; // برای Text معمولی UI
using TMPro; // برای TextMeshPro

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    private int score = 0;

    private void Awake()
    {
        // الگوی ساده Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // اگه می‌خوای بین Sceneها بمونه، این خط رو فعال کن:
        // DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
            // یا مثلاً: scoreText.text = $"Score: {score}";
        }
    }
}
