using UnityEngine;
using UnityEditor;
using System.Globalization;
using System.Collections.Generic;

public class LanguagesConfigWindow : EditorWindow
{
    private HashSet<Language> _languages;
    private HashSet<Language> _selectedLanguages;
    private Vector2 _scrollPos = Vector2.zero;

    [MenuItem("Localization/Language Settings")]
    static void InitializeWindow()
    {
        var window = GetWindow<LanguagesConfigWindow>(utility: true, title: "Localization System");
        window.Show();
    }

    private void Awake()
    {
        var cultureInfos = CultureInfo.GetCultures(CultureTypes.AllCultures);
        _languages = new HashSet<Language>();

        for (int i = 1; i < cultureInfos.Length; i++)
        {
            var lang = new Language(cultureInfos[i].EnglishName, cultureInfos[i].Name);
            _languages.Add(lang);
        }

        _selectedLanguages = new HashSet<Language>();
    }

    private void OnGUI()
    {
        string txtLang = EditorGUILayout.TextField("");

        _scrollPos = EditorGUILayout.BeginScrollView(_scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height * 0.45f));

        foreach (var lang in _languages)
        {
            if (lang.Name.Contains(txtLang))
            {
                if (GUILayout.Button(text: lang.Name, GUILayout.Width(position.width * 0.93f)))
                {
                    _selectedLanguages.Add(lang);
                }
            }
        }
        
        EditorGUILayout.EndScrollView();

        EditorGUILayout.Space(10);

        foreach (var selectLang in _selectedLanguages)
        {
            if (GUILayout.Button(text: selectLang.Name))
            {
                _selectedLanguages.Remove(selectLang);
            }
        }
    }
}
