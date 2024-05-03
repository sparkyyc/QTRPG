using Godot;
using System;
using System.Collections.Generic;
using Quadtree;
using System.Drawing;

public partial class PlayerQT : Node2D
{
	Quad _rootQuadTree = null;
    List<Node2D> _bodies = new List<Node2D>();
	int range_size = 300;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
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
			Rect2 rangePosition = new Rect2(GlobalPosition.X - (range_size/2), GlobalPosition.Y - (range_size/2), new Vector2(range_size, range_size));
            foreach (Node2D body in _bodies)
            {	
                if (_rootQuadTree.SearchRange(body.Position, rangePosition).data == 1){
					body.Visible = true;
				} else {
					body.Visible = false;
				}
				
            }
        }
    }
}
