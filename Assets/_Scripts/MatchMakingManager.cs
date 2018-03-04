using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchMakingManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MatchMaking("QUIZ_BATTLE", 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MatchMaking(string matchShortCode, long skill)
    {
        new GameSparks.Api.Requests.MatchmakingRequest().SetMatchShortCode(matchShortCode).SetSkill(skill).Send((response) =>
        {
            if (!response.HasErrors)
            {
                Debug.Log(response.JSONString);
            }
            else
            {
                Debug.Log(response.JSONString);
            }
        });
    }
}
