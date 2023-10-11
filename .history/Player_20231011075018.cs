using Godot;
using System;

public partial class Player : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	Vector2 lastMousePos = new();
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetGlobalMousePosition();
		Position = mousePos;

		lastMousePos = mousePos;
	}

}
