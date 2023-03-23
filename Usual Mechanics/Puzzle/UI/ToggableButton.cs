using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class ToggableButton : MonoBehaviour, IToggable
{
    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    private bool isActive;
    private Button button;
    public bool IsActive => isActive;
    
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Toggle);
    }

    private void OnEnable()
    {
        isActive = true;
        Toggle();
    }

    public void Toggle()
    {
        if (isActive)
            onDeactivate.Invoke();
        else
            onActivate.Invoke();

        isActive = !isActive;
    }

    public void Deactivate()
    {
        if (!isActive)
            return;

        onDeactivate.Invoke();
        isActive = false;
    }
}
