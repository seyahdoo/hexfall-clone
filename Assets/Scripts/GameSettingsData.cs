using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettingsData", menuName = "ScriptableObjects/GameSettingsData", order = 1)]
public class GameSettingsData : ScriptableObject
{

    public Color[] colors = new Color[] { Color.red, Color.blue, Color.green, Color.magenta, Color.yellow };
    public int gridXSize = 8;
    public int gridYSize = 9;

}
