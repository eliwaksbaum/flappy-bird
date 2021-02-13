using UnityEngine;

public class LoseState : GameState
{
    public override void Enter(GameController gameController)
    {
        gameController.text.DisplayText(TextDisplayer.Texts.Lose, gameController.player.score);
        gameController.pipePairSpawner.StopCoroutine("spawn");
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
        gameController.player.gameObject.SetActive(true);
    }
}
