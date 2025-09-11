using UnityEngine;
[System.Serializable]
public struct Pixel
{
    public TextureType textureType;
    public Color color;

    public static Pixel Create
    {
        get
        {
            return new Pixel
            {
                textureType = TextureType.Null,
                color = Color.clear
            };
        }
    }
}

public enum TextureType
{
    Null = 0,
    Sand = 1,
    Water = 2
}