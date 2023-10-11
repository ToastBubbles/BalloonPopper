using Godot;
using System;

public partial class Balloon : RigidBody2D
{
	[Signal]
	public delegate void PopShredsEventHandler(Vector2 pos, Color color);
	float deviation = 0;
	float floatSpeed = -50;
	Color color = new();

	bool isOnScreen = true;
	public override void _Ready()
	{
		color = new(GD.Randf(), GD.Randf(), GD.Randf(), 1);
		deviation = GD.Randf() - 0.5f;
		floatSpeed = (float)GD.RandRange(-50, -75);
		GetNode<Area2D>("PopBox").AreaEntered += Pop;
		GetNode<Sprite2D>("BalloonSprite").Modulate = color;
		GetParent().GetParent<Balloon_handler>().GetPop += PopShreds;
		GD.Print(GlobalPosition);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		if (isOnScreen)
		{
			Vector2 velocity = new Vector2(deviation, floatSpeed);

			// Set the linear velocity of the RigidBody2D to move it
			LinearVelocity = velocity;
		}
	}

	private void Pop(Area2D body)
	{
		EmitSignal(SignalName.PopShreds, GlobalPosition, color);
		GD.Print("Popped");
		isOnScreen = false;

	}

	public override void _IntegrateForces(PhysicsDirectBodyState2D state)
	{
		if (!isOnScreen)
		{
			state.Transform = new Transform2D(0, new Vector2(-1000, 0));
		}
	}

}
