using Godot;
using System;

public partial class State_handler : Node2D
{

	public float balloonSpeedAdd = 0f;
	[Export]
	public float maxBalloonSpeedAdd = 1000f;
	AudioStreamPlayer2D audioPlayerFail;

	private int score = 0;

	Timer timer;
	Label scoreLabel;
	public override void _Ready()
	{
		audioPlayerFail = GetNode<AudioStreamPlayer2D>("FailAudio");
		timer = GetNode<Timer>("Timer");
		scoreLabel = GetNode<Label>
		timer.Timeout += IncreaseDifficulty;
		timer.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void AddPoint(int pointsToAdd)
	{
		score += pointsToAdd;
	}

	private void IncreaseDifficulty()
	{
		if (balloonSpeedAdd < maxBalloonSpeedAdd)
		{
			balloonSpeedAdd += 10f;
		}
	}
	public void MissedBalloon()
	{
		audioPlayerFail.Play();
	}
}
