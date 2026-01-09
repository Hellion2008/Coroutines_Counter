using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Color _counterWorkColor = Color.green;

    private Color _originalColor;

    private void OnEnable()
    {
        _counter.NumberCountChanged += DisplayCountdown;
    }

    private void Start()
    {
        _text.text = "";
        _originalColor = Color.gray;
    }

    private void OnDisable()
    {
        _counter.NumberCountChanged -= DisplayCountdown;
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");

        if (_counter.IsClicked)
        {
            ChangeColor(_counterWorkColor);
        }
        else
        {
            ChangeColor(_originalColor);
        }
    }

    private void ChangeColor(Color color)
    {
        _text.color = color;
    }
}
