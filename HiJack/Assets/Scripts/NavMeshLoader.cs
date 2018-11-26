using UnityEngine;
using UnityEngine.AI;

public class NavMeshLoader : MonoBehaviour
{
    public NavMeshSurface surface;

    void Start()
    {
        // PLAY MUSIC
        FindObjectOfType<AudioManager>().Play("inGameMusic");

        // UPDATE NAVMESH
        surface.BuildNavMesh();
        Debug.Log("NAVMESH UPDATED.");
    }
}
