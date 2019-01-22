using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BaseReferenceDrawer : PropertyDrawer {
    
    private readonly string[] popupOptions = 
        { "Use Constant", "Use Variable", "Use Instance" };
    /// <summary> Cached style to use to draw the popup button. </summary>
    private GUIStyle popupConstStyle;
    private GUIStyle popupVarStyle;
    private GUIStyle popupInstStyle;

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (popupConstStyle == null)
        {
            popupConstStyle = new GUIStyle(GUI.skin.GetStyle("sv_label_4"));
            popupConstStyle.imagePosition = ImagePosition.ImageOnly;
        }

        if (popupVarStyle == null)
        {
            popupVarStyle = new GUIStyle(GUI.skin.GetStyle("sv_label_6"));
            popupVarStyle.imagePosition = ImagePosition.ImageOnly;
        }

        if (popupInstStyle == null)
        {
            popupInstStyle = new GUIStyle(GUI.skin.GetStyle("sv_label_1"));
            popupInstStyle.imagePosition = ImagePosition.ImageOnly;
        }

        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        float boolSize = 20;

        var boolPosition = new Rect(position.x - boolSize, position.y, boolSize, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        SerializedProperty fieldType = property.FindPropertyRelative("Type");

        GUIStyle popupStyle = fieldType.enumValueIndex == 0 ? popupConstStyle : fieldType.enumValueIndex == 1 ? popupVarStyle : popupInstStyle;        
        int result = EditorGUI.Popup(boolPosition, fieldType.enumValueIndex, popupOptions, popupStyle);
        fieldType.enumValueIndex = result;

        CreateFields(fieldType.enumValueIndex, position, property, boolSize);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }
    
    protected virtual void CreateFields(int type, Rect position, SerializedProperty property, float boolSize) {

    }

}