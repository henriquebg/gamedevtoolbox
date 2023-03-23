public interface IToggable
{
    public bool IsActive { get; }
    public void Toggle();
}
