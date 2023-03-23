using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter : MonoBehaviour
{
    [SerializeField] private string tagFilter = "Player";
    [SerializeField] private bool oneTime = false;
    [SerializeField] private UnityEvent OnEnter;

    private bool oneTimeExecuted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!oneTimeExecuted)
        {
            if (collision.CompareTag(tagFilter) && enabled)
            {
                OnEnter.Invoke();
                oneTimeExecuted = true;
            }
        }
        else if (!oneTime)
        {
            if (collision.CompareTag(tagFilter) && enabled)
            {
                OnEnter.Invoke();
                oneTimeExecuted = true;
            }
        }
    }
}
