﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateGame : GameState
{
    public override void Construct()
    {
        base.Construct();
        GameManager.Instance.motor.ResumePlayer();
        GameManager.Instance.ChangeCamera(GameCamera.Game);
    }

    public override void UpdateState()
    {
        GameManager.Instance.worldGeneration.ScanPosition();
        GameManager.Instance.sceneChunkGeneration.ScanPosition();
    }
}
