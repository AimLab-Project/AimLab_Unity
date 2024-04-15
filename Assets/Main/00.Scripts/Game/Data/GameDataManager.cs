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
        // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�.
        string jsonData = JsonUtility.ToJson(data);
        // �����͸� ������ ��� ����
        string path = Path.Combine(Application.dataPath, "playerData.json");

        Debug.Log(gameData);
        // ���� ���� �� ����
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
