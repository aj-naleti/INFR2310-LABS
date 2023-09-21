using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManger : MonoBehaviour
{
    [HideInInspector]
    [SerializeField] public List<Waypoints> path;
    public GameObject prefab;
    int CurrentPointIndex = 0;
    public List<GameObject> prefabPoints;

    public List<Waypoints> Getpath()
    {
        if (path == null)
        {
            path = new List<Waypoints> ();
        
        }
        return path;
    }

    public void CreatAddPoint()
    {
        Waypoints go = new Waypoints ();
        path.Add (go);
    }

    public Waypoints GetNextTarget()
    {
        int nextPointIndex = (CurrentPointIndex + 1) % (path.Count);
        CurrentPointIndex = nextPointIndex;
        return path[nextPointIndex];
    }

    private void Start()
    {
        prefabPoints = new List<GameObject> ();
        foreach (Waypoints p in path)
        {
            GameObject go = Instantiate(prefab);
            go.transform.position = p.pos;
            prefabPoints.Add (go);
        }
    }

    private void Update()
    {
        for (int i = 0; i < path.Count; i++)
        {
            Waypoints p = path[i];  
            GameObject g = prefabPoints[i];
            g.transform.position = p.pos;
        }
    }
}
