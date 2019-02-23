using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IDataProvider

{
	void Save(PlayerData playerData);
	PlayerData Load();
	void SetOptions(string path);

}
