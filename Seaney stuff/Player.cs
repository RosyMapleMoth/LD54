using Godot;
using System;
using System.Diagnostics;

public class Player : KinematicBody2D
{
	[Export]
	private float Speed;



	// Declare member variables here. Examples:
	// private int a = 2;
	// private string b = "text";

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetMeta("Crushable", true);
		SetMeta("Type", "Player");
	}

	public override void _PhysicsProcess(float delta)
	{
		var change = new Vector2(0,0);
			
		if (Input.IsActionPressed("player_move_right"))
		{
			change += new Vector2(Speed * delta, 0);
		}
		if (Input.IsActionPressed("player_move_left"))
		{
			change += new Vector2(-Speed * delta,0);
		}
		if (Input.IsActionPressed("player_move_up"))
		{
			change += new Vector2(0,  -Speed * delta);
		}
		if (Input.IsActionPressed("player_move_down"))
		{
			change += new Vector2(0, Speed * delta);
		}
		//Debug.WriteLine("Move Vector : " + change.ToString());
		MoveAndCollide(change);
	}

	public void _on_Area_area_entered(object area)
	{
		Console.WriteLine("PowerUp collected");
	}

}

