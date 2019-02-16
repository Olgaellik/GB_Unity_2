using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class MyEditor : EditorWindow
{
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Obj3;
    string _nameObject = "New editor object";
    bool groupEnabled;
    bool _randomColor = true;
    int _countObject = 1;
    //float _radius = 10;

    public Object source;

    Color[] _colors = new Color[]
    {
        Color.green, Color.black, Color.blue, Color.clear, Color.cyan, Color.red, Color.yellow, Color.white,
        Color.red
    };

    [MenuItem("MyEditor/GenerateObjects")]
    public static void ShowWindow()
    {
        var win = EditorWindow.GetWindow(typeof(MyEditor));
        win.minSize = new Vector2(600, 400);
    }

    //int _choiceIndex = 0;

    private Vector3 _minPos, _maxPos;
    
    private List<GameObject> _objs = new List<GameObject>();
    void OnGUI()
    {
        GUILayout.Label("Settings", EditorStyles.boldLabel,GUILayout.Height(30));

        //Obj1 = EditorGUILayout.Popup("Выбери объект",Obj1);
        //_choiceIndex = EditorGUILayout.Popup("Выбери объект",_choiceIndex, _choices);
        //if (_choiceIndex < 0)
        //	_choiceIndex = 0;

        Obj1 =
            EditorGUILayout.ObjectField("Object 1", Obj1, typeof(GameObject), true) as GameObject;
        Obj2 =
            EditorGUILayout.ObjectField("Object 2", Obj2, typeof(GameObject), true) as GameObject;
        Obj3 =
            EditorGUILayout.ObjectField("Object 3", Obj3, typeof(GameObject), true) as GameObject;

        GUILayout.Space(10);
        
        _minPos = EditorGUILayout.Vector3Field("Min Pos", _minPos);
        _maxPos = EditorGUILayout.Vector3Field("Max Pos", _maxPos);
        
        var objs = new List<GameObject>();
        if (Obj1!=null)
            objs.Add(Obj1);
        if (Obj2!=null)
            objs.Add(Obj2);
        if (Obj3!=null)
            objs.Add(Obj3);
        
        GUILayout.Space(10);
        _nameObject = EditorGUILayout.TextField("Object name", _nameObject);
        
        GUILayout.Space(20);
        groupEnabled = EditorGUILayout.BeginToggleGroup("More settings", groupEnabled);
        _randomColor = EditorGUILayout.Toggle("Random colour", _randomColor);
        _countObject = EditorGUILayout.IntSlider("Number of objects", _countObject, 1, 100);
        //_radius = EditorGUILayout.Slider("Радиус окружности", _radius, 10, 50);
        
        GUILayout.Space(30);
        EditorGUILayout.EndToggleGroup();
        GUI.backgroundColor = Color.green;
        if (GUILayout.Button("Generate objects", GUILayout.Height(50)))
        {
            Spawn(objs);
        }
        
        GUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.cyan;
        if (GUILayout.Button("Check and create unique names", GUILayout.Height(50)))
        {
            UniqueNames.CheckUniquenames();
        }
                
        GUI.backgroundColor = Color.grey;
        if (GUILayout.Button("Remove last created objects", GUILayout.Height(50)))
        {
            RemoveSpawn();
        }
        
        GUI.backgroundColor = Color.red;
        if (GUILayout.Button("Remove all created objects", GUILayout.Height(50)))
        {
            RemoveAllSpawn();
        }
        
        GUILayout.EndHorizontal();
    }

    void RemoveSpawn()
    {
        for (var index = _objs.Count - 1; index >= 0; index--)
        {
            var gameObject = _objs[index];
            DestroyImmediate(gameObject);
        }
    }
    
    void RemoveAllSpawn()
    {
        var objs = GameObject.FindGameObjectsWithTag("EditorObjects");
        for (var index = objs.Length - 1; index >= 0; index--)
        {
            var gameObject = objs[index];
            DestroyImmediate(gameObject);
        }
    }

    private void Spawn(List<GameObject> objs)
    {
        if (objs.Count <= 0)
        {
            Debug.LogError("No objects to spawn");
            return;
        }
        _objs.Clear();
        
        GameObject root = new GameObject("EditorObjects");
        root.tag = "EditorObjects";
        for (int i = 0; i < _countObject; i++)
        {
            //float angle = i * Mathf.PI * 2 / _countObject;
            //Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * _radius;
            var pos = new Vector3(
                Random.Range(_minPos.x, _maxPos.x),
                Random.Range(_minPos.y, _maxPos.y),
                Random.Range(_minPos.z, _maxPos.z));

            GameObject temp = Instantiate(objs[Random.Range(0, objs.Count)], pos, Quaternion.identity);
            temp.name = _nameObject + "(" + i + ")";
            temp.transform.parent = root.transform;

            var r = temp.GetComponentInChildren<Renderer>();
            _objs.Add(temp);

            if (r == null || !_randomColor) continue;
            
            var tempMaterial = new Material(r.sharedMaterial);
            tempMaterial.color = _colors[Random.Range(0, _colors.Length - 1)];
            r.sharedMaterial = tempMaterial;

            //temp.GetComponent<Renderer>().material.color = _colors[Random.Range(0, _colors.Length - 1)];
        }
    }
}