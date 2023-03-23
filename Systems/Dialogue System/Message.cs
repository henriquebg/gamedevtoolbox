using SimpleJSON;
using UnityEngine;

namespace OriOpaStudio.DialogueSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Message", menuName = "GameDev Toolbox/Dialogue System/Dialogue Message")]
    public class Message : ScriptableObject
    {
        [SerializeField] private Actor actor;
        [SerializeField] private string code;
        [SerializeField] private string text;

        public string Text 
        {
            get
            {
                return text;
            }
        }

        public Actor Actor { get => actor; set => actor = value; }
    }
}