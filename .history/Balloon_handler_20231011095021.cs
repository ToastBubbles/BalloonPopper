using Godot;
using System;

public partial class Balloon_handler : Node2D
{
	[Export]
	public int maxBalloons = 20;

	private int screenWidth;
	private int screenHeight;

	private PackedScene balloonPath = GD.Load<PackedScene>("res://balloon.tscn");

	private Node2D balloonContainer;
	public override void _Ready()
	{
		balloonContainer = GetNode<Node2D>("BalloonContainer");
		screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");
		screenHeight = (int)ProjectSettings.GetSetting("display/window/size/viewport_height");
		GD.Print(screenHeight);
		GD.Print(screenWidth);
		int count = 0;
		while(count < maxBalloons){
			var instance = ba.Instantiate();
			balloonContainer.AddChild(instance);
			count++;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
