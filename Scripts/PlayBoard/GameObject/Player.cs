using Com.Vincent_Guerrini.PlayBoard;
using Godot;

// Author : Vincent Guerrini / Yoka

namespace Com.Vincent_Guerrini.PlayBoard.GameObject;

public partial class Player : GameObject
{
    public override void _Ready()
	{
        speed = 250;

        base._Ready();
        GD.Print("Spawn");
    }

    public override void _Process(double pDelta)
    {
        float lDelta = (float)pDelta;

        if (Input.IsKeyPressed(Key.Z) && Position.Y >= Height / 2) Position += Vector2.Up * speed * 2 * lDelta;
        if (Input.IsKeyPressed(Key.S) && Position.Y <= screenSize.Y - Height / 2) Position += Vector2.Down * speed * 2 * lDelta;
    }
}
