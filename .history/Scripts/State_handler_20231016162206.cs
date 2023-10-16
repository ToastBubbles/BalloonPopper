using Godot;
using System;

public partial class State_handler : Node2D
{

	public float balloonSpeedAdd = 0f;
	[Export]
	public float maxBalloonSpeedAdd = 1000f;
	AudioStreamPlayer2D audioPlayerFail;

	private int score = 0;
	private int misses = 0;

	private float playerSpeedMod = 0;

	Timer timer;

	Player player;
	Label scoreLabel;
	Label missesLabel;
	Label debugLabel;
	public override void _Ready()
	{
		player = GetNode<Player>("%Player");
		audioPlayerFail = GetNode<AudioStreamPlayer2D>("FailAudio");
		timer = GetNode<Timer>("Timer");
		debugLabel = GetNode<Label>("Debug");
		scoreLabel = GetNode<Label>("Score");
		missesLabel = GetNode<Label>("Misses");
		timer.Timeout += IncreaseDifficulty;
		timer.Start();
		scoreLabel.Text = "Score: 0";
		missesLabel.Text = "Misses: 0";
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}

	public void AddPoint(int pointsToAdd, int powerupIndex)
	{
		if (misses == 0)
		{
			score += pointsToAdd;
			scoreLabel.Text = "Score: " + score.ToString();
			if (powerupIndex == 1)
			{

				player.IncreaseSpeed();
			}
		}
	}

	private void IncreaseDifficulty()
	{
		if (balloonSpeedAdd < maxBalloonSpeedAdd)
		{
			balloonSpeedAdd += 10f;
		}
		debugLabel.Text = "Speed add: " + balloonSpeedAdd.ToString();
	}
	public void MissedBalloon()
	{
		audioPlayerFail.Play();
		misses++;
		missesLabel.Text = "Misses: " + misses.ToString();
		missesLabel.Modulate = new Color(1, 0, 0, 1);
		missesLabel.Scale *= 1.25f;
	}
}
