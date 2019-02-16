using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SaveLoadObjects : EditorWindow

{
    [MenuItem("MyEditor/Save objects")]
    private static void SaveObjects()

    {
        var path = EditorUtility.SaveFilePanel("Select file", Application.dataPath, "LevelData", "xml");

        var objs = Object.FindObjectsOfType<GameObject>();
        var objsList = new List<SerializableGameObject>();

        foreach (var o in objs)
        {
            var so = new SerializableGameObject
            {
                Prefabname = o.name,
                Pos = o.transform.position,
                Rot = o.transform.rotation,
                Scale = o.transform.localScale,
                
            };

            var col = o.GetComponent<SphereCollider>();
            if (col != null)
            {
                so.Collider = true;
                so.IsTrigger = col.isTrigger;
                so.Center = col.center;
                so.Radius = col.radius;
            }
            
            objsList.Add(so);

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
            if (prefab == null)
            {
                Debug.LogWarning("Not found prefab "+o.Prefabname);
                continue;
            }
            //var tempObj = Object.Instantiate(prefab, o.Pos, o.Rot);
            var tempObj = Instantiate(prefab, o.Pos, o.Rot);
            tempObj.transform.localScale = o.Scale;
            tempObj.name = o.Prefabname;
            var sc = tempObj.GetComponent<SphereCollider>();
            
            if (sc != null && o.Collider)
            {
                sc.center = o.Center;
                sc.radius = o.Radius;
                sc.isTrigger = o.IsTrigger;
            }

        }
    }
}