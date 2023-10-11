using Godot;
using System;

public partial class Shred : RigidBody2D
{
	public bool isAvailable = true {get;set;};

	private bool resetState = false;

	private Vector2 pos = new(0, 0);
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void ApplyData(Vector2 pos, Color color)
	{
		this.pos = pos;
		Modulate = color;
		resetState = true;

	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		if (resetState)
		{
			state.Transform = new Transform2D(0, pos);
			resetState = false;
		}
	}
}
