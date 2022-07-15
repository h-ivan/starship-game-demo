// https://github.com/Rfrixy/Generic-Unity-Object-Pooler

using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectPoolItem
{

	public GameObject objectToPool;
	public int amountToPool;
	public bool shouldExpand;

	public ObjectPoolItem(GameObject obj, int amt, bool exp = true)
	{
		objectToPool = obj;
		amountToPool = Mathf.Max(amt,2);
		shouldExpand = exp;
	}
}

public class ObjectPooler : MonoBehaviour
{
	public static ObjectPooler SharedInstance;
	public List<ObjectPoolItem> itemsToPool;


	public List<List<GameObject>> PooledObjectsList;
	public List<GameObject> pooledObjects;
	private List<int> _positions;

	private void Awake()
	{

		SharedInstance = this;

		PooledObjectsList = new List<List<GameObject>>();
		pooledObjects = new List<GameObject>();
		_positions = new List<int>();


		for (var i = 0; i < itemsToPool.Count; i++)
		{
			ObjectPoolItemToPooledObject(i);
		}

	}


	public GameObject GetPooledObject(int index)
	{

		var curSize = PooledObjectsList[index].Count;
		for (var i = _positions[index] + 1; i < _positions[index] + PooledObjectsList[index].Count; i++)
		{

			if (!PooledObjectsList[index][i % curSize].activeInHierarchy)
			{
				_positions[index] = i % curSize;
				return PooledObjectsList[index][i % curSize];
			}
		}

		if (itemsToPool[index].shouldExpand)
		{

			var obj = Instantiate(itemsToPool[index].objectToPool, transform, true);
			obj.SetActive(false);
			PooledObjectsList[index].Add(obj);
			return obj;

		}
		return null;
	}

	public List<GameObject> GetAllPooledObjects(int index)
	{
		return PooledObjectsList[index];
	}


	public int AddObject(GameObject go, int amt = 3, bool exp = true)
	{
		var item = new ObjectPoolItem(go, amt, exp);
		var currLen = itemsToPool.Count;
		itemsToPool.Add(item);
		ObjectPoolItemToPooledObject(currLen);
		return currLen;
	}


	private void ObjectPoolItemToPooledObject(int index)
	{
		var item = itemsToPool[index];

		pooledObjects = new List<GameObject>();
		for (var i = 0; i < item.amountToPool; i++)
		{
			var obj = Instantiate(item.objectToPool);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
		PooledObjectsList.Add(pooledObjects);
		_positions.Add(0);

	}
}