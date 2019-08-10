using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{

    public GameSettingsData gameSettingsData;

    public TileDirector tileDirector;

    public Camera cam;

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

    public Vector2 lastKnownMousePosition;
    public float clickPositionDelta = 20f;

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
                lastKnownMousePosition = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                //Rotate
                //While rotating, seperate the tiles just a little bit, responsively
            }

            if (Input.GetMouseButtonUp(0))
            {
                //if clicked recently, (position not changed much)
                if(Vector2.Distance(Input.mousePosition, lastKnownMousePosition) < clickPositionDelta)
                {
                    //->Select Tiles, if there is previous tiles selected, return them to original state first
                    tileDirector.SelectTiles(cam.ScreenToWorldPoint(Input.mousePosition));
                }
                else
                {
                    //->Try Exploding
                    //->if explosion fails 
                    //->->->Return original state.
                }



            }

        }

        if (gameState == GameState.Exploding)
        {
            //Play animation
            //Zoom camera out just a little bit,
            //play circle growing and fading our particle
            //play particles spazzing out and fading out particle
        }

        if (gameState == GameState.Falling)
        {
            //Play animation
            //Let existing pieces fall
            //Plant new random pieces as existing pieces fall down
        }
        


    }


}
