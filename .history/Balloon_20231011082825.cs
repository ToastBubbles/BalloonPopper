using Godot;
using System;

public partial class Balloon : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	float deviation = 0;
	float floatSpeed = -50;
	public override void _Ready()
	{
		deviation = GD.Randf() - 0.5f;
		floatSpeed = (float)GD.RandRange(-50, -75);
		Connect("body_entered", se, "_on_BodyEntered");
        Connect("body_exited", this, "_on_BodyExited");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2(deviation, floatSpeed);

		// Set the linear velocity of the RigidBody2D to move it
		LinearVelocity = velocity;
	}
	private void _on_BodyEntered(Node body)
	{
		if (body is RigidBody2D)
		{
			GD.Print("Collision detected with the other RigidBody2D!");
			// Perform actions or logic for the collision
		}
	}

	private void _on_BodyExited(Node body)
	{
		if (body is RigidBody2D)
		{
			GD.Print("Collision with the other RigidBody2D ended.");
			// Perform actions when the collision ends
		}
	}
}
