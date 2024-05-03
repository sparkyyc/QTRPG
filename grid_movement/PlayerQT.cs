using System;
using System.Collections.Generic;
using System.Linq;
using Godot;
using Quadtree;

public partial class PlayerQT : Node2D
{
    Quad _rootQuadTree = null;
    List<Node2D> _bodies = new List<Node2D>();
    int range_size = 325;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _rootQuadTree = new Quad(new Vector2(0, 0), new Vector2(1280, 720));
        _bodies = GetTree().GetNodesInGroup("Enemy").Cast<Node2D>().ToList();
        foreach (Node2D body in _bodies)
        {
            _rootQuadTree.Insert(new NodeQT(body.Position));
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (Input.IsAnythingPressed())
        {
            Rect2 rangePosition = new Rect2(
                GlobalPosition.X - (range_size / 2),
                GlobalPosition.Y - (range_size / 2),
                new Vector2(range_size, range_size)
            );
            foreach (Node2D body in _bodies)
            {
                int isVis = _rootQuadTree.SearchRange(body.Position, rangePosition).data;
                GD.Print(isVis);
                GD.Print(body.Position);
                GD.Print(rangePosition);
                if (isVis == 1)
                {
                    body.Visible = true;
                }
                else
                {
                    body.Visible = false;
                }
            }
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.IsReleased())
        {
            Rect2 rangePosition = new Rect2(
                GlobalPosition.X - (range_size / 2),
                GlobalPosition.Y - (range_size / 2),
                new Vector2(range_size, range_size)
            );
            foreach (Node2D body in _bodies)
            {
                int isVis = _rootQuadTree.SearchRange(body.Position, rangePosition).data;
                if (isVis == 1)
                {
                    body.Visible = true;
                }
                else
                {
                    body.Visible = false;
                }
            }
        }
    }
}
