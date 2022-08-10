using Godot;
using Godot;
using System;

public class Player : KinematicBody
{
	[Export]
	private float Speed = 200;
	Vector2 dir = Vector2.Zero;
	Vector3 mDir = Vector3.Zero;

	AnimatedSprite3D sprite;
	Camera cam;
	public Vector3 CamForward;

	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite3D>("AnimatedSprite3D");
		cam = GetNode("%DollyFollow").GetNode<Camera>("FollowCam");
	}

	public override void _PhysicsProcess(float delta)
	{
		Move();
		mDir = dir.y * cam.GlobalTransform.basis.z.Normalized() + dir.x * cam.GlobalTransform.basis.x.Normalized();
		MoveAndSlide(mDir * delta * Speed, Vector3.Up);
		base._PhysicsProcess(delta);
	}
	void Move()
	{
		if (Input.IsActionPressed("ui_up")) { dir = Vector2.Up; sprite.Animation = "up"; }
		else if (Input.IsActionPressed("ui_down")) { dir = Vector2.Down; sprite.Animation = "down"; }
		else if (Input.IsActionPressed("ui_left")) { dir = Vector2.Left; sprite.Animation = "side"; sprite.FlipH = false; }
		else if (Input.IsActionPressed("ui_right")) { dir = Vector2.Right; sprite.Animation = "side"; sprite.FlipH = true; }
		else dir = Vector2.Zero;
		sprite.Playing = (dir != Vector2.Zero);
	}


}
