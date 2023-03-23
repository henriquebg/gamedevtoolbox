using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolableFactory
{
    public static IPoolable CreateInstance(Component component)
    {
        if (component is AudioSource)
        {
            return new AudioSourcePoolable((AudioSource) component);
        }

        return null;
    }
}
