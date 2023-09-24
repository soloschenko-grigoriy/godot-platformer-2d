using Godot;

namespace Platformer2DProject;

public partial class Enemy : Area2D
{
    [Export] public float moveSpeed = 30f;
    [Export] public Vector2 moveDirection;

    private Vector2 _startPosition;
    private Vector2 _targetPosition;
    
    public override void _Ready()
    {
        _startPosition = GlobalPosition;
        _targetPosition = _startPosition + moveDirection;
    }
    
    public override void _Process(double delta)
    {
        GlobalPosition = GlobalPosition.MoveToward(_targetPosition, moveSpeed * (float) delta);

        if (GlobalPosition != _targetPosition)
        {
            return;
        }

        _targetPosition = GlobalPosition == _startPosition ? _startPosition + moveDirection : _startPosition;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (!body.IsInGroup("Player"))
        {
            return;
        }

        if (body is Player player)
        {
            player.GameOver();
        }
    }
}