using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private Condition[] conditions;
    [SerializeField] private UnityEvent whenSolved;
    [SerializeField] private UnityEvent whenWrong;

    public void CheckSolution()
    {
        bool solved = true;

        foreach (var condition in conditions)
        {
            solved &= condition.IsFulfilled;
        }

        if (solved)
            whenSolved.Invoke();
        else
            whenWrong.Invoke();
    }
}
