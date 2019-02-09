using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammatesController : MonoBehaviour
{
	public static event Action<TeammateModel> TeammateSelected;

	private TeammateModel currentTeammate;

	public void MoveCommand()

	{
		Debug.Log("MoveCommand");
		RaycastHit hit;
		if (Camera.main != null)
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log("Raycast ok "+hit);
				var teammate = hit.collider.GetComponent<TeammateModel>();
				if (teammate) SelectTeammate(teammate);
				else if (currentTeammate) currentTeammate.SetDestination(hit.point);
			}
		}
		else
		{
			Debug.LogWarning("Camera.main null");
		}
	}

	public void SelectTeammate(TeammateModel teammate)

	{
		currentTeammate = teammate;
		TeammateSelected?.Invoke(currentTeammate);
	}
}
