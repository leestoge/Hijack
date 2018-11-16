using UnityEngine;
using UnityEngine.AI;

public class NavMeshLoader : MonoBehaviour
{

    public NavMeshSurface surface;

    // Use this for initialization
    void Start()
    {
        // UPDATE NAVMESH
        surface.BuildNavMesh();
        Debug.Log("NAVMESH UPDATED.");
    }
}
