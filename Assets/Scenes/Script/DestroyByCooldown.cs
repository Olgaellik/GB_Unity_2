using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByCooldown : MonoBehaviour
{


	public float TimeDestroy;
	void Start()
	{
		Invoke("DestroyLate", TimeDestroy);
	}

	void DestroyLate()
	{
		Destroy(gameObject);
	}
}
