using Godot;
using System;

public class Player : Spatial
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private float MOUSE_SPEED = 0.2f;
    private Spatial rotation;
    private Area footpad;
    // Movement
    private Vector3 dir;
    private Vector3 pos;
    private float ACC_SPEED = 0.2f;
    private float DEACC_SPEED = 0.6f;
    private float MAX_SPEED = 2f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        rotation = GetNode<Spatial>("Rotation");
        footpad = GetNode<Area>("footPad");
        pos = new Vector3(0, 0, 0);
    }
    public override void _PhysicsProcess(float delta)
    {
        Vector3 applyForce = new Vector3(0, 0, 0);
        
        if(Input.IsActionPressed("ui_up")){
            applyForce.z -= ACC_SPEED;
        }
        if(Input.IsActionPressed("ui_down")){
            applyForce.z += ACC_SPEED;
        }
        if(Input.IsActionPressed("ui_left")){
            applyForce.x -= ACC_SPEED;
        }
        if(Input.IsActionPressed("ui_right")){
            applyForce.x += ACC_SPEED;
        }
        if(Input.IsActionPressed("ui_jump")){
            applyForce.y += ACC_SPEED;
        }
        applyForce = applyForce.Normalized();
        pos.Dot(applyForce);

        this.Translation += pos;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
