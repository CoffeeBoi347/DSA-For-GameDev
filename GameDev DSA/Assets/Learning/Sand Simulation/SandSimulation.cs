using UnityEngine;

public class SandSimulation : MonoBehaviour
{
    [Header("Texture Settings")]

    public int width;
    public int height;
    private byte r;
    private byte g;
    private byte b;
    [Header("Components")]

    [SerializeField] private Texture2D _texture;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _backgroundColor;

    [Header("Data")]

    private Pixel[,] _grid;
    private void Start()
    {
        _texture = new Texture2D(width, height, TextureFormat.RGBA32, false);
        _texture.filterMode = FilterMode.Point;
        if (this.gameObject.GetComponent<SpriteRenderer>() == null)
        {
            _spriteRenderer = this.gameObject.AddComponent<SpriteRenderer>();
        }

        _grid = new Pixel[width, height];

        for(int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                _grid[x, y].color = _backgroundColor;
            }
        }

        _grid[width / 2, height / 2] = new Pixel { textureType = TextureType.Sand, color = Color.yellow };
        UpdatePixel();

        _spriteRenderer.sprite = Sprite.Create(_texture, new Rect(0, 0, width, height), Vector2.one / 2, 100);
    }

    private void Update()
    {
        InputControls();
        UpdatePixel();
        SimulateSand();
    }
    void UpdatePixel()
    {
        r = (byte)Random.Range(0f, 255f);
        g = (byte)Random.Range(0f, 255f);
        b = (byte)Random.Range(0f, 255f);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _texture.SetPixel(x, y, _grid[x, y].color);
            }
        }

        _texture.Apply();
    }

    void InputControls()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 localPosSprite = transform.InverseTransformPoint(mousePos);

            float x = localPosSprite.x + 0.5f;
            float y = localPosSprite.y + 0.5f;

            int ux = Mathf.RoundToInt(x * width);
            int uy = Mathf.RoundToInt(y * height);

            if(ux >= 0 && ux < width && uy >= 0 && uy < height)
            {
                _grid[ux, uy] = new Pixel { textureType = TextureType.Sand, color = Color.yellow };
            }
        }
    }

    void SimulateSand()
    {
        for(int y = 1; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                if (_grid[x, y].textureType != TextureType.Sand) continue;

                // Down
                if (_grid[x, y - 1].textureType == TextureType.Null)
                {
                    SwapSand(x, y, x, y - 1);
                }
                // Left
                else if (x > 0 && _grid[x - 1, y].textureType == TextureType.Null)
                {
                    SwapSand(x, y, x - 1, y);
                }
                // Right
                else if (x < width - 1 && _grid[x + 1, y].textureType == TextureType.Null)
                {
                    SwapSand(x, y, x + 1, y);
                }
                // Down Left
                else if (x > 0 && _grid[x - 1, y - 1].textureType == TextureType.Null)
                {
                    SwapSand(x, y, x - 1, y - 1);
                }
                // Down Right
                else if (x < width - 1 && _grid[x + 1, y - 1].textureType == TextureType.Null)
                {
                    SwapSand(x, y, x + 1, y - 1);
                }
            }
        }
    }

    void SwapSand(int x, int y, int x2, int y2)
    {
        _grid[x, y] = new Pixel { textureType = TextureType.Null, color = _backgroundColor };
        _grid[x2, y2] = new Pixel { textureType = TextureType.Sand, color = new Color32(r, g, b, 255) };
    }
}