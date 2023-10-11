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

	private PackedScene balloonPath = GD.Load<PackedScene>("res://Scenes/balloon.tscn");
	private PackedScene shredPath = GD.Load<PackedScene>("res://Scenes/shred.tscn");
	private Node2D balloonContainer;
	private Node2D shredContainer;
	private Timer timer;
	Random rand = new();
	public override void _Ready()
	{
		timer = GetNode<Timer>("Timer");
		balloonContainer = GetNode<Node2D>("BalloonContainer");
		shredContainer = GetNode<Node2D>("ShredContainer");
		audioPlayer = GetParent().GetNode<AudioStreamPlayer2D>("PopAudio");
		screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");

		timer.Timeout += SpawnBalloon;

		timer.Start();

		int count = 0;
		while (count < maxBalloons)
		{
			Node2D instance = (Node2D)balloonPath.Instantiate();
			//instance.GlobalPosition = new Vector2(rand.Next(wallBuffer, screenWidth - wallBuffer), screenHeight + 20);
			instance.GlobalPosition = new Vector2(-100, -100);
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

	private void SpawnBalloon()
	{
		List<Balloon> children = new();


		foreach (var child in balloonContainer.GetChildren())
		{
			children.Add((Balloon)child);
		}
		foreach (Balloon balloon in children)
		{
			if (!balloon.isOnScreen)
			{
				balloon.GlobalPosition = new Vector2(rand.Next(wallBuffer, screenWidth - wallBuffer), screenHeight + 20);
				balloon.shuffleAttributes
				balloon.isOnScreen = true;
				break;
			}

		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void SpawnShreds(Vector2 pos, Color color)
	{
		audioPlayer.Play();
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
