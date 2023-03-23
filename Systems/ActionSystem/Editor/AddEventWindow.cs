using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    public class AddEventWindow : EditorWindow
    {
        private Event[] events;
        private Sequencer sequencer;
        IEnumerable<Event> query;

        public Sequencer Sequencer { get { return sequencer; } set { sequencer = value; } }

        public static AddEventWindow ShowWindow()
        {
            var window = GetWindow<AddEventWindow>(utility: true, title: "Localization System");
            window.Show();
            return window;
        }

        private void OnEnable()
        {
            events = FindObjectsOfType<Event>();
            query = events.OrderBy(ev => ev.OwnerName);
        }

        private void OnGUI()
        {
            foreach (var ev in query)
            {
                var eventInfos = $"{ev.OwnerName}: {ev.EventName}";
                var buttonOptions = GUILayout.Width(position.width);

                if (GUILayout.Button(text: eventInfos, buttonOptions))
                {
                    var serializedSequencer = new SerializedObject(sequencer);
                    serializedSequencer.Update();
                    var timelineProperty = serializedSequencer.FindProperty("timeline");
                    timelineProperty.arraySize++;
                    var eventProperty = timelineProperty.GetArrayElementAtIndex(timelineProperty.arraySize - 1).FindPropertyRelative("keyframeEvent");
                    eventProperty.objectReferenceValue = ev;
                    serializedSequencer.ApplyModifiedProperties();
                    Close();
                }
            }
        }
    }
}