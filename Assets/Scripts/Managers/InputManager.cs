using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Player Input Controls")]
    [SerializeField] private KeyCode[] swing = { KeyCode.A, KeyCode.G, KeyCode.L, KeyCode.UpArrow };
    
    [Header("UI Input Controls")]
    [SerializeField] private KeyCode pause = KeyCode.Escape;
    
    private void Update()
    {
        Pause();
        PlayerInput();
    }

    private void PlayerInput()
    {
        for (int playerIndex = 0; playerIndex < swing.Length; playerIndex++)
        {
            KeyCode playerKey = swing[playerIndex];
            if (Input.GetKeyDown(playerKey))
            {
                GameManager.instance.players[playerIndex].StartSwing();
            }
            if (Input.GetKeyUp(playerKey))
            {
                GameManager.instance.players[playerIndex].StopSwing();
            }
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(pause))
        {
            Time.timeScale = 1.0f - Time.timeScale;
        }
    }
}