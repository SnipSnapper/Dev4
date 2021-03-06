﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
namespace GUIapp
{
  
  public interface GuiElement : Drawable, Updateable { }
  
  public class Label : GuiElement
  {
    public string content;

    public int size;
    public Color color;
    public Point top_left_corner;
    public Label(string content, Point top_left_corner, int size, Color color)
    {
      this.size = size;
      this.color = color;
      this.content = content;
      this.top_left_corner = top_left_corner;

    }

    public void Draw(DrawVisitor visitor)
    {
            visitor.DrawLabel(this);
    }
    public void Update(UpdateVisitor visitor, float dt) { }

    
  }

  public class Button : GuiElement
  {
    public float width, height;
    public Action action;
    public Color color;
    public Label label;
    public Point top_left_corner;
        private string v1;
        private int v2;
        private int v3;
        private Color red;
        private double v4;
        private double v5;
        private string v6;

        public Button(string text, Point top_left_corner, int size, Color color, float width, float height, Action action) 
    {
      this.action = action;
      this.width = width;
      this.height = height;
      this.color = color;
      this.top_left_corner = top_left_corner;
      label = new Label(text, top_left_corner, size, color);
    }

        public void Draw(DrawVisitor visitor)
    {
            visitor.DrawButton(this);
    }
    public bool is_intersecting(Point point)
    {
      return point.X > top_left_corner.X && point.Y > top_left_corner.Y &&
             point.X < top_left_corner.X + width && point.Y < top_left_corner.Y + height;
    }
    public void Update(UpdateVisitor visitor, float dt)
    {
      //MISSING CODE HERE
    }


  }

  
  public class GuiManager : Updateable, Drawable
  {
    public List<GuiElement> elements;
    public GuiManager(System.Action exit)
    {
      elements = new List<GuiElement>();
      elements.Add(new Label("Hi Ahmed!", new Point(0, 0), 10, Color.White));
      elements.Add(new Button("Click me", new Point(0, 100), 10, Color.White, 100, 30,
                                                  () => {
                                                    elements = new List<GuiElement>();
                                                    elements.Add(new Button("Exit", new Point(0, 0), 10, Color.Black, 100, 30,
                                                            () => {
                                                              exit();
                                                            }
                                                            ));
                                                  }
                                                  ));
    }

    public void Draw(DrawVisitor visitor)
    {
      visitor.DrawGui(this);
    }
    
    public void Update(UpdateVisitor visitor, float dt)
    {
      //MISSING CODE HERE
    }
  }

  

}
