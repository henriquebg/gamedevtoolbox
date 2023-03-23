using UnityEngine;
using UnityEngine.Events;

public class OnTriggerExit : MonoBehaviour
{ 
    [SerializeField] private string tagFilter = "Player";
    [SerializeField] private UnityEvent OnEnter;

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(tagFilter) && enabled)
        {
            OnEnter.Invoke();
        }
    }
}