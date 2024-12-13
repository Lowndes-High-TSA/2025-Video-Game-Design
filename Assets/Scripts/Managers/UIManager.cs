using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance { get; private set; }
    
    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI timer;
    
    [Header("Pause Screen")]
    [SerializeField] private Image pauseScreen;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;
    }

    private void Update()
    {
        TogglePauseScreen();
    }

    public void UpdateTimer(int time)
    {
        int minutes = time / 60;
        int seconds = time % 60;
        timer.text = $"{minutes:00}:{seconds:00}";
    }

    public void TogglePauseScreen()
    {
        if (Mathf.Approximately(Time.timeScale, 0.0f))
        {
            pauseScreen.gameObject.SetActive(true);
        }
        if (Mathf.Approximately(Time.timeScale, 1.0f))
        {
            pauseScreen.gameObject.SetActive(false);
        }
    }
}