using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Wave 
{
    private float _maxDelay;
    private float _minDelay;
    private int _count;
    private List<int> _templateIndexes;
    public List<int> TemplateIndexes=>_templateIndexes;
    public int Count=>_count;

    public float Delay()
    {
        return Random.Range(_minDelay, _maxDelay);
    }
    public int GetTemplate()
    {
        return _templateIndexes[Random.Range(0, _templateIndexes.Count)];
    }
    public Wave (List<int> indexes,int count, float maxDelay,float minDelay)
    {
        _templateIndexes = indexes;
        _count = count;
        _maxDelay = maxDelay;
        _minDelay = minDelay;
    }
}
