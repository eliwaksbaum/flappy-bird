
public abstract class GameState
{
    public static StartState start = new StartState();
    public static CountdownState countdown = new CountdownState();
    public static PlayState play = new PlayState();
    public static PauseState pause = new PauseState();
    public static LoseState lose = new LoseState();

    public abstract void Enter(GameController gameController);
    public abstract void Update(GameController gameController);
    public abstract void Exit(GameController gameController);
}
