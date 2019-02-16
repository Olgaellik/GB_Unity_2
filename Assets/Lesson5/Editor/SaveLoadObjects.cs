using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoadObjects

{
  [MenuItem("MyEditor/Save objects")]
  private static void SaveObjects()

  {
    var path = EditorUtility.SaveFilePanel("Select file", Application.dataPath, "LevelData", "xml");

    var objs = Object.FindObjectsOfType<GameObject>();
    var objsList = new List<SerializableGameObject>();

    foreach (var o in objs)
    {
      objsList.Add(new SerializableGameObject

        {
          Prefabname = o.name,
          Pos = o.transform.position,
          Rot = o.transform.rotation,
          Scale = o.transform.localScale
        }
      );

      SerializableToXML.Save(objsList.ToArray(), path);

    }
  }

  [MenuItem("MyEditor/Load objects")]
  private static void LoadObjects()
  {
    var path = EditorUtility.OpenFilePanel("Select file", Application.dataPath, "xml");
    var objs = SerializableToXML.Load(path);

    foreach (var o in objs)
    {
      var prefab = Resources.Load<GameObject>(o.Prefabname);
      var tempObj = Object.Instantiate(prefab, o.Pos, o.Rot);
      tempObj.transform.localScale = o.Scale;
      tempObj.name = o.Prefabname;
    }
  }


}
