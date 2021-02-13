using UnityEngine;

public class PauseState : GameState
{
    public override void Enter(GameController gameController)
    {
        gameController.player.SetFalling(false);
        gameController.ground.inPlay = false;
        gameController.background.inPlay = false;
        gameController.pipePairSpawner.SetPipes(false);
        gameController.text.DisplayText(TextDisplayer.Texts.Pause);
    }
    public override void Update(GameController gameController)
    {
        if (Input.GetButtonDown("Pause"))
        {
            gameController.ChangeState(GameState.play);
        }
    }
    public override void Exit(GameController gameController)
    {
        gameController.player.SetFalling(true);
        gameController.ground.inPlay = true;
        gameController.background.inPlay = true;
        gameController.pipePairSpawner.SetPipes(true);
        gameController.text.DeleteText();
    }
}
