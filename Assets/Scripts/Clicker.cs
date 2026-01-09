using UnityEngine;

public class Clicker : MonoBehaviour
{
    private const int MouseButton = 0;

    [SerializeField] private Counter _counter;

    private void Update()
    {
        if (Input.GetMouseButtonDown(MouseButton))
        {
            _counter.ChangeStatusClick();
        }
    }
}
