﻿using UnityEngine;

using UnityEditor;

public class DeletePrefs : EditorWindow {

[MenuItem("Edit/Reset Playerprefs")]
 
     public static void DeletePlayerPrefs()
     {
         PlayerPrefs.DeleteAll();
     }
}


