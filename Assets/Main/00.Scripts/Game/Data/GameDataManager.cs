using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class GameDataManager : MonoBehaviour
{

    [SerializeField]
    //public List<GameData> gameDatas;
    public GameData gameData;

    private void Start()
    {
        gameData.hitDatas = new List<HitData>();
    }


    [ContextMenu("To Json Data")] // ������Ʈ �޴��� �Ʒ� �Լ��� ȣ���ϴ� To Json Data ��� ��ɾ ������
    void SavePlayerDataToJson()
    {
        // ToJson�� ����ϸ� JSON���·� �����õ� ���ڿ��� �����ȴ�  
        string jsonData = JsonUtility.ToJson(gameData);
        // �����͸� ������ ��� ����
        string path = Path.Combine(Application.dataPath, "playerData.json");

        Debug.Log(gameData);
        // ���� ���� �� ����
        File.WriteAllText(path, jsonData);

    }

    
}
