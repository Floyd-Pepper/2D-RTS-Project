using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FogOfWar {

    private static GameObject[,] _FOWsquares;

    public static void Initialize()
    {
        _FOWsquares = new GameObject[100,100];
        Texture2D black_texture = new Texture2D(100, 100);
        for (int y = 0; y < 100; y++)
        {
            for (int x = 0; x < 100; x++)
            {
                black_texture.SetPixel(x, y, Color.black);
            }
        }
        black_texture.Apply();
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++)
            {
                GameObject tile = new GameObject();
                SpriteRenderer spriteRenderer = tile.AddComponent<SpriteRenderer>();
                Sprite black_square = Sprite.Create(black_texture, new Rect(i, j, 1, 1), new Vector2(0, 0), 1f);
                spriteRenderer.sprite = black_square;
                tile.transform.position = new Vector3(i, j, 0);
                _FOWsquares[i,j] = tile;
                spriteRenderer.sortingLayerName = "FogOfWar";
            }
        }   
    }

    public static void DiscoverTiles(int x, int y)
    {
        for(int i = x - 5; i < x + 5; i++)
        {
            for (int j = y - 5; j < y + 5; j++)
            {
                _FOWsquares[i, j].SetActive(false);
            }
        }
        
    }
}
