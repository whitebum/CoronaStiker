using CoronaStriker.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

namespace CoronaStriker.Level
{
    //public sealed class RecordManager : Singleton<RecordManager>
    //{
    //    private static string recordDataPath = @$"{Application.streamingAssetsPath}/Records.json";
    //
    //    private List<RecordData> recordDatas = new List<RecordData>();
    //
    //    private void Awake()
    //    {
    //        
    //    }
    //
    //    public void TestCreateNewJson()
    //    {
    //        var temp = new RecordData[5];
    //
    //        for (var count = 0; count < temp.Length; ++count)
    //        {
    //            temp[count] = new RecordData { playerInitial = "AAA", playerScore = 000000, clearTime = 000.0f, killCount = 0 };
    //        }
    //
    //        JsonUtility.ToJson(temp, true);
    //    }
    //}

    public class RecordManager : MonoBehaviour
    {
        private static string recordDataPath = @$"{Application.streamingAssetsPath}/Records.json";

        private void Awake()
        {
            TestCreateNewJson();
        }

        public void TestCreateNewJson()
        {
            var temp = new List<RecordData>();
            for (var count = 0; count < 5; ++count)
            {
                temp.Add(new RecordData { playerInitial = "AAA", 
                                               playerScore   = 000000, 
                                               clearTime     = 000.0f, 
                                               killCount     = 0        });
            }

            var tempJson = JsonUtility.ToJson(temp[0]);

            Debug.Log(tempJson);

            File.WriteAllText(recordDataPath, tempJson);
        }
    }
}