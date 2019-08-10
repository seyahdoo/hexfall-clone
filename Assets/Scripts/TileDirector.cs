using seyahdoo.pooling.v3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDirector : MonoBehaviour
{

    public GameObject tilePrefab;
    public GameObject[,] tiles;


    private readonly float kok3 = 1.7320508075688772f;

    public void SetupTiles(int sizeX, int sizeY)
    {
        Pool.CreatePool<Tile>(null, sizeX * sizeY, sizeX * sizeY);
        
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Tile tile = Pool.Get<Tile>();
                tile.transform.position = CalculateTilePosition(sizeX, sizeY, x, y);
                tile.spriteRenderer.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                tile.transform.SetParent(this.transform);
            }
        }
    }

    public Vector2 CalculateTilePosition(int sizeX, int sizeY, int x, int y)
    {
        float centerX = (sizeX - 1) * 0.75f / 2;
        float centerY = (((sizeY - 1) * kok3 / 2) + kok3 / 4) / 2;
        float positionX = (x * 0.75f) - centerX;
        float positionY = (y * (kok3 / 2)) - centerY + ((x % 2) * (kok3 / 4));
        return new Vector2(positionX, positionY);
    }


    public void SelectTiles(int posX, int posY)
    {



    }






}
