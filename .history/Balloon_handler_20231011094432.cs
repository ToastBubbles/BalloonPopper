using Godot;
using System;

public partial class Balloon_handler : Node2D
{
	[Export]
	public int maxBalloons = 20;

	private int screenWidth;
	private int screenHeight;
	public override void _Ready()
	{
		screenHeight = Glo.get("display/width")
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
