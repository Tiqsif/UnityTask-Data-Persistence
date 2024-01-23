using System.IO;
using UnityEngine;

public class Data : MonoBehaviour
{
    // transfers data between scenes
    public static Data Instance;

    public int score;
    public string playerName;
    public string highScoreName;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        DontDestroyOnLoad(gameObject);
        LoadData();

    }
    [System.Serializable]
    class SavedData
    {
        public string playerName;
        public int score;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.playerName = highScoreName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText("Assets/BestScore.json", json);
    }

    public void LoadData()
    {
        string path = "Assets/BestScore.json";

        if (File.Exists(path))
        {
            Debug.Log("File exists");
            string json = File.ReadAllText(path);

            SavedData data = JsonUtility.FromJson<SavedData>(json);

            highScoreName = data.playerName;
            score = data.score;
        }
    }
}