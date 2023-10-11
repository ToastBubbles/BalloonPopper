using Godot;
using System;

public partial class Balloon : RigidBody2D
{
	[Signal]
	public delegate void PopShredsEventHandler(Vector2 pos, Color color);

	[Signal]
	public delegate void OOBEventHandler();

	State_handler stateHandler;
	float deviation = 0;


	float floatSpeed = -50;
	Color color = new();

	public bool isOnScreen = false;
	public override void _Ready()
	{
		color = new(GD.Randf(), GD.Randf(), GD.Randf(), 1);

		stateHandler = GetParent().GetParent().GetParent().GetNode<State_handler>("StateHandler");
SetA
		GetNode<Area2D>("PopBox").AreaEntered += Pop;

		OOB += stateHandler.MissedBalloon;
		GetNode<Sprite2D>("BalloonSprite").Modulate = color;
		PopShreds += GetParent().GetParent<Balloon_handler>().GetPop;


	}

	private void setAttributes()
	{
		deviation = GD.Randf() - 0.5f;
		floatSpeed = (float)GD.RandRange(-50, -150) + stateHandler.balloonSpeedAdd;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{

		if (isOnScreen)
		{
			Vector2 velocity = new Vector2(deviation, floatSpeed);

			// Set the linear velocity of the RigidBody2D to move it
			LinearVelocity = velocity;
			if (GlobalPosition.Y < -50)
			{
				isOnScreen = false;
				EmitSignal(SignalName.OOB);
			}
		}
	}

	private void Pop(Area2D body)
	{
		EmitSignal(SignalName.PopShreds, GlobalPosition, color);

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
