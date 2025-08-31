using System.Collections.Generic;
using UnityEngine;

public class Cell
{
    public Vector2Int cellPos;
    public bool isWalkable;

    public Cell(int x, int y, bool _isWalkable)
    {
        cellPos = new Vector2Int(x, y);
        isWalkable = _isWalkable;
    }
}

public class BuildGraph
{
    public int height, width;
    public Cell[,] cells;

    public BuildGraph(int width, int height, HashSet<Vector2Int> posHolder)
    {
        this.height = height;
        this.width = width;
        cells = new Cell[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y ++)
            {
                bool isBlocked = posHolder.Contains(new Vector2Int(x, y));
                cells[x, y] = new Cell(x, y, !isBlocked);
            }
        }
    }

    public bool InBounds(Vector2Int cellPos) => cellPos.x >= 0 && cellPos.x < width && cellPos.y > 0 && cellPos.y < height;
    public bool IsWalkable(Vector2Int cellPos) => InBounds(cellPos) && cells[cellPos.x, cellPos.y].isWalkable;
    public Cell GetCell(Vector2Int cellPos) => InBounds(cellPos) ? cells[cellPos.x, cellPos.y] : null;

    private static readonly Vector2Int[] dirs =
    {
        new Vector2Int(1, 0),
        new Vector2Int(0, -1),
        new Vector2Int(0, 1),
        new Vector2Int(-1, 0),
    };

    public List<Vector2Int> GetNeighbors(Vector2Int cellPos)
    {

        List<Vector2Int> result = new();
        foreach(Vector2Int dir in dirs)
        {
            var finalDir = cellPos + dir;
            if (IsWalkable(finalDir))
            {
                result.Add(finalDir);
            }
        }

        return result;
    }
}