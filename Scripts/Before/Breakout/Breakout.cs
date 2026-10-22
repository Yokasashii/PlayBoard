using Godot;
using System;

public partial class Breakout : Node2D
{
    [Export] Area2D player;
    [Export] Area2D ball;

    Vector2 screenSize;
    RandomNumberGenerator rand = new RandomNumberGenerator();
      
    public override void _Ready()
    {
        screenSize = GetWindow().Size;
        StartRound();
    }

    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;

        ball.Position += Scale * 200 * lDelta;
        if (ball.Position.X >= screenSize.X || ball.Position.X <= 0) ball.Scale *= new Vector2(-1, 1);
        if (ball.Position.Y >= screenSize.Y || ball.Position.Y <= 0) ball.Scale *= new Vector2(1, -1);
    }

    void StartRound()
    {
        player.Position = new Vector2(screenSize.X / 2, screenSize.Y - 50);
        player.RotationDegrees = 90;

        ball.Position = new Vector2(screenSize.X / 2, screenSize.Y - 100);
        ball.Scale = new Vector2(rand.Randf() >= 0.5 ? 1 : -1 , 1);
    }
}
