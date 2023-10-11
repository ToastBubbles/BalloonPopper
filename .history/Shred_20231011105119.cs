using Godot;
using System;

public partial class Shred : RigidBody2D
{
	public bool isAvailable { get; set; } = true;

	private bool resetState = false;

	private Vector2 pos = new(0, 0);

	private int screenHeight;
	public override void _Ready()
	{
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
	}
	int frameCount = 50;
	int temp = 0;

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (!isAvailable && GlobalPosition.Y > screenHeight - 200)
		{
			isAvailable = true;
			SetDeferred("Freeze", true);
		}
		if()
		GD.Print($"isAvail: {isAvailable} isFroze: {Freeze}");

	}

	public void ApplyData(Vector2 pos, Color color)
	{
		SetDeferred("Freeze", false);
		isAvailable = false;
		this.pos = pos;
		Modulate = color;
		resetState = true;

	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		if (resetState)
		{
			// GD.Print("moving shred to ", pos);
			state.Transform = new Transform2D(0, pos);
			state.LinearVelocity = new();
			resetState = false;

		}
		// if (isAvailable)
		// {
		// 	state.SetDeferred("Freeze", true);
		// }
		// else
		// {
		// 	state.SetDeferred("Freeze", false);
		// }

	}
}
