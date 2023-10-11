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


	public override void _Process(double delta)
	{
		Vector2 mousePos = GetGlobalMousePosition();
		Vector2 dir = mousePos - lastMousePos;
		Position = mousePos;
		GD.Print(dir);
		float targetRotation = Mathf.Atan2(directionVector.y, directionVector.x);

        // Interpolate the current rotation to the target rotation
        Rotation = Rotation.LinearInterpolate(targetRotation, RotationSpeed * delta);

		lastMousePos = mousePos;
	}

}
