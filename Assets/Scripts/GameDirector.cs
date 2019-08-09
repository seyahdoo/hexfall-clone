using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public GameSettingsData gameSettingsData;

    public TileDirector tileDirector;

    public enum GameState
    {
        Loading,
        Starting,
        Exploding,
        Falling,
        Rotating,
        GameOver,
    }
    public GameState gameState;

    public bool selectionExists;
    public int selectedTrioX;
    public int selectedTrioY;


    private void Start()
    {
        tileDirector.SetupTiles(gameSettingsData.gridXSize, gameSettingsData.gridYSize);



    }


    private void Update()
    {

        if (gameState == GameState.Loading)
        {

        }


        if (gameState == GameState.Rotating)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Record mouse position

                
            }

            if (Input.GetMouseButton(0))
            {
                //Rotate
            }

            if (Input.GetMouseButtonUp(0))
            {
                //if clicked recently, (position not changed much)
                    //Select Tiles, if there is previous tiles selected, return them to original state
                //else
                    //Try Explode -> if fails Return original state.

            }

        }

        if (gameState == GameState.Exploding)
        {
            //Play animation
        }

        if (gameState == GameState.Falling)
        {
            //Play animation
        }
        


    }


}
