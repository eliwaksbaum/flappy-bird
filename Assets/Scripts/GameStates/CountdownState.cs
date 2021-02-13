using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownState : GameState
{
    GameController gc;

    public override void Enter(GameController gameController)
    {
        gameController.pipePairSpawner.ClearPipes();
        gameController.text.DisplayText(TextDisplayer.Texts.CountDown);
        gc = gameController;
        CountDownText.CountDone += ToPlay;
    }

    public override void Update(GameController gameController) {}
    
    public override void Exit(GameController gameController)
    {
        gameController.player.SetFalling(true);
        gameController.pipePairSpawner.StartCoroutine("spawn");
        gameController.text.DeleteText();
        CountDownText.CountDone -= ToPlay;
    }

    void ToPlay()
    {
        gc.ChangeState(GameState.play);
    }

    void OnDisable()
    {
        CountDownText.CountDone -= ToPlay;
    }
}
