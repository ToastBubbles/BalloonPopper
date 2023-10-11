using Godot;
using System;

public partial class Shred : RigidBody2D
{
	public bool isAvailable = true;

	private bool resetState = false;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ApplyData(Vector2 pos, Color color)
	{
		GlobalPosition = pos;
		Modulate = color;

	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		if (!isOnScreen)
		{
			state.Transform = new Transform2D(0, new Vector2(-1000, 0));
		}
	}
}
