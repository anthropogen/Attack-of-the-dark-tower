using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public abstract class Pool<T> : MonoBehaviour where T:MonoBehaviour
{
    [SerializeField] private T[] templates;
    [SerializeField] private int countObject;
    [SerializeField] private Transform container;
    protected List<T>[] objects;

    private void Start()
    {
        CreatePools();
    }
    private void CreatePools()
    {
        objects = new List<T>[templates.Length];
        for (int i = 0; i < templates.Length; i++)
        {
            objects[i] = new List<T>();
            for (int j = 0; j < countObject; j++)
            {
                CreateObject(i);
            }
        }
    }
    private bool TryGetObject(int index , out T result)
    {
        result = objects[index].FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }
    private T CreateObject(int index)
    {
        var obj = Instantiate(templates[index], container);
        objects[index].Add(obj);
        obj.gameObject.SetActive(false);
        return obj;
    }
    public T GetFreeObject(int index)
    {
        if (index>0||index<objects.Length)
        {
            T result;
            if (TryGetObject(index, out result))
            {
                return result;
            }
            return CreateObject(index);
        }
        return null;
    }
    public T GetRandomObject()
    {
        int index = Random.Range(0,objects.Length);
        return  GetFreeObject(index);
    }
}
