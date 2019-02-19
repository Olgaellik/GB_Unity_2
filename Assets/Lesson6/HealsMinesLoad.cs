using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealsMinesLoad : MonoBehaviour

{
    public string mine;
    public string heal;

    public int CountMines;
    public int CountHeals;

    public Transform ParentObj;
    public Vector3 MinVec;
    public Vector3 MaxVec;
    
    private void Start()
    {
        InstantiateFromResources(mine, CountMines);
        InstantiateFromResources(heal, CountHeals);

    }

    void InstantiateFromResources(string resPath, int count)
    {
        var resPrefab = (GameObject)Resources.Load(resPath);
        if (resPrefab != null)
        {
            InstantiateObjs(resPrefab, count);
        }
        else
        {
            Debug.LogError(resPath+" prefab in resources not found");
        }
    }


    private void InstantiateObjs(GameObject minePrefab, int count)
    {
        for (int i = 0; i < count; i++)
        {
            var vec = new Vector3(
                Random.Range(MinVec.x, MaxVec.x),
                Random.Range(MinVec.y, MaxVec.y),
                Random.Range(MinVec.z, MaxVec.z)
            );
            var obj = Instantiate(minePrefab, ParentObj);
            obj.transform.localPosition = vec;
        }
    }
}