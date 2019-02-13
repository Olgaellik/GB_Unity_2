using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBotsController : BaseController

{
    private List<Enemybot> botList = new List<Enemybot>();
    private Transform targetTransform;
    private bool isInitialized;

    private void Start()

    {
        //yield return new WaitWhile(() => !Main.Instance && !Main.Instance.PlayerModel);
        //targetTransform = Main.Instance.PlayerModel.transform;
        targetTransform = Player.Instance.transform;
        SetTarget(targetTransform);
        foreach (var bot in FindObjectsOfType<Enemybot>()) AddBot(bot);
    }

//    public void Initialize()
//
//    {
//        if (isInitialized) return;
//        isInitialized = true;
//
//        foreach (var bot in FindObjectsOfType<Enemybot>) AddBot(bot);
//    
//    }

    public void AddBot(Enemybot bot)
    {
        if (botList.Contains(bot)) return;
        botList.Add(bot);
        bot.SetTarget(targetTransform);
    }

    public void RemoveBot(Enemybot bot)
    {
        if (botList.Contains(bot)) return;
        if (botList.Contains(bot)) return;
        botList.Remove(bot);
    }

    private void Update()
    {
        if (!targetTransform)

        {
            //targetTransform = Main.Instance.PlayerModel?.transform;
            targetTransform = Player.Instance.transform;
            return;
        }

        // if (!isInitialized) Initialize();
    }

    public void SetTarget(Transform target)

    {
        foreach (var bot in botList) bot.SetTarget(target);
        {
        }
    }
}