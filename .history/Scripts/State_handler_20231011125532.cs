using Godot;
using System;

public partial class State_handler : Node2D
{

	public float balloonSpeedAdd = 0f;
	AudioStreamPlayer2D audioPlayerFail;

	Timer timer;
	public override void _Ready()
	{
		audioPlayerFail = GetNode<AudioStreamPlayer2D>("FailAudio");
		timer = GetNode<Timer>("Timer");
		timer.ti
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void MissedBalloon()
	{
		audioPlayerFail.Play();
	}
}
