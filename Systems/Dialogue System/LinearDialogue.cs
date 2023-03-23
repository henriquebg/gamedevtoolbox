using UnityEngine;

namespace OriOpaStudio.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Linear Dialogue", menuName = "GameDev Toolbox/Dialogue System/Linear Dialogue")]
    public class LinearDialogue : Dialogue
    {
        [SerializeField] private Message[] messages;

        private int count;

        public override bool ReachedEnd { get => count >= messages.Length; }

        public override void Initialize()
        {
            count = 0;
        }


        public override Message GetNextMessage()
        {
            if (count < messages.Length)
                return messages[count++];

            return null;
        }
    }
}