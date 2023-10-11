using Godot;
using System;

public partial class Balloon_handler : Node2D
{
	[Export]
	public int maxBalloons = 20;

	[Export]
	public int maxShreds = 50;
	[Export]
	public int wallBuffer = 20;

	private int shredsPerBalloon = 5;

	private int screenWidth;
	private int screenHeight;

	private PackedScene balloonPath = GD.Load<PackedScene>("res://balloon.tscn");
	private PackedScene shredPath = GD.Load<PackedScene>("res://shred.tscn");
	private Node2D balloonContainer;
	private Node2D shredContainer;
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

		int count2 = 0;
		while (count2 < maxShreds)
		{
			Node2D instance = (Node2D)shredPath.Instantiate();
			instance.GlobalPosition = new Vector2(-100, -100);
			shredContainer.AddChild(instance);


			count2++;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnShreds(Vector2 pos, Color color)
	{
		List<Shred> children = shredContainer.GetChildren();

		foreach (var child in children)
		{
			if()
		}


	}

	public void GetPop(Vector2 pos, Color color)
	{
		GD.Print("Got it ", pos, color);
	}
}
