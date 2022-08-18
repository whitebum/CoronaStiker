using CoronaStriker.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace CoronaStriker.Level
{
    public sealed class RecordManager : Singleton<RecordManager>
    {
        private readonly string playerRecordsPath = $"{Application.streamingAssetsPath}/Data/Records";

        [SerializeField] private List<PlayerRecord> m_playerRecords;

        public List<PlayerRecord> playerRecords { get => m_playerRecords; private set => m_playerRecords = value; }

        private async void Awake()
        {
            playerRecords = new List<PlayerRecord>();

            if (File.Exists(playerRecordsPath))
            {
                var records = await File.ReadAllLinesAsync(playerRecordsPath);

                foreach (var record in records)
                {
                    var recordData = record.Split('\n');

                    playerRecords.Add(new PlayerRecord(recordData[0], recordData[1]));
                }
            }

            else
            {
                var tempRecords = new List<PlayerRecord>
                {
                    new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000)),
                    new PlayerRecord(new string(new char[] { (char)Random.Range(65, 91), (char)Random.Range(65, 91), (char)Random.Range(65, 91)}), Random.Range(10000, 50000))
                };

                playerRecords.AddRange(tempRecords);
            }

            playerRecords.Sort((item, item2) => int.Parse(item2.playerScore).CompareTo(int.Parse(item.playerScore)));
        }

        protected override void OnApplicationQuit()
        {
            base.OnApplicationQuit();

            
        }
    }
}