using CoronaStriker.Core.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Profiling;

namespace CoronaStriker.Level
{
    public sealed class RecordManager : Singleton<RecordManager>
    {
        private readonly string playerRecordsPath = @$"{Application.streamingAssetsPath}/Records.txt";

        [SerializeField] private List<PlayerRecord> m_playerRecords;

        public List<PlayerRecord> playerRecords { get => m_playerRecords; private set => m_playerRecords = value; }

        private async void Awake()
        {
            playerRecords = new List<PlayerRecord>();

            if (!File.Exists(playerRecordsPath))
            {
                var records = await File.ReadAllLinesAsync(playerRecordsPath);

                foreach (var record in records)
                {
                    var recordData = record.Split(' ');

                    playerRecords.Add(new PlayerRecord(recordData[0], recordData[1]));
                }
            }
            else
            {
                var tempRecords = new List<PlayerRecord>
                {
                    //new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    //new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    //new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    //new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    //new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000))
                    new PlayerRecord("AAA", 5000),
                    new PlayerRecord("BBB", 4000),
                    new PlayerRecord("CCC", 3000),
                    new PlayerRecord("DDD", 2000),
                    new PlayerRecord("EEE", 1000),
            };

                playerRecords.AddRange(tempRecords);
            }

            playerRecords.Sort((item, item2) => int.Parse(item2.playerScore).CompareTo(int.Parse(item.playerScore)));
        }

        protected override void OnApplicationQuit()
        {
            base.OnApplicationQuit();

            if (!File.Exists(playerRecordsPath))
            {
                var temp = File.CreateText(playerRecordsPath);

                foreach (var record in playerRecords)
                {
                    temp.WriteLine($"{record}");
                }

                temp.Close();
            }
        }
    }
}