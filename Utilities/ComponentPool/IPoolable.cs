using UnityEngine;

public interface IPoolable
{
    public bool IsAvailable();
    public Component GetComponent();
}
