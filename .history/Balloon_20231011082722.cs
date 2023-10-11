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
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2(deviation, floatSpeed);

		// Set the linear velocity of the RigidBody2D to move it
		LinearVelocity = velocity;
	}
	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		// Check for collisions with the other RigidBody2D
		RigidBody2D otherRigidBody = GetNode<RigidBody2D>("../OtherRigidBody2DNodeName");
		if (IsColliding() && IsOnContacts(otherRigidBody))
		{
			GD.Print("Collision detected with the other RigidBody2D!");
			// Perform actions or logic for the collision
		}
	}
}
