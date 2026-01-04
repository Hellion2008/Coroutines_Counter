using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void Start()
    {
        _text.text = "";
        StartCoroutine(Countdown(1));
    }

    private IEnumerator Countdown (float delay, int start = 10)
    {
        var wait = new WaitForSeconds (delay);

        for (int i = start; i > 0; i--)
        {
            DisplayCountdown(i);
            yield return wait;
        }
    }

    private void DisplayCountdown (int count)
    {
        _text.text = count.ToString ("");
    }
}
