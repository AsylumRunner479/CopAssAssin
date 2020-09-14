using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode : MonoBehaviour
{
    public int teamAmount = 2;
    public List<Team> teams;
    protected void Start()
    {
        SetUpGame();
    }
    public void SetUpGame()
    {
        for (int teamID = 1; teamID < teamAmount; teamID++)
        {
            teams.Add(new Team(teamID));
        }
    }
    public void AddScore(int teamID, int score)
    {
       
        foreach (Team team in teams)
        {
            if (team.teamID == teamID)
            {
                teams[teamID].score += score;
                return;
            }
            
        }
    }
    [System.Serializable]
    public class Team
    {
        public int score;
        public int teamID = 0;
        public Team(int teamID)
        {
            this.teamID = teamID;
        }
    }
}
