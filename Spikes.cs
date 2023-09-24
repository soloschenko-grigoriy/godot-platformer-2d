using Godot;

namespace Platformer2DProject;

public partial class Spikes : Area2D
{
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