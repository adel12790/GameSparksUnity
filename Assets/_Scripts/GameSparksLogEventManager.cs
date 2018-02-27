using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSparksLogEventManager : MonoBehaviour {

	public void SetScoreInGameSparks(int score)
    {
        new GameSparks.Api.Requests.LogEventRequest()
            .SetEventKey("leaderboardEvent")
            .SetEventAttribute("score", score)
            .Send((response) => {
                if (!response.HasErrors)
                {
                    Debug.Log("Score Posted Successfully");
                }
                else
                {
                    Debug.Log("Error in posting score, error: " + response.Errors);
                }
        });
    }
}
