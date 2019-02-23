using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
using Debug = UnityEngine.Debug;

public class TeammateModel : MonoBehaviour
{

    private NavMeshAgent agent;
    private ThirdPersonCharacter character;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<ThirdPersonCharacter>();

        agent.updateRotation = false;
        agent.updatePosition = true;
    }

    private void Update()
    {
        if (_points.Count > 0)
        {
            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false,false);
            else
            {
            
                _points.RemoveAt(0);
                if (_points.Count > 0)
                {
                    agent?.SetDestination(_points[0]);
                }
                else
                {
                    character.Move(Vector3.zero, false, false);
                }
            }

        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }


    }

    List<Vector3> _points = new List<Vector3>();
    public void SetDestination(Vector3 pos)
    {
        _points.Add(pos);
        if (_points.Count == 1)
        {
            Debug.Log("Set dest");
            agent?.SetDestination(pos);
        }
    }


}
