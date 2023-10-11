using Godot;
using System;

public partial class Player : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	Vector2 lastMousePos = new();
	public override void _Ready()
	{
		lastMousePos = GetGlobalMousePosition();
	}

float r
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetGlobalMousePosition();
		Vector2 dir = mousePos - lastMousePos;
		Position = mousePos;
		GD.Print(dir);
		float targetRotation = Mathf.Atan2(dir.y, dir.x);

        // Interpolate the current rotation to the target rotation
        Rotation = Mathf.Lerp(targetRotation, RotationSpeed * delta);

		lastMousePos = mousePos;
	}

}
