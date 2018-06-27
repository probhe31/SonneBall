using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;

public class MakeCharacterCollection
{

    [MenuItem("Assets/Create/Data/CharacterCollection")]
    public static void Create()
    {
        CharacterCollection characterList = ScriptableObject.CreateInstance<CharacterCollection>();
        AssetDatabase.CreateAsset(characterList, "Assets/CharacterCollection.asset");
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = characterList;
    }

}
#endif