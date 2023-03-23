using UnityEngine;

namespace OriOpaStudio.DialogueSystem
{
    public abstract class Dialogue : ScriptableObject
    {
        public virtual bool ReachedEnd { get; }

        public abstract void Initialize();
        public abstract Message GetNextMessage();
    }
}