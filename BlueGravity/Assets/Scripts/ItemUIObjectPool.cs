using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUIObjectPool : MonoBehaviour
{
    public GameObject prefab;
    public int initialSize = 30;

    private ObjectPool<ItemUI> _objectPool;

    private void Start()
    {
        _objectPool = new ObjectPool<ItemUI>(prefab.GetComponent<ItemUI>(), initialSize);
    }

    public ItemUI SpawnObjectFromPool(Transform parent)
    {
        ItemUI obj = _objectPool.GetObjectFromPool();
        obj.transform.position = parent.position;
        obj.transform.SetParent(parent);
        obj.transform.localScale =Vector3.one;
        obj.transform.rotation = parent.rotation;
        return obj;
    }

    public void ReturnObjectToPool(ItemUI obj)
    {
        obj.transform.SetParent(transform);
        _objectPool.ReturnObjectToPool(obj);
    }
}
