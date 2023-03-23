using UnityEngine;
using OriOpaStudio.ActionSystem;
using System.Collections.Generic;

namespace OriOpaStudio.DialogueSystem
{
    public class DialogueSystem : MonoBehaviour
    {
        private Dialogue currentDialogue;
        private DialogueBox dialogueBox;
        private List<ActionSystem.Event> endEvent;
        private bool dialogueEnded = false;

        void Start()
        {
            dialogueBox = GetComponentInChildren<DialogueBox>();
            endEvent = new List<ActionSystem.Event>();
        }

        public void StartConversarion(Dialogue dialogue)
        {
            currentDialogue = dialogue;
            currentDialogue.Initialize();
            dialogueBox.ChangeDisplayedMessageTo(currentDialogue.GetNextMessage());
            dialogueBox.ShowBox();
        }

        public void EndConversation()
        {
            dialogueBox.HideBox();

            foreach (var ev in endEvent)
            {
                ev.Play();
            }

            endEvent = new List<ActionSystem.Event>();
        }

        public void RegisterEndConversationEvent(ActionSystem.Event endEvent)
        {
            this.endEvent.Add(endEvent);
        }

        public void NextMessage()
        {
            if (!currentDialogue.ReachedEnd)
            {
                dialogueBox.ChangeDisplayedMessageTo(currentDialogue.GetNextMessage());
            }
            else
            {
                EndConversation();
            }
        }
    }
}