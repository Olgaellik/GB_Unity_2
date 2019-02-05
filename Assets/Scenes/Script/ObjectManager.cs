using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController;

	/// <summary>
	/// Класс для хранения ссылок на объекты
	/// </summary>
	public class ObjectManager : MonoBehaviour
	{ 
		[SerializeField] private Ammunition[] _ammunitionList = new Ammunition[5]; 
		[SerializeField] private Weapon[] _weaponsList = new Weapon [5];
		#region Property	
		public Weapon[] GetWeaponsList
		{
			get { return _weaponsList; }
		}
		public Ammunition[] GetAmmunitionList
		{
			get { return _ammunitionList; }
		} 
		#endregion

		private void Start()
		{
			foreach (var weapon in _weaponsList)
			{
				weapon.gameObject.SetActive(false);
			}
		}
	}




