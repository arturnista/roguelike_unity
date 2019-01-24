using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(DataHolderItem))]
public class DataHolderItemDrawer : PropertyDrawer {

    // Draw the property inside the given rect
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Properties
        var typeProperty = property.FindPropertyRelative("Name");
        var variableProperty = property.FindPropertyRelative("Variable");

        // Draw label
        // GUIContent labelContent = new GUIContent();
        // labelContent.text = typeProperty.objectReferenceValue ? typeProperty.objectReferenceValue.name : "Undefined type";
        // position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), labelContent);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        var halfWidth = position.width / 2;

        var typePosition = new Rect(position.x, position.y, halfWidth, position.height);
        var variablePosition = new Rect(position.x + halfWidth, position.y, halfWidth, position.height);

        EditorGUI.PropertyField(typePosition, typeProperty, GUIContent.none);
        EditorGUI.PropertyField(variablePosition, variableProperty, GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
    }

}