using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int startTime;
    public int currentTime { get; private set; }
    
    private Action _onTimerStart;
    private Action<int> _onTimerUpdate;
    private Action _onTimerEnd;
    
    private void Start()
    {
        // The events are assigned.
        _onTimerUpdate += UIManager.instance.UpdateTimer;
        _onTimerEnd += GameManager.instance.OnEnd;
        // The timer is initiated.
        StartCoroutine(Countdown());
    }

    private void Update()
    {
    }

    private IEnumerator Countdown()
    {
        _onTimerStart?.Invoke();
        _onTimerUpdate?.Invoke(currentTime);
        
        currentTime = startTime;
        while (currentTime > 0)
        {
            currentTime--;
            _onTimerUpdate?.Invoke(currentTime);
            yield return new WaitForSeconds(1f);
        }
        
        _onTimerEnd?.Invoke();
    }
}