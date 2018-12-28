using System.Collections.Generic;
using UnityEngine;


public class UnityPool<T> : MonoBehaviour where T : MonoBehaviour
{

    public T _Prefab;

    public bool _DoPrewarm;

    [Range(1 , 1000)]
    public int _PrewarmCount;

    private static UnityPool<T> _Instance;

    private Queue<GameObject> _Pool;



    private void Awake()
    {
        _Instance = this;
        _Pool = new Queue<GameObject>();

        if (_DoPrewarm)
            Add(_PrewarmCount);

        Debug.Log("Pool for type " + typeof(T).Name + " Objects : " + _Pool.Count);
    }

    public static UnityPool<T> GetInstance()
    {
        return _Instance;
    }

    public void Return(GameObject obj)
    {
        obj.SetActive(false);
        _Pool.Enqueue(obj);
    }

    public GameObject Get()
    {
        if (_Pool.Count == 0)
        {
            Add();
        }

        var obj = _Pool.Dequeue();
        obj.SetActive(true);

        return obj;
    }

    private void Add(int Count = 1)
    {
        for (int i = 0; i < Count; i++)
        {
            var tmp = Instantiate(_Prefab.gameObject);
            tmp.SetActive(false);
            _Pool.Enqueue(tmp);
        }
    }
}
