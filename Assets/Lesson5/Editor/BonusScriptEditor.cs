using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomEditor(typeof(BonusScript))]
public class BonusScriptEditor : Editor

{
	bool _isPressButton;
	private string objname = "";
	private Color _color = Color.red;

	private List<GameObject> _ojs;
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
		
		BonusScript testTarget = (BonusScript) target;

		//objname = GUILayout.TextField(objname);
		objname = EditorGUILayout.TextField("Name" , objname);
		_color = EditorGUILayout.ColorField("Color " , _color);

		var isPressButton = GUILayout.Button("Generate object", EditorStyles.miniButton);

		if (isPressButton)
		{
			_ojs = testTarget.CreateObj(_color, objname);
			_isPressButton = true;
		}

		if (_isPressButton)
		{
			EditorGUILayout.HelpBox("Generated objects with name "+objname, MessageType.Warning);
		}
		GUI.backgroundColor = Color.red;
		if (_ojs!=null && _ojs.Count > 0)
		{
			EditorGUILayout.LabelField("Объектов " + _ojs.Count);
			if (GUILayout.Button("Удалить 1 объект", EditorStyles.miniButton))
			{
				var o = _ojs[_ojs.Count - 1];
				_ojs.Remove(o);
				DestroyImmediate(o);
			}
			
		}

	}
}
