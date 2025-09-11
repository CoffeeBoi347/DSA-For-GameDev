using UnityEngine;

public class ShapesManager : MonoBehaviour
{
    public Sprite[] shapeSprites;
    private ShapeSprite[] shapes;

    private void Start()
    {
        GenerateShapeFromTexture();
    }

    void GenerateShapeFromTexture()
    {
        shapes = new ShapeSprite[shapeSprites.Length];

        for(int i = 0; i < shapes.Length; i++)
        {
            Texture2D tex = ReturnTextureFromShape(shapeSprites[i]);
            shapes[i] = GetShapeFromTexture(tex);
        }
    }

    public Texture2D ReturnTextureFromShape(Sprite sprite)
    {
        Texture2D tex = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
        tex.filterMode = FilterMode.Point;

        Color[] colors = sprite.texture.GetPixels( // don't forget to enable read/write in the advanced settings of sprite
            (int)sprite.rect.x,
            (int)sprite.rect.y,
            (int)sprite.rect.width,
            (int)sprite.rect.height);

        tex.SetPixels(colors);
        tex.Apply();

        return tex;
    }

    public ShapeSprite GetShapeFromTexture(Texture2D tex)
    {
        ShapeSprite shape = new ShapeSprite(tex.width, tex.height);
        for (int y = 0; y < tex.height; y++)
        {
            for(int x = 0; x < tex.width; x++)
            {
                Color getPixel = tex.GetPixel(x, y);
                if (getPixel.a < 0.1f)
                {
                    shape.cells[x, y] = new Pixel { textureType = TextureType.Null, color = Color.clear };
                }
                else
                {
                    shape.cells[x, y] = new Pixel { textureType = TextureType.Sand, color = Color.white }; // this line
                }
            }
        }

        return shape;
    }
}