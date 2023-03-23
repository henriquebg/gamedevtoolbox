using System.Collections;
using UnityEditor;
using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    [CustomEditor(typeof(Event))]
    public class EventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            var labelOptions = new GUILayoutOption[]
                                {
                                    GUILayout.Width(Screen.width * 0.2f),
                                    GUILayout.Height(20f),
                                };

            var textFieldOptions = new GUILayoutOption[]
                                    {
                                        GUILayout.Width(Screen.width * 0.37f),
                                        GUILayout.Height(20f),
                                    };

            var ev = (Event)serializedObject.targetObject;
            GUILayout.BeginHorizontal();
            GUILayout.Label("Event Name", labelOptions);
            var newEventName = EditorGUILayout.TextField(ev.EventName, textFieldOptions);
            EditorGUILayout.EndHorizontal();
            var eventNameProperty = serializedObject.FindProperty("eventName");
            eventNameProperty.stringValue = newEventName;

            serializedObject.ApplyModifiedProperties();
            
            base.OnInspectorGUI();
        }
    }
}