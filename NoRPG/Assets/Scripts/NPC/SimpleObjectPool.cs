using UnityEngine;
using System.Collections.Generic;

//simple object pooling class
public class SimpleObjectPool : MonoBehaviour
{
    //the prefab that this object pool returns instances of
    public GameObject prefab;

    //collection of currently inactive intances of prefab
    private Stack<GameObject> inactiveInstances = new Stack<GameObject>();

    //Returns an instance of the prefab
    public GameObject GetObject()
    {
        GameObject spawnedGameObject;

        //if there is an inactive instance of the prefab ready to return, return that
        //otherwise, create new instance
        if (inactiveInstances.Count > 0)
        {
            spawnedGameObject = inactiveInstances.Pop();
        }
        else
        {
            spawnedGameObject = GameObject.Instantiate(prefab);

            //add the PooledObject componenten to the prefab so we know it came from this pool
            PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

        //put the instance in the root of the scene and enable it
        //spawnedGameObject.transform.SetParent(GameObject.Find("Content").transform);
        spawnedGameObject.SetActive(true);

        //return reference of instance
        return spawnedGameObject;
    }

    //Return an instance of the prefab to the pool
    public void ReturnObject(GameObject toReturn)
    {
        PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

        //if the instance came from this pool, return it to the pool
        //otherwise just destroy it
        if (pooledObject != null && pooledObject.pool == this)
        {
            //make the instace a child and disable it
            toReturn.transform.SetParent(transform);
            toReturn.SetActive(false);

            //add the instance to the collection of inactive instances
            inactiveInstances.Push(toReturn);
        }
        else
        {
            Debug.LogWarning(toReturn.name + " was returned to a pool it wasnt spawned from! Destroying.");
            Destroy(toReturn);
        }
    }
}

//a component that simply identifies the pool that a GameObject came from
public class PooledObject : MonoBehaviour
{
    public SimpleObjectPool pool;
}