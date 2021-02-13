using UnityEngine;

public class PlayState : GameState
{
    bool birdDead;
    GameController gc;

    public override void Enter(GameController gameController)
    {
        Bird.OnHit += BirdFall;
        gameController.text.DisplayText(TextDisplayer.Texts.Play);
        gameController.player.scoreText.enabled = true;
        gameController.player.score = 0;
        gc = gameController;
        birdDead = false;
    }

    public override void Update(GameController gameController)
    {
        if (!birdDead)
        {
            if (Input.GetButtonDown("Jump") || gameController.player.jumpPressed)
            {
                gameController.player.jumpPressed = true;
            }
            else if (Input.GetButtonDown("Pause"))
            {
                gameController.ChangeState(GameState.pause);
            }
        }
        else
        {
            if (gameController.player.transform.position.y < -10.5f)
            {
                Bird newBird = gameController.player.Reset();
                gameController.player.Clear();
                gameController.player = newBird;
                gameController.ChangeState(GameState.lose);
            }
        }
    }

    public override void Exit(GameController gameController)
    {
        Bird.OnHit -= BirdFall;
        gameController.player.scoreText.enabled = false;
        gameController.text.DeleteText();
    }

    void BirdFall()
    {
        birdDead = true;
        gc.text.DeleteText();
    }

    void OnDisable()
    {
        Bird.OnHit -= BirdFall;
    }
}
