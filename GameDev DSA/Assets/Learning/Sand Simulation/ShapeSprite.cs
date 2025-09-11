using UnityEngine;
[System.Serializable]
public class ShapeSprite
{
    public Pixel[,] cells;
    public int width;
    public int height;

    public ShapeSprite(int width, int height)
    {
        this.width = width;
        this.height = height;

        cells = new Pixel[width, height];
    }
}