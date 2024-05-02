using Godot;
using System;
using System.Collections.Generic;
using Quadtree;

public partial class PlayerQT : Node2D
{
	Quad _rootQuadTree = null;
    List<Node2D> _bodies = new List<Node2D>();
	List<Node2D> _quadrants = new List<Node2D>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(Position.X, Position.Y);
        // Rect2 _sampleBounds = new Rect2(new Vector2(0, 0), new Vector2(64, 64));
        _rootQuadTree = new Quad(new Vector2(0, 0), new Vector2(1280, 720));
        Node2D enemyBody = GetNode<Node2D>("/root/Game/Exploration/Grid/Opponent");
        _bodies.Add(enemyBody);
        _rootQuadTree.Insert(new NodeQT(enemyBody.Position));
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta) { }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent && keyEvent.Pressed)
        {
            foreach (Node2D body in _bodies)
            {
                GD.Print(_rootQuadTree.Search(body.Position).data);
            }
        }
    }
}
