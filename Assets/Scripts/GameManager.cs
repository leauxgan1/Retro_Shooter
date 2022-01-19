using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum GameState {
        playing,
        loading
    }
    private GameState state;
    public Enemy[] Enemies;
    // Start is called before the first frame update
    void Start()
    {
        state = GameState.playing;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
