using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Transform[] gameObjects;
    private Rigidbody[] rigidbodies;
    private Vector3[] startPosition;
    private int countObj;
    static private bool IsReturn = false;
    private bool IsRest = false;


    public static bool GetRest
    {
        get { return IsReturn; }
    }

    private void Awake()
    {
        countObj = this.gameObject.transform.childCount;

        gameObjects = new Transform[countObj];
        startPosition = new Vector3[countObj];
        rigidbodies = new Rigidbody[countObj];

        int countChild = 0;
        foreach (Transform child in this.transform)
        {
            gameObjects[countChild] = child;

            child.gameObject.AddComponent<DataObject>();

            
            startPosition[countChild] = child.transform.position;

            rigidbodies[countChild] = child.gameObject.GetComponent<Rigidbody>();
            
                
           countChild++;
        }



    }
    void Update()
    {
        if (!IsRest)
        {
            for (int i = 0; i < countObj; i++)
            {
                if (IsStartPosition())
                    IsRestObjects();
            }

        }
        else
        {
           if(!IsStartPosition())
            {
                IsReturn = false;
                IsRest = false;
                return;
            }
            IsReturn = true;
        }
        

    }

    bool IsStartPosition()
    {
        for (int i = 0; i < countObj; i++)
        {
            if (Vector3.Distance(gameObjects[i].position, startPosition[i]) > 0.01f)
                return true;
        }
        return false;
    }

    void IsRestObjects()
    {
        IsRest = true;
        for (int i = 0; i < countObj; i++)
        {
            if (rigidbodies[i].velocity != new Vector3(0f, 0f, 0f))
            {
                IsRest = false;
            }


        }
    
          
    }
}
