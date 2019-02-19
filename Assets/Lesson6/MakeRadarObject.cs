using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lesson6;
using UnityEngine.UI;

public class MakeRadarObject : MonoBehaviour 

{

	public Image Image;

	private void Start()
	{
		Radar.RegisterRadarObject(gameObject, Image);
	}

	private void OnDestroy()
	{
		Radar.RemoveRadarObject(gameObject);
	}

}
