using Godot;
using System;

public partial class Balloon_handler : Node2D
{
	[Export]
	public int maxBalloons = 20;
	[Export]
	public int wallBuffer = 20;

	private int screenWidth;
	private int screenHeight;

	private PackedScene balloonPath = GD.Load<PackedScene>("res://balloon.tscn");

	private Node2D balloonContainer;

	Random rand = new();
	public override void _Ready()
	{
		balloonContainer = GetNode<Node2D>("BalloonContainer");
		screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
		GD.Print(screenHeight);
		GD.Print(screenWidth);
		int count = 0;
		while (count < maxBalloons)
		{
			Node2D instance = (Node2D)balloonPath.Instantiate();
			instance.GlobalPosition = new Vector2(rand.Next(wallBuffer, screenWidth - wallBuffer), screenHeight + 20);
			balloonContainer.AddChild(instance);


			count++;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void GetPop(Vector2 pos, Color color)
	{
		GD.Print("Got it", pos);
	}
}
