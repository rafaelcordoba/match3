using System;
using System.Collections;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Tester : MonoBehaviour
{
    [SerializeField] private bool _useTask;
    [SerializeField] private int _delay;
    
    void Start()
    {
        if (_useTask)
            LogTask();
        else
            StartCoroutine(LogCoroutine());
    }

    private void Update()
    {
        Debug.Log("update");
    }

    private void FixedUpdate()
    {
        Debug.Log("fixed update");
    }

    IEnumerator LogCoroutine()
    {
        Debug.Log("LogCoroutine Before");
        yield return new WaitForSeconds(_delay);
        Debug.Log("LogCoroutine After");
    }

    async void LogTask()
    {
        Debug.Log("UniTask Before");
        await Task.Delay(TimeSpan.FromSeconds(_delay));
        Debug.Log("UniTask After");
    }
}
