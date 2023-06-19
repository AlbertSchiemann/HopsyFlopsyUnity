using UnityEngine;
using UnityEditor;
/*
public class GridTileEditorWindow : EditorWindow
{
    private GameGrid gameGrid;
    private bool[] tileSettings;
    
    private static GridTileEditorWindow window;

    public static void OpenWindow(GameGrid grid)
    {
        window = GetWindow<GridTileEditorWindow>();
        window.titleContent = new GUIContent("Tile Editor");
        window.gameGrid = grid;
        window.tileSettings = new bool[grid.width * grid.length];
        window.Show();
    }

    private void OnGUI()
    {
        if (gameGrid == null)
        {
            Close();
            return;
        }

        GUILayout.Label("Tile Settings", EditorStyles.boldLabel);

        int index = 0;
        for (int z = 0; z < gameGrid.length; z++)
        {
            EditorGUILayout.BeginHorizontal();

            for (int x = 0; x < gameGrid.width; x++)
            {
                tileSettings[index] = EditorGUILayout.Toggle(tileSettings[index]);

                index++;
            }

            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();

        if (GUILayout.Button("Apply Changes"))
        {
            ApplyTileSettings();
        }
    }

    private void ApplyTileSettings()
    {
        if (gameGrid == null || tileSettings == null || tileSettings.Length != gameGrid.width * gameGrid.length)
        {
            return;
        }

        for (int z = 0; z < gameGrid.length; z++)
        {
            for (int x = 0; x < gameGrid.width; x++)
            {
                int index = x + z * gameGrid.width;
                GameObject gridCell = gameGrid.GetGridCell(x, z);

                if (gridCell != null)
                {
                    GridCell cellScript = gridCell.GetComponent<GridCell>();
                    if (cellScript != null)
                    {
                        cellScript.isOccupied = tileSettings[index];
                    }
                }
            }
        }

        EditorUtility.SetDirty(gameGrid);
        AssetDatabase.SaveAssets();
    }
}
*/