using Godot;
using System;

public enum Powerup
{
	None,
	Speed,
	Spike,

}

public partial class Balloon : RigidBody2D
{

	private Texture speedTexture;
	private Texture spikeTexture;

	private Powerup powerup = Powerup.None;
	[Signal]
	public delegate void PopShredsEventHandler(Vector2 pos, Color color);

	[Signal]
	public delegate void AddPointEventHandler(int points, int powerupIndex);

	[Signal]
	public delegate void OOBEventHandler();

	State_handler stateHandler;
	float deviation = 0;


	float floatSpeed = -50;
	Color color = new();

	public bool isOnScreen = false;
	public override void _Ready()
	{
		speedTexture = GD.Load("res://")
		color = new(GD.Randf(), GD.Randf(), GD.Randf(), 1);

		stateHandler = GetParent().GetParent().GetParent().GetNode<State_handler>("StateHandler");
		ShuffleAttributes();
		GetNode<Area2D>("PopBox").AreaEntered += Pop;
		AddPoint += stateHandler.AddPoint;
		OOB += stateHandler.MissedBalloon;
		GetNode<Sprite2D>("BalloonSprite").Modulate = color;
		PopShreds += GetParent().GetParent<Balloon_handler>().GetPop;


	}

	public void ShuffleAttributes(Powerup pUp = Powerup.None)
	{
		Sprite2D glow = GetNode<Sprite2D>("GlowBG");
		Sprite2D powerupSprite = GetNode<Sprite2D>("PowerupSprite");

		deviation = (GD.Randf() - 0.5f) * 75;
		floatSpeed = (float)GD.RandRange(-50, -150) - stateHandler.balloonSpeedAdd;
		color = new(GD.Randf(), GD.Randf(), GD.Randf(), 1);
		GetNode<Sprite2D>("BalloonSprite").Modulate = color;
		powerup = pUp;
		if (powerup != Powerup.None)
		{
			GD.Print(glow.Visible);
			glow.Modulate = color;
			glow.Visible = true;
			//convert color to a float between 0.0 - 3.0 where 0 is black and 3 is white
			//basically if the color is closer to white, it will make the icon black and vise versa
			float colVal = color.R + color.G + color.B;
			if (colVal >= 1.2)
			{
				powerupSprite.Modulate = new Color(0, 0, 0, 1);
			}
			else
			{
				powerupSprite.Modulate = new Color(1, 1, 1, 1);
			}
			powerupSprite.Visible = true;


		}
		else
		{
			glow.Visible = false;
			powerupSprite.Visible = false;
		}
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
		EmitSignal(SignalName.AddPoint, 1, (int)powerup);

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
