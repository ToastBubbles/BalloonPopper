using Godot;
using System;

public partial class Shred : RigidBody2D
{
	public bool isAvailable = true;

	private bool resetState = false;

	private Vector2 pos = new(0, 0);

	private int screenHeight;

	private bool set = false;

	private bool hasSetPos = false;
	public override void _Ready()
	{
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
		Freeze = true;
	}
	int frameCount = 10;
	int temp = 0;

	Random rand = new();
	public override void _PhysicsProcess(double delta)
	{
		if (resetState)
		{
			GD.Print("moving shred to ", pos);
			LinearVelocity = new();
			Transform = new Transform2D(0, pos);

			hasSetPos = true;
			resetState = false;


		}
		if (hasSetPos && GlobalPosition.Y < screenHeight && Freeze)
		{
			Freeze = false;
			ApplyImpulse(new Vector2(rand.Next()), GlobalPosition);
		}



		if (!isAvailable && GlobalPosition.Y > screenHeight && hasSetPos)
		{
			GD.Print($"Now Available  {GlobalPosition} {Position}");
			isAvailable = true;
			Freeze = true;
			hasSetPos = false;
		}
		if (set)
		{
			if (temp >= frameCount)
			{
				GD.Print($"isAvail: {isAvailable} isFroze: {Freeze} pos: {GlobalPosition.Y} vs {screenHeight}");
				temp = 0;
			}
			else
			{
				temp++;
			}
		}


	}

	public void ApplyData(Vector2 pos, Color color)
	{
		GD.Print("applying");
		set = true;
		resetState = true;

		this.pos = pos;
		Modulate = color;
		isAvailable = false;
	}

	// public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	// {
	// 	GD.Print("huh");
	// 	if (resetState)
	// 	{
	// 		GD.Print("moving shred to ", pos);
	// 		state.LinearVelocity = new();
	// 		state.Transform = new Transform2D(0, pos);
	// 		resetState = false;
	// 		hasSetPos = true;

	// 	}
	// 	// if (isAvailable)
	// 	// {
	// 	// 	state.SetDeferred("Freeze", true);
	// 	// }
	// 	// else
	// 	// {
	// 	// 	state.SetDeferred("Freeze", false);
	// 	// }

	// }
}
