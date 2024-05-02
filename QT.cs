using Godot;
using System;


namespace Quadtree{


struct Point
{
    public int x;
    public int y;

    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
    }
}

struct NodeQT

{
    public Vector2 pos;
    public int data;

    public NodeQT
    (Vector2 _pos)
    {
        pos = _pos;
        data = 1;
    }
}

class Quad
{
    private Vector2 topLeft;
    private Vector2 bottomRight;

    private NodeQT
     n;

    private Quad topLeftTree;
    private Quad topRightTree;
    private Quad bottomLeftTree;
    private Quad bottomRightTree;

    public int Children = 4;
    public int Capacity = 4;

    public Quad()
    {
        topLeft = new Vector2(0, 0);
        bottomRight = new Vector2(0, 0);
        n = new NodeQT
        ();
        topLeftTree = null;
        topRightTree = null;
        bottomLeftTree = null;
        bottomRightTree = null;
    }

    public Quad(Vector2 _topLeft, Vector2 _bottomRight)
    {
        topLeft = _topLeft;
        bottomRight = _bottomRight;
        n = new NodeQT
        ();
        topLeftTree = null;
        topRightTree = null;
        bottomLeftTree = null;
        bottomRightTree = null;
    }

    public void Insert(NodeQT
     node)
    {
        if (node.Equals(default(NodeQT)))
        {
            return;
        }

        if (!InBoundary(node.pos))
        {
            return;
        }

        if (Math.Abs(topLeft.X - bottomRight.X) <= 1 && Math.Abs(topLeft.Y - bottomRight.Y) <= 1)
        {
            if (n.Equals(default(NodeQT)))
            {
                n = node;
            }
            return;
        }

        if ((topLeft.X + bottomRight.X) / 2 >= node.pos.X)
        {
            if ((topLeft.Y + bottomRight.Y) / 2 >= node.pos.Y)
            {
                if (topLeftTree == null)
                {
                    topLeftTree = new Quad(
                        new Vector2(topLeft.X, topLeft.Y),
                        new Vector2((topLeft.X + bottomRight.X) / 2, (topLeft.Y + bottomRight.Y) / 2)
                    );
                }
                topLeftTree.Insert(node);
            }
            else
            {
                if (bottomLeftTree == null)
                {
                    bottomLeftTree = new Quad(
                        new Vector2(topLeft.X, (topLeft.Y + bottomRight.Y) / 2),
                        new Vector2((topLeft.X + bottomRight.X) / 2, bottomRight.Y)
                    );
                }
                bottomLeftTree.Insert(node);
            }
        }
        else
        {
            if ((topLeft.Y + bottomRight.Y) / 2 >= node.pos.Y)
            {
                if (topRightTree == null)
                {
                    topRightTree = new Quad(
                        new Vector2((topLeft.X + bottomRight.X) / 2, topLeft.Y),
                        new Vector2(bottomRight.X, (topLeft.Y + bottomRight.Y) / 2)
                    );
                }
                topRightTree.Insert(node);
            }
            else
            {
                if (bottomRightTree == null)
                {
                    bottomRightTree = new Quad(
                        new Vector2((topLeft.X + bottomRight.X) / 2, (topLeft.Y + bottomRight.Y) / 2),
                        new Vector2(bottomRight.X, bottomRight.Y)
                    );
                }
                bottomRightTree.Insert(node);
            }
        }
    }

    public NodeQT Search(Vector2 p)
    {
        if (!InBoundary(p))
        {
            return default;
        }

        if (!n.Equals(default(NodeQT)))
        {
            return n;
        }

        if ((topLeft.X + bottomRight.X) / 2 >= p.X)
        {
            if ((topLeft.Y + bottomRight.Y) / 2 >= p.Y)
            {
                if (topLeftTree == null)
                {
                    return default(NodeQT);
                }
                return topLeftTree.Search(p);
            }
            else
            {
                if (bottomLeftTree == null)
                {
                    return default(NodeQT);
                }
                return bottomLeftTree.Search(p);
            }
        }
        else
        {
            if ((topLeft.Y + bottomRight.Y) / 2 >= p.Y)
            {
                if (topRightTree == null)
                {
                    return default(NodeQT);
                }
                return topRightTree.Search(p);
            }
            else
            {
                if (bottomRightTree == null)
                {
                    return default(NodeQT);
                }
                return bottomRightTree.Search(p);
            }
        }
    }
    

    private bool InBoundary(Vector2 p)
    {
        return (
            p.X >= topLeft.X && p.X <= bottomRight.X && p.Y >= topLeft.Y && p.Y <= bottomRight.Y
        );
    }
}

// class Program
// {
//     static void Main()
//     {
//         Quad center = new Quad(new Point(0, 0), new Point(8, 8));
//         Node a = new Node(new Point(1, 1), 1);
//         Node b = new Node(new Point(2, 5), 2);
//         Node c = new Node(new Point(7, 6), 3);
//         center.Insert(a);
//         center.Insert(b);
//         center.Insert(c);

//         Console.WriteLine("Node a: " + center.Search(new Point(1, 1)).data);
//         Console.WriteLine("Node b: " + center.Search(new Point(2, 5)).data);
//         Console.WriteLine("Node c: " + center.Search(new Point(7, 6)).data);
//         Console.WriteLine("Non-existing node: " + center.Search(new Point(5, 5)).data);
//     }
// }

}
