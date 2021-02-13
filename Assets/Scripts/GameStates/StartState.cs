using UnityEngine;

public class StartState : GameState
{
    public override void Enter(GameController gameController)
    {
        gameController.text.DisplayText(TextDisplayer.Texts.Start);
    }

    public override void Update(GameController gameController)
    {
        if (Input.GetButtonDown("Enter"))
        {
            gameController.ChangeState(GameState.countdown);
        }
    }

    public override void Exit(GameController gameController)
    {
        gameController.text.DeleteText();
    }
}
