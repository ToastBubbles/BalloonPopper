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

	float RotationSpeed = 1f;
	public override void _Process(double delta)
	{
		Vector2 mousePos = GetGlobalMousePosition();
		Vector2 dir = mousePos - lastMousePos;
		// Position = mousePos;
		// GD.Print(dir);
		float targetRotation = Mathf.Atan2(dir.Y, dir.X);

		Vector2 lookDir = GlobalPosition - mousePos;

		LookAt(mousePos);
		// Interpolate the current rotation to the target rotation
		// Rotation = (float)Mathf.Lerp(Rotation, targetRotation, RotationSpeed * delta);
		Vector2 myPos = new Vector2((float)Mathf.Lerp(GlobalPosition.X, mousePos.X, delta * 2), (float)Mathf.Lerp(GlobalPosition.Y, mousePos.Y, delta * 2));
		Position = myPos;
		lastMousePos = mousePos;
	}

}
