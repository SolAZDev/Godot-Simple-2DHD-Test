using Godot;
using System;

public class NPC : Area
{
	[Export] public SpriteFrames frames;
	private AnimatedSprite3D sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if (frames == null) return;
		sprite = GetNode<AnimatedSprite3D>("AnimatedSprite3D");
		sprite.Frames = frames;
	}

	//  // Called every frame. 'delta' is the elapsed time since the previous frame.
	//  public override void _Process(float delta)
	//  {
	//      
	//  }
}
