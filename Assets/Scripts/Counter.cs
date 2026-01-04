using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _delay = 0.5f;
    [SerializeField] private Color _changedColor;

    private bool _isClicked = false;
    private Color _originalColor;

    private void Start()
    {
        _text.text = "";
        _originalColor = _text.color;
        StartCoroutine(Countdown(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isClicked)
            {
                _isClicked = false;
                _text.color = _originalColor;
            }
            else
            {
                _isClicked = true;
                _text.color = _changedColor;
            }
        }

        Debug.Log(_isClicked);
    }

    private IEnumerator Countdown(float delay, int start = 100)
    {
        var wait = new WaitWhile(() => _isClicked == false);
        int currentNumber = 0;

        while (true)
        {
            DisplayCountdown(currentNumber++);
            yield return new WaitForSeconds(delay);
            yield return wait;
        }
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }
}
