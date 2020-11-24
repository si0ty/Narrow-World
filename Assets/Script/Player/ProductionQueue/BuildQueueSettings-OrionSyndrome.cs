using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BuildQueueSettings : MonoBehaviour { 

public enum BuildQueueItemState
{
    Unknown,
    Appear,
    Disappear,
    Update
}

public class BuildQueue<T> : IEnumerable<T> where T : class
{


    public List<T> _list;
    private Dictionary<T, BuildQueueItemState> _tracker;

    public int Count => _list.Count;
    public int MaxItems { get; private set; }

    public delegate void BuildQueueEventHandler(BuildQueue<T> queue);
    public event BuildQueueEventHandler HasChanged;

    public Transform myIconPosition;

  


    public BuildQueue(int maxItems) {
        MaxItems = maxItems;
        _list = new List<T>(maxItems);
        _tracker = new Dictionary<T, BuildQueueItemState>();


        var queue = new BuildQueue<GameObject>(5);


      

         }

    public T this[int index] => (index < Count) ? _list[index] : null; // I've modified this a bit
    public int IndexOf(T obj) => _list.IndexOf(obj);

    public bool KnowsAbout(T obj) => _tracker.ContainsKey(obj);
    public bool Contains(T obj) => KnowsAbout(obj) && _tracker[obj] != BuildQueueItemState.Disappear;


    public BuildQueueItemState StateOf(T obj) {
        if (KnowsAbout(obj)) return _tracker[obj];
        return BuildQueueItemState.Unknown;
    }   // returns false if full, true if not

    public bool Enqueue(T obj) {
        if (Count == MaxItems || Contains(obj)) return false; // safety check
        _tracker[obj] = BuildQueueItemState.Appear; // we can tell it should appear
        _list.Add(obj);
        HasChanged?.Invoke(this);
        return true;
    }

    // throws error if empty
    public T Dequeue() {
        T obj = _list[Count - 1];
        _tracker[obj] = BuildQueueItemState.Disappear;
        _list.RemoveAt(Count - 1);
        HasChanged?.Invoke(this);
        return obj;
    }


    public bool Insert(int index, T obj) {
        if (Count == MaxItems || Contains(obj)) return false; // same as in Enqueue
        _tracker[obj] = BuildQueueItemState.Appear;
        if (index < Count - 1) {
            for (int i = index + 1; i < Count; i++) {
                _tracker[_list[i]] = BuildQueueItemState.Update; // everything to the right of it should move
            }
        }
        _list.Insert(index, obj);
        HasChanged?.Invoke(this);
        return true;
    }

    // throws error if empty
    public T RemoveAt(int index) {
        T obj = _list[index];
        _tracker[obj] = BuildQueueItemState.Disappear; // this one should disappear
        if (index < Count - 1) { // if index was anything less than the last element
            for (int i = index + 1; i < Count; i++) {
                _tracker[_list[i]] = BuildQueueItemState.Update; // everything to the right of it should move
            }
        }
        _list.RemoveAt(index);
        HasChanged?.Invoke(this);
        return obj;
    }


    public void Clear() {
        for (int i = 0; i < Count; i++) {
            _tracker[_list[i]] = BuildQueueItemState.Disappear; // everything has to go
        }
        _list.Clear();
        HasChanged?.Invoke(this);
    }


    public IEnumerator<T> GetEnumerator() {
        for (int i = 0; i < Count; i++) yield return this[i];
    }


    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}
}



/*static public class VisualBuildQueueUtils
{

    static public Vector2 GetIconPositionOf(int index, float topPosition, float iconWidth, float iconSpacing)
      => new Vector2((iconWidth + iconSpacing) * index, topPosition);

    static public (Vector2 position, T obj)[] GetIconArray<T>(this BuildQueue<T> queue, float topPosition, float iconWidth, float iconSpacing) where T : class {
        var array = new (Vector2, T)[queue.Count];
        int i = 0;
        foreach (var item in queue) {
            array[i] = (GetIconPositionOf(i, topPosition, iconWidth, iconSpacing), item);
            i++;
        }
        return array;
    }
} */
