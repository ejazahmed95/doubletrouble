using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>: MonoBehaviour where T: MonoBehaviour {
    [SerializeField] private T objectPrefab;

    private List<T> _freeObjectPool;

    private void Awake() {
        _freeObjectPool = new List<T>();
    }

    public T GetNewObject() {
        if (_freeObjectPool.Count > 0) {
            var obj = _freeObjectPool[0];
            _freeObjectPool.RemoveAt(0);
            obj.gameObject.SetActive(true);
            return obj;
        }
        T newObj = Instantiate(objectPrefab, gameObject.transform);
        return newObj;
    }

    public virtual void RemoveObject(T obj) {
        obj.gameObject.SetActive(false);
        _freeObjectPool.Add(obj);
    }
}
