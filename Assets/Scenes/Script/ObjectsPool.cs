using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using My.Interface;
using UnityEngine;

public class ObjectsPool : MonoBehaviour
{

	public static ObjectsPool Instance { get; private set; }

	[SerializeField] private GameObject[] objects;
	private Dictionary<string, Queue<Ipoolable>> objectsDict = new Dictionary<string, Queue<Ipoolable>>();

	private void Awake()

	{
		if (Instance) DestroyImmediate(gameObject);
		else Instance = this;
	}

	private void Start()
	{
		foreach (var o in objects)
		{
			var poolobj = o.GetComponent<Ipoolable>();
			if (poolobj == null) continue;
			if (objectsDict.ContainsKey(poolobj.PoolID))

			{
				Debug.LogWarning($"Pool already contains this obj");
				continue;
			}

			var queue = new Queue<Ipoolable>();
			for (int i = 0; i < poolobj.ObjectsCount; i++)

			{
				var go = Instantiate(o);
				go.SetActive(false);
				queue.Enqueue(go.GetComponent<Ipoolable>());
			}

			objectsDict.Add(poolobj.PoolID, queue);
		}

	}

	public Ipoolable GetObject(string poolID)

	{
		if (string.IsNullOrEmpty(poolID)) return null;
		if (!objectsDict.ContainsKey(poolID)) return null;

		var p = objectsDict[poolID].Dequeue();
		objectsDict[poolID].Enqueue(p);

		return p;
	}
}
