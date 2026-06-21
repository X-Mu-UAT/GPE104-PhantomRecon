using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject hudPanel;
    [SerializeField] private GameObject gameOverPanel;

    [Header("HUD Elements")]
    [SerializeField] private Slider healthSlider;

    private bool isPaused = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            ShowMainMenu();
        }
        else
        {
            ShowHUD();
        }
    }

    private void Update()
    {
        // New Input System syntax for checking if the Escape key was pressed this frame
        if (SceneManager.GetActiveScene().buildIndex != 0 && UnityEngine.InputSystem.Keyboard.current != null && UnityEngine.InputSystem.Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // --- Panel Navigation Actions --- 
    public void ShowMainMenu()
    {
        SetPanelStates(true, false, false, false);
        Time.timeScale = 1f;
    }

    public void ShowSettings()
    {
        SetPanelStates(false, true, false, false);
    }

    public void ShowHUD()
    {
        SetPanelStates(false, false, true, false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ShowGameOver()
    {
        SetPanelStates(false, false, false, true);
        Time.timeScale = 0f;
    }

    private void SetPanelStates(bool menu, bool settings, bool hud, bool over)
    {
        if (mainMenuPanel != null) mainMenuPanel.SetActive(menu);
        if (settingsPanel != null) settingsPanel.SetActive(settings);
        if (hudPanel != null) hudPanel.SetActive(hud);
        if (gameOverPanel != null) gameOverPanel.SetActive(over);
    }

    // --- Game State Loops --- 
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if (settingsPanel != null) settingsPanel.SetActive(true);
        if (hudPanel != null) hudPanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        if (settingsPanel != null) settingsPanel.SetActive(false);
        if (hudPanel != null) hudPanel.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    // --- Dynamic HUD Updates --- 
    public void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
}
