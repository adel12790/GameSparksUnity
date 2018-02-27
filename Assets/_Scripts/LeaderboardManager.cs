using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardManager : MonoBehaviour {

    public Text statusTxt;
    public RectTransform ListParent;
    public RectTransform ListItem;

    private const string RankUITextName = "PlayerRankText";
    private const string NameUITextName = "PlayerNameText";
    private const string ScoreUITextName = "PlayerScoreText";

    public void getLeaderboardData()
    {
        new GameSparks.Api.Requests.LeaderboardDataRequest().SetLeaderboardShortCode("highscore").SetEntryCount(20).Send((response) => {
            if (!response.HasErrors)
            {
                Debug.Log("Found leaderboard data");

                foreach (GameSparks.Api.Responses.LeaderboardDataResponse._LeaderboardData item in response.Data)
                {
                    RectTransform itemList = Instantiate<RectTransform>(ListItem);
                    Text[] itemTxts = itemList.GetComponentsInChildren<Text>();
                    foreach (var itemTxt in itemTxts)
                    {
                        switch (itemTxt.name)
                        {
                            case RankUITextName:
                                itemTxt.text = item.Rank.ToString();
                                break;
                            case NameUITextName:
                                itemTxt.text = item.UserName.ToString();
                                break;
                            case ScoreUITextName:
                                itemTxt.text = item.JSONData["score"].ToString();
                                break;
                            default:
                                break;
                        }
                    }
                    itemList.gameObject.transform.SetParent(ListParent, false);

                    int rank = (int)item.Rank;
                    string username = item.UserName.ToString();
                    string score = item.JSONData["score"].ToString();

                    string status = "Rank: " + rank + " username: " + username + " score: " + score;

                    statusTxt.text = status;
                    Debug.Log(status);
                }
            }
            else
            {
                statusTxt.text = "Could'nt connect to the internet, Please maintain Internet connectivity.";
                Debug.Log("Error retrieving Leaderboard .....");
            }
        });
    }
}
