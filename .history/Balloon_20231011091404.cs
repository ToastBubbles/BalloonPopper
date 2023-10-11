using Godot;
using System;

public partial class Balloon : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	float deviation = 0;
	float floatSpeed = -50;
	Color color = new();
	public override void _Ready()
	{
		color = new(GD.Randf(), GD.Randf(), GD.Randf(), 1);
		deviation = GD.Randf() - 0.5f;
		floatSpeed = (float)GD.RandRange(-50, -75);
		GetNode<Area2D>("PopBox").AreaEntered += Pop;
		GetNode<Sprite2D>("BalloonSprite").Modulate()

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector2 velocity = new Vector2(deviation, floatSpeed);

		// Set the linear velocity of the RigidBody2D to move it
		LinearVelocity = velocity;
	}

	private void Pop(Area2D body)
	{
		GD.Print("Popped");
	}

}