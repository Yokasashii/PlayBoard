using Godot;

// Author : Vincent Guerrini / Yoka

namespace Com.Vincent_Guerrini.PlayBoard;
	
public partial class Main : Node2D
{
	[Export] private Button pongButton;
	[Export] private Button snakeButton;
	[Export] private Button breakoutButton;

	private string Pong = "res://Scenes/Games/Pong/Pong.tscn";
	private string Snake = "res://Scenes/Games/Snake/Snake.tscn";
	private string Breakout = "res://Scenes/Games/Breakout/Breakout.tscn";

    public override void _Ready()
	{
		pongButton.Pressed += StartPong;
		snakeButton.Pressed += StartSnake;
		breakoutButton.Pressed += StartBreakout;
    }

	private void StartPong()
	{
		GetTree().ChangeSceneToFile(Pong);
	}

    private void StartSnake()
    {
        GetTree().ChangeSceneToFile(Snake);
    }

    private void StartBreakout()
    {
        GetTree().ChangeSceneToFile(Breakout);
    }

}

