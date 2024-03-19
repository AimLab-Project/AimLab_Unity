using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // 게임 점수
    public int score;

    public GameData(int score)
    {
        this.score = score;
    }
}


