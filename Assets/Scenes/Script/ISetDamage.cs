using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace My.Interface

{
	public interface ISetDamage
	{
		float CurrentHealth { get; }
		void ApplyDamage(float damage);
	}
}
