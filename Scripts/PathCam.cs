using Godot;
using System;

public class PathCam : Path
{
    [Export] private NodePath FollowTarget;
    [Export] private NodePath LookTarget;
    [Export] public bool InterpolatePos = true;
    [Export] public float PosSpeed = 1;

    public Camera camera;
    PathFollow follower;
    Spatial _fTarget;
    Spatial _lTarget;




    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        follower = GetNode<PathFollow>("DollyFollow");
        camera = follower.GetNode<Camera>("FollowCam");
        if (FollowTarget != null) _fTarget = GetNode<Spatial>(FollowTarget);
        if (LookTarget != null) _lTarget = GetNode<Spatial>(LookTarget);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (_fTarget == null) return;

        if (InterpolatePos) follower.Offset = Mathf.Lerp(follower.Offset, Curve.GetClosestOffset(ToLocal(_fTarget.GlobalTranslation)), PosSpeed * delta);
        else follower.Offset = Curve.GetClosestOffset(ToLocal(_fTarget.GlobalTranslation));

        if (_lTarget == null) return;
        camera.LookAt(_lTarget.GlobalTransform.origin, Vector3.Up);
    }
}
