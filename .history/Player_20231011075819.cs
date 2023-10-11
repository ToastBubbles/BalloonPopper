using Godot;
using System;

public partial class Player : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	// Vector2 lastMousePos = new();
	// public override void _Ready()
	// {
	// 	lastMousePos = GetGlobalMousePosition();
	// }

	// float RotationSpeed = 1f;
	// public override void _Process(double delta)
	// {
	// 	Vector2 mousePos = GetGlobalMousePosition();
	// 	Vector2 dir = mousePos - lastMousePos;
	// 	Position = mousePos;
	// 	GD.Print(dir);
	// 	float targetRotation = Mathf.Atan2(dir.Y, dir.X);

	// 	// Interpolate the current rotation to the target rotation
	// 	Rotation = (float)Mathf.Lerp(Rotation, targetRotation, RotationSpeed * delta);

	// 	lastMousePos = mousePos;
	// }
	 // Offset from the mouse cursor to the dart's pivot point
    private Vector2 offset = Vector2.Zero;

    // Speed at which the dart follows the mouse
    public float MoveSpeed = 200.0f;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            // Get the global position of the mouse cursor
            var mouseGlobal = GetGlobalMousePosition();
            
            // Calculate the target position (mouse position with offset)
            var targetPosition = mouseGlobal - offset;

            // Move the dart towards the target position
            MoveAndSlide((targetPosition - Position).Normalized() * MoveSpeed);
        }
    }

    public override void _Ready()
    {
        // Calculate the initial offset from the mouse cursor to the dart's pivot point
        offset = GlobalTransform.Origin - GetGlobalMousePosition();
    }

}
