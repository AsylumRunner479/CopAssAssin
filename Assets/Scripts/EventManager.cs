using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnGameStart();
    public static event OnGameStart onGameStart;
    float startTime = 3f;
    private void Awake()
    {
        RegisteringToEvent();
        StartCoroutine(GameStarts());
    }
    void RegisteringToEvent()
    {
        onGameStart += SpawnPlayer;
        onGameStart += ResetScores;
    }
    void ResetScores()
    {

    }
    void SpawnPlayer()
    {

    }
    private void Start()
    {
        StartCoroutine(GameStarts());
    }
    IEnumerator GameStarts()
    {
        yield return new WaitForSeconds(startTime);
        onGameStart();
    }
}
