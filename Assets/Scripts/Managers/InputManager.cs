using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [Header("Player Input Controls")]
    [SerializeField] private KeyCode[] swing = { KeyCode.A, KeyCode.G, KeyCode.L, KeyCode.UpArrow };
    
    [Header("UI Input Controls")]
    [SerializeField] private KeyCode pause = KeyCode.Escape;
    
    [Header("Game Events")]
    [SerializeField] private UnityEvent onSwingStart;
    [SerializeField] private UnityEvent onSwingEnd;
    
    private void Update()
    {
        if (Input.GetKeyDown(pause))
        {
            Time.timeScale = 1.0f - Time.timeScale;
        }
        if (Input.GetKeyDown(swing[0]))
        {
            onSwingStart.Invoke();
        }
        if (Input.GetKeyUp(swing[0]))
        {
            onSwingEnd.Invoke();
        }
    }
}