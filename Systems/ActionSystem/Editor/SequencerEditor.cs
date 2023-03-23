using UnityEditor;
using UnityEngine;

namespace OriOpaStudio.ActionSystem
{
    [CustomEditor(typeof(Sequencer))]
    public class SequencerEditor : Editor
    {
        private SerializedProperty timelineProperty;
        private GUILayoutOption[] startTimeOptions;
        private GUILayoutOption[] startTimeTextOptions;
        private GUILayoutOption[] ownerOptions;
        private GUILayoutOption[] labelOptions;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            ConfigureElements();
            ShowHeader();
            GUILayout.Space(10);
            ShowTimeline();
            serializedObject.ApplyModifiedProperties();
        }              

        private void ShowHeader()
        {
            if (GUILayout.Button("Add Event"))
            {
                var window = AddEventWindow.ShowWindow();
                window.Sequencer = target as Sequencer;
            }

            if (GUILayout.Button("Clear Event List"))
            {
                timelineProperty.ClearArray();
            }
        }

        private void ConfigureElements()
        {
            timelineProperty = serializedObject.FindProperty("timeline");

            startTimeOptions = 
                new GUILayoutOption[]
                {
                    GUILayout.Width(Screen.width * 0.1f),
                    GUILayout.Height(20f),
                };

            startTimeTextOptions =
                new GUILayoutOption[]
                {
                    GUILayout.Width(Screen.width * 0.1f),
                    GUILayout.Height(20f),
                };

            ownerOptions = 
                new GUILayoutOption[]
                {
                    GUILayout.Width(Screen.width * 0.2f),
                    GUILayout.Height(20f),
                };

            labelOptions = 
                new GUILayoutOption[]
                {
                    GUILayout.Width(Screen.width * 0.37f),
                    GUILayout.Height(20f),
                };
        }

        private void ShowTimeline()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Time", startTimeOptions);
            GUILayout.Label("Owner", ownerOptions);
            GUILayout.Label("Event", labelOptions);
            EditorGUILayout.EndHorizontal();

            for (int i = 0; i < timelineProperty.arraySize; i++)
            {
                var keyframeProperty = timelineProperty.GetArrayElementAtIndex(i);
                var startTimeProperty = keyframeProperty.FindPropertyRelative("startTime");
                var eventProperty = keyframeProperty.FindPropertyRelative("keyframeEvent");
                var ev = (Event) eventProperty.objectReferenceValue;
                
                if (ev != null)
                {
                    GUILayout.BeginHorizontal();
                    startTimeProperty.floatValue = EditorGUILayout.FloatField(startTimeProperty.floatValue, startTimeTextOptions);
                    GUILayout.Label(ev.OwnerName, ownerOptions);
                    GUILayout.Label(ev.EventName, labelOptions);
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
    }
}