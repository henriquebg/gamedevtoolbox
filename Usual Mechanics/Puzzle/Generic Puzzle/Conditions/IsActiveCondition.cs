using UnityEngine;

[RequireComponent(typeof(IToggable))]
public class IsActiveCondition : Condition
{
    private IToggable toggableObject;
    public override bool IsFulfilled
    {
        get
        {
            return toggableObject.IsActive;
        }
    }

    private void Start()
    {
        toggableObject = GetComponent<IToggable>();
    }
}
