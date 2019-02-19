using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseController : MonoBehaviour 

{
	public bool Enabled { get; private set; }

	public virtual void On()
	{
		Enabled = true;
	}
	public virtual void Off()
		
	{
		Enabled = false;
	}
}
