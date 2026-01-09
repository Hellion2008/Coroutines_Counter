using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private bool _isClicked = false;

    public bool IsClicked
    { 
        get 
        { 
            return _isClicked; 
        }
    }

    public event Action<int> NumberCountChanged;

    private void Start()
    {
        _coroutine = StartCoroutine(Countdown(_delay));
    }

    public void ChangeStatusClick()
    {
        _isClicked = !_isClicked;
    }

    private IEnumerator Countdown(float delay)
    {
        var wait = new WaitForSeconds(delay);
        int currentNumber = 0;

        while (enabled)
        {
            if (_isClicked)
            {
                currentNumber++;               
            }

            NumberCountChanged?.Invoke(currentNumber);
            yield return wait;
        }
    }
}
