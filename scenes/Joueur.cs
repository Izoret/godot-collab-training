using Godot;
using System;

public partial class Joueur : Area2D
{
	[Export]
    private int SPEED = 400;
    private AnimatedSprite2D animatedSprite;
    private CollisionShape2D collisionShape2D;
    private Vector2 velocity;
    private Vector2 screensize;

	public override void _Ready()
	{
		screensize = GetViewportRect().Size;
        animatedSprite = (AnimatedSprite2D)GetNode("AnimatedSprite2D");
        collisionShape2D = (CollisionShape2D)GetNode("CollisionShape2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		velocity = new Vector2();

        if (Input.IsActionPressed("ui_right"))
        {
            velocity.X += 1;
        }

        if (Input.IsActionPressed("ui_left"))
        {
            velocity.X -= 1;
        }

        if (Input.IsActionPressed("ui_down"))
        {
            velocity.Y += 1;
        }

        if (Input.IsActionPressed("ui_up"))
        {
            velocity.Y -= 1;
        }

        if (velocity.Length() > 0)
        {
            velocity = velocity.Normalized() * SPEED;
            animatedSprite.Play();
        }
        else
        {
            animatedSprite.Stop();
        }

        Position = Position + velocity * (float)delta;

		Position = new Vector2(
        Mathf.Clamp(Position.X, 0, screensize.X),
        Mathf.Clamp(Position.Y, 0, screensize.Y)
    	);

		if (velocity.X != 0){
			animatedSprite.Animation = "droite";
			animatedSprite.FlipH = velocity.X < 0;
			animatedSprite.FlipV = false;
		}
		else {
			animatedSprite.Animation = "haut";
			animatedSprite.FlipV = velocity.Y > 0;
		}
		
	}

	
}
