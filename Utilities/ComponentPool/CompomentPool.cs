using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CompomentPool<T> where T : Component
{
    private GameObject pool;
    private List<IPoolable> pooledComponents;
    private int numberOfComponents = 1;

    public int Size => pooledComponents.Count;

    public CompomentPool()
    {
        pool = new GameObject("ComponentPool_" + typeof(T).ToString());
        pooledComponents = new List<IPoolable>();

        for (int i = 0; i < numberOfComponents; i++)
        {
            T component = pool.AddComponent<T>();
            pooledComponents.Add(PoolableFactory.CreateInstance(component));
        }
    }

    public T GetNextAvailable()
    {
        var component = pooledComponents.Find(component => component.IsAvailable());

        if (component == null)
        {
            return (T) InstantiateNewComponent();
        }

        return (T) component.GetComponent();
    }

    private Component InstantiateNewComponent()
    {
        var newComponent = pool.AddComponent<T>();
        pooledComponents.Add(PoolableFactory.CreateInstance(newComponent));

        return newComponent;
    }

    public void ClearPool()
    {
        pooledComponents.RemoveAll(component => component.IsAvailable());
    }
}
