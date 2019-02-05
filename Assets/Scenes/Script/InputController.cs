using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyController;
using My.Helper;


public class InputController : BaseController
{
    private bool _isActiveFlashlight = false;
    private bool _isSelectWeapons = true;
    private int _indexWeapons = 0;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isActiveFlashlight = !_isActiveFlashlight;
            if (_isActiveFlashlight)
            {
                Main.Instance.GetTorchController.On();
            }
            else
            {
                Main.Instance.GetTorchController.Off();
            }
        }

        // Меняем оружие по нажатию клавиш
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _indexWeapons = 0;
            _isSelectWeapons = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _indexWeapons = 1;
            _isSelectWeapons = false;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            _indexWeapons += 1;
            _isSelectWeapons = false;
        }

        if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
        {
            _indexWeapons -= 1;
            _isSelectWeapons = false;
        }

        
// Меняем оружие колесиком        
        if (_isSelectWeapons) return;

        var mo = Main.Instance.GetManagerObject();
        var wc = Main.Instance.GetWeaponsController();

        Debug.Log("Try select " + _indexWeapons);
        if (_indexWeapons < 0)
        {
            _indexWeapons = mo.GetWeaponsList.Length - 1;
        }

        if (_indexWeapons >= mo.GetWeaponsList.Length)
        {
            _indexWeapons = 0;
        }
/*		for (var index = 0; index < mo.GetWeaponsList.Length; index++)
		{
			var weapon = mo.GetWeaponsList[index];
			if (index == _indexWeapons)
			{
				wc.On(mo.GetWeaponsList[_indexWeapons], mo.GetAmmunitionList[_indexWeapons]);
			}
			else
			{
				(mo.GetWeaponsList[_indexWeapons], mo.GetAmmunitionList[_indexWeapons]);
			}
		}*/

        var weapon = mo.GetWeaponsList[_indexWeapons];
        Debug.Log("Try select2 " + weapon);
        if (weapon)
        {
            Debug.Log("Try select3 " + weapon);
            wc.Off();
            // Передаем в контроллер стрельбы чем и из чего стрелять
            wc.On(weapon, mo.GetAmmunitionList[_indexWeapons]);
        }

        _isSelectWeapons = true;
    }
}