using System.Collections.Generic;
using UnityEngine;

public class DFSVisualizer : MonoBehaviour
{
    [Header("Map Sizes")]
    public int width;
    public int height;

    public Vector2Int start;
    public Vector2Int end;

    [Header("Regions")]
    public List<Vector2Int> blockedRegions = new List<Vector2Int>();
    private BuildGraph buildGraph;

    public List<Vector2Int> path;
    public HashSet<Vector2Int> visited;

    private void Start()
    {
        HashSet<Vector2Int> blockRegions = new HashSet<Vector2Int>(blockedRegions);
        buildGraph = new BuildGraph(width, height, blockRegions);
        visited = new HashSet<Vector2Int>();
        path = new List<Vector2Int>();

        bool foundPath = SimpleDFS.FindNextMove(buildGraph, start, end, visited, path);
        Debug.Log(foundPath ? "Path Found" : "Path Not Found");
    }

    private void OnDrawGizmos()
    {
        if (buildGraph == null) return;

        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                Vector2Int pos = new Vector2Int(x, y);
                Vector3 worldPos = new Vector3(x, y);

                if (blockedRegions.Contains(pos))
                {
                    Gizmos.color = Color.black;
                }

                else if(pos == start)
                {
                    Gizmos.color = Color.green;
                }

                else if (pos == end)
                {
                    Gizmos.color = Color.red;
                }
                else if (visited.Contains(pos))
                {
                    Gizmos.color = new Color32(10, 245, 0, 255);
                }

                else
                {
                    Gizmos.color = Color.grey;
                }

                Gizmos.DrawCube(worldPos, Vector3.one * 0.9f);
            }
        }
    }
}