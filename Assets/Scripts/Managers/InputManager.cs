using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [Header("Player Input Controls")]
    [SerializeField] private InputAction swing;
    
    [Header("UI Input Controls")]
    [SerializeField] private InputAction pause;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("fire!");
            Time.timeScale = 1.0f - Time.timeScale;
        }
    }
}