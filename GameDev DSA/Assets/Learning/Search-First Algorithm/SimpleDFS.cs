using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimpleDFS
{
    public static bool FindNextMove(BuildGraph g, Vector2Int start, Vector2Int goal, HashSet<Vector2Int> visited, List<Vector2Int> path)
    {
        if (visited.Contains(start) || !g.IsWalkable(start))
            return false;


        visited.Add(start);
        path.Add(start);

        if (start == goal) return true;

        foreach (Vector2Int neighbor in g.GetNeighbors(start))
        {
            if (FindNextMove(g, neighbor, goal, visited, path)) return true;
        }

        path.RemoveAt(path.Count - 1);
        return false;
    }
}
