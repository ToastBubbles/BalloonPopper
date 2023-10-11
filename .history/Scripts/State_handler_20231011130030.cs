using Godot;
using System;

public partial class State_handler : Node2D
{

	public float balloonSpeedAdd = 0f;
	[Export]
	public float maxBalloonSpeedAdd = 100f;
	AudioStreamPlayer2D audioPlayerFail;

	Timer timer;
	public override void _Ready()
	{
		audioPlayerFail = GetNode<AudioStreamPlayer2D>("FailAudio");
		timer = GetNode<Timer>("Timer");
		timer.Timeout += IncreaseDifficulty;
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void IncreaseDifficulty()
	{
if(balloonSpeedAdd < maxBalloonSpeedAdd){
	balloonSpeedAdd += 0.2
}
	}
	public void MissedBalloon()
	{
		audioPlayerFail.Play();
	}
}
