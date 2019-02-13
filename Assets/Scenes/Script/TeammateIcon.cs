using System;
using System.Collections;
using System.Collections.Generic;
using My.Objects;
using UnityEngine;

public class TeammateIcon: BaseObjectScene

{

	private TeammateModel _model;

	protected override void Awake()

	{
		base.Awake();
		_model = GetComponentInParent<TeammateModel>();
		IsVisible = false;

		TeammatesController.TeammateSelected += OnTeammateSelected;
	}

	private void OnTeammateSelected(TeammateModel teammate)

	{
		IsVisible = _model == teammate;
	}

	private void OnDestroy()
	{
		TeammatesController.TeammateSelected -= OnTeammateSelected;
	}
}
