using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour {

    public int points;   // Points to add.
    public string user;

    public Text anzeige;

    private const string privateCode = "JV5KqpJJSEuJsPnFsYGMnABwEyIYl-10yrekASfAdy5A";
    private const string publicCode = "5adcfacfd6024519e0ea7f39";
    private const string webUrl = "http://dreamlo.com/lb/";

    public HighScore[] highScoreList;

    private void Awake() {
        AddNewHighScore(user, points);
        DownloadHighScores();
    }

    public void AddNewHighScore(string username, int score) {
        StartCoroutine(UpdloadNewHighscore(username, score));
    }

    IEnumerator UpdloadNewHighscore(string userName, int score) {
        WWW www = new WWW(webUrl + privateCode + "/add/" + WWW.EscapeURL(userName) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty (www.error))
            print ("Upload Successful");
        else {
            print ("Error uploading: " + www.error);
        }
    }

    public void DownloadHighScores() {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase() {
        WWW www = new WWW(webUrl + publicCode + "/pipe/");
        yield return www;
        if (string.IsNullOrEmpty (www.error)) {
            FormatHighscores(www.text);
        }
        else {
            print ("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream) {
        string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
        highScoreList = new HighScore[entries.Length];
        for (int i = 0; i <entries.Length; i ++) {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highScoreList[i] = new HighScore(username,score);
            print (highScoreList[i].userName + ": " + highScoreList[i].score);
            //this line will change the ui text
            anzeige.text = (highScoreList [i].userName + ": " + highScoreList [i].score);
        }
    }


    public struct HighScore {
        public string userName;
        public int score;

        public HighScore(string myUserName, int myScore) {
            userName = userName = myUserName;
            score = myScore;
        }
    }
}
