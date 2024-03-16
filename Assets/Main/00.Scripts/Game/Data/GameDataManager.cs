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


    [ContextMenu("To Json Data")] // 컴포넌트 메뉴에 아래 함수를 호출하는 To Json Data 라는 명령어가 생성됨
    void SavePlayerDataToJson()
    {
        // ToJson을 사용하면 JSON형태로 포멧팅된 문자열이 생성된다  
        string jsonData = JsonUtility.ToJson(gameData);
        // 데이터를 저장할 경로 지정
        string path = Path.Combine(Application.dataPath, "playerData.json");

        Debug.Log(gameData);
        // 파일 생성 및 저장
        File.WriteAllText(path, jsonData);

    }

    
}
