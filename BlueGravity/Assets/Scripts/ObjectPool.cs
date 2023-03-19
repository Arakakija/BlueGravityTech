using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : Component
{
     private Queue<T> _poolQueue = new Queue<T>();
     private T prefab;

     public ObjectPool(T prefab, int initSize)
     {
          this.prefab = prefab;
          AddToPool(initSize);
     }

     public T GetObjectFromPool()
     {
          if (_poolQueue.Count == 0)
          {
               AddToPool(1);
          }

          T obj = _poolQueue.Dequeue();
          obj.gameObject.SetActive(true);
          return obj;
     }

     public void ReturnObjectToPool(T obj)
     {
          obj.gameObject.SetActive(false);
          _poolQueue.Enqueue(obj);
     }

     private void AddToPool(int size)
     {
          for (int i = 0; i < size; i++)
          {
               T obj = Object.Instantiate(prefab);
               obj.gameObject.SetActive(false);
               _poolQueue.Enqueue(obj);
          }
     }

}
