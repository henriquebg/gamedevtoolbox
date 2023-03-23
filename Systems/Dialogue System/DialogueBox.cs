using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Collections;

namespace OriOpaStudio.DialogueSystem
{
    public class DialogueBox : MonoBehaviour
    {
        [SerializeField] private Image background;
        [SerializeField] private Image avatar;
        [SerializeField] private TextMeshProUGUI speakerName;
        [SerializeField] private TextMeshProUGUI textMessage;
        [SerializeField] private UnityEvent ShowBoxEvent;
        [SerializeField] private UnityEvent HideBoxEvent;
        
        private AudioAsset currentNarration;

        public void ChangeDisplayedMessageTo(Message message)
        {
            avatar.sprite = message.Actor.Avatar;
            speakerName.text = message.Actor.Name;
            textMessage.text = message.Text;                
        }

        public void ShowBox()
        {
            ShowBoxEvent.Invoke();
        }

        public void HideBox()
        {
            HideBoxEvent.Invoke();
        }
    }
}