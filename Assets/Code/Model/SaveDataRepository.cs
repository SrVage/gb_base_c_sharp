﻿using System.IO;
using UnityEngine;

namespace Code
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        public SaveDataRepository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(SceneObjects[] player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            SavedData[] savePlayer = new SavedData[player.Length];

            for (int i = 0; i < player.Length; i++)
            {
                savePlayer[i] = new SavedData
                            {
                                PositionOfObject = player[i].transform.position,
                                NameOfObject = player[i].name,
                                IsEnabled = player[i].isActiveAndEnabled
                            };
            }
            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }

        public void Load(SceneObjects[] player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file)) return;
            var newPlayer = _data.Load(file);
            for (int i = 0; i < newPlayer.Length; i++)
            {
                player[i].transform.position = newPlayer[i].PositionOfObject;
                player[i].name = newPlayer[i].NameOfObject;
                player[i].gameObject.SetActive(newPlayer[i].IsEnabled);
            }
            
        }
    }
}