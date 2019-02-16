using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class BonusScript: MonoBehaviour
{
	[Range(1,10)]
	[SerializeField] private int _count = 1;
	[SerializeField] private int _offset = 1;
	[SerializeField] private GameObject _obj;
	[SerializeField] private Axis _axis;

	enum Axis
	{
		x,
		y,
		z
	}

	void Start()
	{
		CreateObj(Color.black);
	}

	public List<GameObject> CreateObj( Color color , string newName = "noname")
	{
		int x = 0;
		int y = 0;
		int z = 0;
		
		if (_axis == Axis.x)
		{
			x = _offset;
		}
		else if (_axis == Axis.y)
		{
			y = _offset;
		}
		else if (_axis == Axis.z)
		{
			z = _offset;
		}

		var l = new List<GameObject>();
		for (int i = 0; i < _count; i++)
		{
			var obj = Instantiate(_obj, new Vector3(x * i, y * i, z * i), Quaternion.identity);
			obj.name = newName;
			var r = obj.GetComponent<MeshRenderer>();
			if (r != null)
			{
				var tempMaterial = new Material(r.sharedMaterial);
				tempMaterial.color = color;
				r.sharedMaterial = tempMaterial;
			}
			l.Add(obj);
		}

		return l;
	}
}

