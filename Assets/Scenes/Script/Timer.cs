using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace My.Helper
{


	public sealed class Timer 
	{
		DateTime _start;
		float _elapsed = -1;
		private TimeSpan _duration;

		public void Start(float elapsed)
		{
			_elapsed = elapsed;
			_start = DateTime.Now;
			_duration = TimeSpan.Zero;
		}

		public void Update()
		{
			if (_elapsed > 0)
			{
				_duration = DateTime.Now - _start;

				if (_duration.TotalSeconds > _elapsed)
				{
					_elapsed = 0;
				}
			}
			else if (Math.Abs(_elapsed) < 0.001f)
			{
				_elapsed = -1;
			}
		}

		public bool IsEvent()
		{
			return Math.Abs(_elapsed) < 0.001f;
			
		}
	}
}
