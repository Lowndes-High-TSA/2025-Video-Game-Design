using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Pause Screen")]
    [SerializeField]
    private Image pauseScreen;

    private void Update()
    {
        TogglePauseScreen();
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