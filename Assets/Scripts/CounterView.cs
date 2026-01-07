using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    private const int MouseButton = 0;

    [SerializeField] private Counter _counter;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Color _changedColor = Color.green;

    private Color _originalColor;
    private bool _isClicked = false;

    private void Start()
    {
        _text.text = "";
        _originalColor = _text.color;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            _isClicked = !_isClicked;

            if (_isClicked)
            {
                ChangeColor(_changedColor);
            }
            else
            {
                ChangeColor(_originalColor);
            }
        }
    }

    private void OnEnable()
    {
        _counter.NumberCountChanged += DisplayCountdown;
    }

    private void OnDisable()
    {
        _counter.NumberCountChanged -= DisplayCountdown;
    }

    private void DisplayCountdown(int count)
    {
        _text.text = count.ToString("");
    }

    private void ChangeColor(Color color)
    {
        _text.color = color;
    }
}
