using Godot;

namespace Platformer2DProject;

public partial class Player : CharacterBody2D
{
    [Export] public float moveSpeed = 100f;
    [Export] public float jumpForce = 200f;
    [Export] public float gravity = 500f;

    public override void _PhysicsProcess(double delta)
    {
        var velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity.Y += gravity * (float) delta;
        }

        velocity.X = 0f;

        if (Input.IsActionPressed("move_left"))
        {
            velocity.X -= moveSpeed;
        }

        if (Input.IsActionPressed("move_right"))
        {
            velocity.X += moveSpeed;
        }
        
        if(Input.IsActionPressed("jump") && IsOnFloor())
        {
            velocity.Y -= jumpForce;
        }
            
        Velocity = velocity;
        MoveAndSlide();
    }
}