using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private const int MouseButton = 0;

    [SerializeField] private float _delay = 0.5f;

    private Coroutine _coroutine;
    private bool _isClicked = false;

    public event Action<int> NumberCountChanged;

    private void Start()
    {
        _coroutine = StartCoroutine(Countdown(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            _isClicked = !_isClicked;
        }
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
                    NumberCountChanged?.Invoke(currentNumber);
                }

            yield return wait;
        }
    }

    public void OnClicked(bool isClicked)
    {
        if (isClicked)
        {
            _coroutine = StartCoroutine(Countdown(_delay));
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);
            }
        }
    }
}
