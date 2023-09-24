using Godot;

namespace Platformer2DProject;

public partial class Coin : Area2D
{
    [Export] private int _scoreValue = 1;
    [Export] private float _moveHeight = 5.0f;
    [Export] private float _moveSpeed = 5.0f;

    private float _startY;
    private float _t = 0.0f;
    
    public override void _Ready()
    {
        _startY = GlobalPosition.Y;
    }

    public override void _Process(double delta)
    {
        _t += (float) delta;
        
        var d = (Mathf.Sin(_t * _moveSpeed) + 1) / 2.0f;
        var globalPosition = GlobalPosition;
        globalPosition.Y = _startY + (d * _moveHeight);

        GlobalPosition = globalPosition;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("Player") && body is Player player)
        {
            player.IncreaseScore(_scoreValue);
            QueueFree();
        }
    }
}