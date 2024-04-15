using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class GameDataManager : MonoBehaviour
{
    [SerializeField]
    GameData gameData;

    [SerializeField]
    List<HitData> hitDatas;

    [SerializeField]
    public int Score
    {
        get { return GameManager.Instance.GetScore(); }
    }

    private void Start()
    {
        hitDatas = new List<HitData>();
    }
    
    
    void SavePlayerDataToJson<T>(T data)
    {
        // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다.
        string jsonData = JsonUtility.ToJson(data);
        // 데이터를 저장할 경로 지정
        string path = Path.Combine(Application.dataPath, "playerData.json");

        Debug.Log(gameData);
        // 파일 생성 및 저장
        File.WriteAllText(path, jsonData);
    }


    public void GetHitdataToJson()
    {
        int last = hitDatas.Count-1;
        if(last < 0)
        {
            Debug.LogError("Hit Data Result null!");
        }
        else
        {
            SavePlayerDataToJson<HitData>(hitDatas[last]);
        }
    }

    public HitData GetCurrentData()
    {
        return hitDatas[hitDatas.Count - 1];
    }

    public void GetResultdataToJson()
    {
        if (gameData == null)
        {
            Debug.LogError("Result data Result null!");
        }
        else
        {
            SavePlayerDataToJson<GameData>(gameData);
        }
    }

    public void SetHitData(HitData hitData)
    {
        if (hitDatas == null)
            hitDatas = new List<HitData>();
        hitDatas.Add(hitData);
    }
}
