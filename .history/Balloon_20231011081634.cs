using Godot;
using System;

public partial class Balloon : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	float deviation = 0;
	float floatSpeed =
	public override void _Ready()
	{
		deviation = GD.Randf() - 0.5f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2(deviation, -10);

		// Set the linear velocity of the RigidBody2D to move it
		LinearVelocity = velocity;
	}
}
