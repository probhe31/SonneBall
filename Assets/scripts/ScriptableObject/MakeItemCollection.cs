using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class MakeItemCollection
{

    [MenuItem("Assets/Create/Data/ItemCollection")]
    public static void Create()
    {
        ItemCollection levelSchemaList = ScriptableObject.CreateInstance<ItemCollection>();
        AssetDatabase.CreateAsset(levelSchemaList, "Assets/ItemCollection.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = levelSchemaList;
    }

}
#endif
