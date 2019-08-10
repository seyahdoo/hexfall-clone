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
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                GameObject go = Instantiate(tilePrefab);
                go.transform.position = CalculateTilePosition(sizeX, sizeY, x, y);
                go.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                go.transform.SetParent(this.transform);
            }
        }
    }

    public Vector2 CalculateTilePosition(int sizeX, int sizeY, int x, int y)
    {
        float centerX = (sizeX - 1) * 0.75f / 2;
        float centerY = (((sizeY - 1) * kok3 / 2) + kok3 / 4) / 2;
        float cx = (x * 0.75f) - centerX;
        float cy = (y * (kok3 / 2)) - centerY + ((x % 2) * (kok3 / 4));
        return new Vector2(cx, cy);
    }


    public void SelectTiles(int posX, int posY)
    {



    }






}
