using seyahdoo.pooling.v3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDirector : MonoBehaviour
{

    public GameSettingsData gameSettingsData;

    public TileSlot[,] tileSlots;
    public List<Tile> tiles = new List<Tile>();

    public Tile[] selectedTiles = null;
    public GameObject rotatorPivot = null;

    public bool TileSelectDebugMode = false;
    public GameObject debugCube;

    private readonly float kok3 = 1.7320508075688772f;

    private void Awake()
    {
        tileSlots = new TileSlot[gameSettingsData.gridXSize, gameSettingsData.gridYSize];
        for (int x = 0; x < gameSettingsData.gridXSize; x++)
        {
            for (int y = 0; y < gameSettingsData.gridYSize; y++)
            {
                GameObject go = new GameObject("TileSlot");
                go.transform.SetParent(this.transform);
                TileSlot ts = go.AddComponent<TileSlot>();
                tileSlots[x, y] = ts;
            }
        }

        rotatorPivot = new GameObject("RotatorPivot");
        rotatorPivot.transform.SetParent(this.transform);
        
    }

    public void SetupTiles(int sizeX, int sizeY)
    {
        Pool.CreatePool<Tile>(null, sizeX * sizeY, sizeX * sizeY);
        
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Tile tile = Pool.Get<Tile>();
                tileSlots[x, y].transform.position = CalculateTilePosition(sizeX, sizeY, x, y);
                tile.spriteRenderer.color = Random.ColorHSV(0, 1, 1, 1, 1, 1);
                tile.transform.SetParent(this.transform);
                tiles.Add(tile);
                tileSlots[x, y].tile = tile;
                tile.tileSlot = tileSlots[x, y];

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


    /// <summary>
    /// Select 3 tiles with giving a center point
    /// </summary>
    /// <param name="centerPosition"></param>
    /// <returns></returns>
    public Tile[] SelectTiles(Vector2 centerPosition)
    {
        Tile[] selectedTiles = new Tile[3] { null, null, null };
        float[] distances = new float[3] { 1000f, 1000f, 1000f };

        foreach (Tile tile in tiles)
        {
            float distance = Vector2.Distance(tile.transform.position, centerPosition);

            //find most distant selected tile
            int max = 0;
            for (int i = 1; i < 3; i++)
            {
                if (distances[max] < distances[i])
                {
                    max = i;
                }
            }

            //if distance < most distant selected tile, swap with most distant selected tile
            if (distance < distances[max])
            {
                selectedTiles[max] = tile;
                distances[max] = distance;
            }

        }


        if(this.selectedTiles.Length > 0)
        {
            foreach (Tile tile in this.selectedTiles)
            {
                tile.tileSlot.following = true;
            }
            Rotate(0);
            for (int i = 0; i < 3; i++)
            {
                this.selectedTiles[i].transform.SetParent(this.transform);
            }
        }

        rotatorPivot.transform.position = 
            (selectedTiles[0].transform.position + 
            selectedTiles[1].transform.position + 
            selectedTiles[2].transform.position) 
            / 3;

        for (int i = 0; i < 3; i++)
        {
            selectedTiles[i].transform.SetParent(rotatorPivot.transform);
        }

        this.selectedTiles = selectedTiles;



        if (TileSelectDebugMode)
        {
            debugCube.transform.position = centerPosition;

            Color c = Random.ColorHSV(0, 1, 1, 1, 1, 1);

            for (int i = 0; i < 3; i++)
            {
                selectedTiles[i].spriteRenderer.color = c;
            }

        }

        return selectedTiles;

    }

    private float lastRotationValue = 0f;

    /// <summary>
    /// Rotate selected tiles
    /// </summary>
    /// <param name="degrees"></param>
    public void Rotate(float degrees)
    {
        lastRotationValue = degrees;
        rotatorPivot.transform.localEulerAngles = Vector3.forward * degrees;
    }

    public float FindSnapRotationValue(float degrees)
    {

        int optimizedX = ((int)(((degrees % 360) + 60) / 120)) % 2;
        return optimizedX * 120f;

    }


    /// <summary>
    /// Seperate the tiles around one point for a little bit
    /// </summary>
    /// <param name="value"></param>
    public void SetSeperation(Vector2 center, float value)
    {


    }

    private void LateUpdate()
    {

        for (int x = 0; x < gameSettingsData.gridXSize; x++)
        {
            for (int y = 0; y < gameSettingsData.gridYSize; y++)
            {
                if(tileSlots[x, y].following && tileSlots[x, y].tile != null)
                {
                    tileSlots[x, y].tile.transform.position = Vector3.Lerp(tileSlots[x, y].tile.transform.position, tileSlots[x, y].transform.position, Time.deltaTime * 4);
                    tileSlots[x, y].tile.transform.rotation = Quaternion.Lerp(tileSlots[x, y].tile.transform.rotation, tileSlots[x, y].transform.rotation, Time.deltaTime * 4);
                }

            }
        }

    }



}
