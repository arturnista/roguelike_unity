using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(FloatRangeReference))]
public class FloatRangeReferenceDrawer : BaseReferenceDrawer {
    
    protected override void CreateFields(int type, Rect position, SerializedProperty property, float boolSize) {

        var fieldPosition = new Rect(position.x, position.y, position.width, position.height);

        var labelSize = 28;
        var fieldSize = position.width / 2 - labelSize;
        var minLabelPosition = new Rect(position.x, position.y, labelSize, position.height);
        var minFieldPosition = new Rect(position.x + labelSize, position.y, fieldSize, position.height);

        var maxLabelPosition = new Rect(position.x + fieldSize + labelSize, position.y, labelSize, position.height);
        var maxFieldPosition = new Rect(position.x + fieldSize + labelSize * 2, position.y, fieldSize, position.height);

        if(type == (int)FloatRangeReference.VariableType.Constant) {
            EditorGUI.LabelField(minLabelPosition, "Min");
            EditorGUI.PropertyField(minFieldPosition, property.FindPropertyRelative("ConstantMinValue"), GUIContent.none);

            EditorGUI.LabelField(maxLabelPosition, "Max");
            EditorGUI.PropertyField(maxFieldPosition, property.FindPropertyRelative("ConstantMaxValue"), GUIContent.none);
        } else {
            EditorGUI.PropertyField(fieldPosition, property.FindPropertyRelative("Variable"), GUIContent.none);
        }

    }

}