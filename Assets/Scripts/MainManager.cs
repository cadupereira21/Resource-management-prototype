using System;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour {
    
    private const string SAVE_FILE = "/gamesave.json";
    
    public static MainManager Instance;

    public Color teamColor;

    private void Awake() {
        
        if (Instance != null) {
            Destroy(this.gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(this);
        
        LoadColor();
    }

    public void SaveColor() {
        SaveData data = new SaveData(teamColor);

        string jsonData = JsonUtility.ToJson(data);
        
        Debug.Log($"Saving file at directory: {Application.persistentDataPath}");
        File.WriteAllText(Application.persistentDataPath + SAVE_FILE, jsonData);
    }

    public void LoadColor() {
        string path = Application.persistentDataPath + SAVE_FILE;

        if (!File.Exists(path)) return;
        
        string jsonData = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(jsonData);
        teamColor = data.teamColor;
    }

    [Serializable]
    private class SaveData {
        public Color teamColor;
        
        public SaveData(Color color) {
            teamColor = color;
        }
    }
}