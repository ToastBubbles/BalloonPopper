using Godot;
using System;

public partial class State_handler : Node2D
{
	AudioStreamPlayer2D audioPlayerFail;
	public override void _Ready()
	{
		audioPlayerFail = GetNode<AudioStr>
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void MissedBalloon()
	{

	}
}