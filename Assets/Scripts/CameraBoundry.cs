using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraBoundry : MonoBehaviour
{
    public GameSettingsData gameSettingsData;
    public Camera cam;

    private void Awake()
    {
        float w = ((gameSettingsData.gridXSize - 1) * 0.75f) + 1;
        float orthographicSize = w * Screen.height / Screen.width * 0.5f;

        cam.orthographicSize = orthographicSize;
    }
}
