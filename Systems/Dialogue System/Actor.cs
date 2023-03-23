using UnityEngine;

namespace OriOpaStudio.DialogueSystem
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Actor", menuName = "GameDev Toolbox/Dialogue Actor")]
    public class Actor : ScriptableObject
    {
        [SerializeReference] private string actorName;
        [SerializeReference] private Sprite avatar;

        public string Name { get => actorName; set => actorName = value; }
        public Sprite Avatar { get => avatar; set => avatar = value; }
    }
}