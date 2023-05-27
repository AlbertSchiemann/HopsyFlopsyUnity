using UnityEngine;
using UnityEditor;
/*
[CustomEditor(typeof(GameGrid))]
public class GameGridEditor : Editor
{
    private SerializedProperty gridCellPrefab;
    
    private void OnEnable()
    {
        gridCellPrefab = serializedObject.FindProperty("gridCellPrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        
        EditorGUILayout.PropertyField(gridCellPrefab);
        
        if (GUILayout.Button("Open Tile Editor"))
        {
            GridTileEditorWindow.OpenWindow((GameGrid)target);
        }
        
        serializedObject.ApplyModifiedProperties();
    }
}
*/