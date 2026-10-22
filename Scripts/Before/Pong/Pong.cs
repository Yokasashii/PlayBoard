using Com.Vincent_Guerrini.PlayBoard.GameObject;
using Com.Vincent_Guerrini.PlayBoard.GameObject.Pong;
using Godot;
using Godot.Collections;
using System;

public partial class Pong : Node2D
{
    [Export] PackedScene scenePlayer;
    [Export] PackedScene sceneBall;
    [Export] Label score;
    [Export] Timer gameTimer;

    Array<GameObject> elements = [];
    RandomNumberGenerator rand = new RandomNumberGenerator();
    Player player1 = new Player();
    Player player2 = new Player();
    PongBall ball = new PongBall();
    private Vector2 screenSize;
    bool onGame = false;
    int scorePlayer1 = 0;
    int scorePlayer2 = 0;


    public override void _Ready()
    {
        screenSize = GetWindow().Size;
        elements = [
            player1 = (Player)scenePlayer.Instantiate(), 
            player2 = (Player)scenePlayer.Instantiate(), 
            ball = (PongBall)sceneBall.Instantiate()];
        int lCount = elements.Count;
        for (int i = 0; i <= lCount - 1; i++) { AddChild(elements[i]); }
        gameTimer.Timeout += SpeedUpBall;
        StartRound();
    }

    public override void _Process(double pDelta)
    {
        if (onGame)
        {
            CheckRound();
        }
    }

    void StartRound()
    {
        player1.Position = new Vector2(50, screenSize.Y / 2);
        player2.Position = new Vector2(screenSize.X - 50, screenSize.Y / 2);
        ball.Position = new Vector2(screenSize.X / 2, screenSize.Y / 2);
        ball.Scale = new Vector2(rand.Randf() > 0.5 ? 1 : -1, rand.Randf() > 0.5 ? 1 : -1);
        ball.speed = 200;
        score.Text = scorePlayer1 + " : " + scorePlayer2;
        gameTimer.Start(5);
        onGame = true;
    }

    void CheckRound() 
    {
        if (ball.Position.X > screenSize.X) {scorePlayer1++; onGame = false;}
        if (ball.Position.X < 0) {scorePlayer2++; onGame = false;}
        if (!onGame) StartRound();
    }

    void SpeedUpBall()
    {
        ball.speed += 50;
    }

    
}
