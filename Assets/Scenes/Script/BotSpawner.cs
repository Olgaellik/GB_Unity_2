using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class BotSpawner : MonoBehaviour
{


	public Enemybot.BotSpawnParams SpawnParams;
	public Enemybot BotPrefab;

	private Enemybot instance;

	private void Update()

	{
		if (instance) return;
		
		instance = Instantiate(BotPrefab, transform.position, transform.rotation);
		instance.Initialization(SpawnParams);
	}

	
}
