using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int startTime;
    public int currentTime { get; private set; }
    
    [SerializeField] private UnityEvent<int> onTimerUpdate;
    
    private void Start()
    {
        currentTime = startTime;
        StartCoroutine(Countdown());
    }

    private void Update()
    {
    }

    private IEnumerator Countdown()
    {
        while (currentTime > 0)
        {
            currentTime--;
            onTimerUpdate.Invoke(currentTime);
            yield return new WaitForSeconds(1f);
        }
    }
}