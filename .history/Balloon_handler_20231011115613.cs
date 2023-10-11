using Godot;
using System;
using System.Collections.Generic;

public partial class Balloon_handler : Node2D
{
	[Export]
	public int maxBalloons = 20;

	[Export]
	public int maxShreds = 50;
	[Export]
	public int wallBuffer = 20;

	private int shredsPerBalloon = 4;

	private AudioStreamPlayer2D audioPlayer;

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
		shredContainer = GetNode<Node2D>("ShredContainer");
		audioPlayer = GetParent().GetNode<AudioStreamPlayer2D>("Pop");
		screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");

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
		List<Shred> children = new();

		int placed = 0;
		foreach (var child in shredContainer.GetChildren())
		{
			children.Add((Shred)child);
		}
		foreach (Shred shred in children)
		{
			if (shred.isAvailable)
			{
				shred.ApplyData(pos, color);
				placed++;
			}
			if (placed >= shredsPerBalloon)
			{
				break;
			}
		}


	}

	public void GetPop(Vector2 pos, Color color)
	{
		// GD.Print("Got it ", pos, color);
		SpawnShreds(pos, color);
	}
}
