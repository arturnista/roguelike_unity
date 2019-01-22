using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(BoolReference))]
public class BoolReferenceDrawer : BaseReferenceDrawer {
    
    protected override void CreateFields(int type, Rect position, SerializedProperty property, float boolSize) {
        var fieldPosition = new Rect(position.x, position.y, position.width, position.height);
        if(type == (int)FloatReference.VariableType.Constant) {
            EditorGUI.PropertyField(fieldPosition, property.FindPropertyRelative("ConstantValue"), GUIContent.none);
        } else {
            EditorGUI.PropertyField(fieldPosition, property.FindPropertyRelative("Variable"), GUIContent.none);
        }
    }

}