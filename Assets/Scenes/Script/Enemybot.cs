using System;
using System.Collections;
using System.Collections.Generic;
using My.Interface;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Experimental.PlayerLoop;
using Random = UnityEngine.Random;

public class Enemybot : MonoBehaviour, ISetDamage
{
    public Transform EyesTransform;

    public float SearchDistance = 40f;
    public float RangeDistance = 20f;
    public float MeleeDistance = 5f;

    private float maxRandomRadius;
    private bool useRandomWP;

    private Waypoint[] waypoints;
    private int currentWP;
    private float currentWPTimeout;

    private NavMeshAgent agent;
    private Vector3 randomPos;
    private Transform targetTransform;
    public Weapon weaponmelee;
    public Weapon weaponrange;
    public Ammunition RangeAmmution;

    public void Initialization(BotSpawnParams spawnParams)

    {
        waypoints = spawnParams.Waypoints;
        useRandomWP = waypoints.Length <= 1;
        maxRandomRadius = Mathf.Max(2, spawnParams.MaxRandomRadius);
        SearchDistance = Math.Max(2, spawnParams.SearchDistance);
        //RangeDistance = Math.Max(2,spawnParams.AttackDistance);
        //MeleeDistance = Math.Max(2,spawnParams.AttackDistance);

        agent = GetComponent<NavMeshAgent>();

        //weapon = GetComponentInChildren<Weapon>(true);


        Main.Instance.EnemyBotsController.AddBot(this);
    }

    public void SetTarget(Transform target)
    {
        targetTransform = target;
    }

    private void Update()
    {
        if (CurrentHealth <= 0) return;
        //Проверка возможности атаки

        var isTargetSeen = false;

        if (targetTransform)

        {
            var dist = Vector3.Distance(transform.position, targetTransform.position);
            if (dist < SearchDistance)
            {
                isTargetSeen = CheckTarget();
                if (isTargetSeen)
                    agent.SetDestination(targetTransform.position);
            }

            //Debug.Log(dist);
            if (dist < MeleeDistance && isTargetSeen)
            {
                weaponmelee.Fire(null);
            }
            else if (dist < RangeDistance && isTargetSeen)
            {
                weaponrange.Fire(RangeAmmution);
            }
        }

        if (isTargetSeen) return;

        if (useRandomWP)
        {
            agent.SetDestination(randomPos);
            if (!agent.hasPath || agent.remainingDistance > maxRandomRadius * 2) randomPos = GenerateWaypoint();
        }
        else
        {
            agent.SetDestination(waypoints[currentWP].transform.position);
            if (!agent.hasPath)
            {
                currentWPTimeout += Time.deltaTime;
                if (currentWPTimeout >= waypoints[currentWP].WaitTime)

                {
                    currentWPTimeout = 0;
                    currentWP++;
                    if (currentWP >= waypoints.Length) currentWP = 0;
                }
            }
        }
    }

    [SerializeField] private float currentHealth = 100f;

    public float CurrentHealth
    {
        get { return currentHealth; }
        set { currentHealth = value; }
    }

    public void ApplyDamage(float damage)
    {
        if (CurrentHealth <= 0) return;
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) Death();
    }

    public Animator anim;
    private void Death()

    {
        anim.SetTrigger("die");
        Destroy(gameObject, 3f);
        //foreach (var c in GetComponentsInChildren<Transform>())

        //{
            
            //c.SetParent(null);
           
            
            
/*
            var col = c.GetComponent<Collider>();

            if (col) col.enabled = true;

            var rb = c.gameObject.AddComponent<Rigidbody>();
            rb.mass = 5;
            rb.AddForce(Vector3.up * Random.Range(10f, 30f), ForceMode.Impulse);
            */
        //}

        Main.Instance.EnemyBotsController.RemoveBot(this);
    }

    private bool CheckTarget()
    {
        RaycastHit hit;
        if (Physics.Linecast(EyesTransform.position, targetTransform.position, out hit) &&
            hit.transform == targetTransform)
        {
            return true;
        }

        if (Physics.Linecast(EyesTransform.position, targetTransform.position + Vector3.up * 0.5f, out hit) &&
            hit.transform == targetTransform)
        {
            return true;
        }

        if (Physics.Linecast(EyesTransform.position, targetTransform.position - Vector3.up * 0.5f, out hit) &&
            hit.transform == targetTransform)
        {
            return true;
        }

        //if (Physics.Linecast(EyesTransform.position + result, out hit, maxRandomRadius * 1.5f, NavMesh.AllAreas))
        //	return hit.position;

        //return transform.position;
        return false;
    }

    private Vector3 GenerateWaypoint()

    {
        var result = maxRandomRadius * Random.insideUnitSphere;


        NavMeshHit hit;
        if (NavMesh.SamplePosition(transform.position + result, out hit, maxRandomRadius * 1.5f, NavMesh.AllAreas))
            return hit.position;
        else return transform.position;
    }

    [Serializable]
    public class BotSpawnParams

    {
        public float AttackDistance;
        public float SearchDistance;
        public Waypoint[] Waypoints;
        public float MaxRandomRadius;
    }
}