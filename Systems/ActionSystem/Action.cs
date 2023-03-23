using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace OriOpaStudio.ActionSystem
{
    [System.Serializable]
    public class Action
    {
        private static MonoBehaviour coroutineHandler;
        [SerializeField] private string name = "New Action";
        [SerializeField] private float startTime = 0f;
        [SerializeField] private UnityEvent actions;

        public void Play()
        {
            if (coroutineHandler == null)
               coroutineHandler = GameObject.FindObjectOfType<MonoBehaviour>();

            coroutineHandler.StartCoroutine(ExecuteAction(actions, startTime));
        }

        IEnumerator ExecuteAction(UnityEvent actions, float startTime)
        {
            yield return new WaitForSeconds(startTime);
            actions.Invoke();
        }
    }
}