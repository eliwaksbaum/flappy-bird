using UnityEngine;

public class GameController : MonoBehaviour
{

    public Bird player;
    public PipePairSpawner pipePairSpawner;
    public Scroller ground;
    public Scroller background;
    public TextDisplayer text;

    GameState currentState = GameState.start;

    void Start()
    {
        currentState.Enter(this);
    }

    void Update()
    {
        currentState.Update(this);
        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log(player.score);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState.Exit(this);
        currentState = newState;
        currentState.Enter(this);
    }
}
