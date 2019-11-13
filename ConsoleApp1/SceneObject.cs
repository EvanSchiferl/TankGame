using System;
using System.Collections.Generic;
using System.Text;
using Raylib;
using rl = Raylib.Raylib;
using System.Diagnostics;

namespace ConsoleApp1
{
    class SceneObject
    {
        SceneObject tankObject = new SceneObject();
        SceneObject turretObject = new SceneObject();

        SpriteObject tankSprite = new SpriteObject();
        SpriteObject turretSprite = new SpriteObject();

        protected SceneObject parent = null;
        protected List<SceneObject> children = new List<SceneObject>();

        protected Matrix4 localTransform = new Matrix4();
        protected Matrix4 globalTransform = new Matrix4();

        public Matrix4 LocalTransform
        {
            get { return localTransform; }
        }

        public Matrix4 GlobalTransform
        {
            get { return globalTransform; }
        }

        public void UpdateTransform()
        {
            if (parent != null)
                globalTransform = parent.globalTransform * localTransform;
            else
                globalTransform = localTransform;

            foreach (SceneObject child in children)
                child.UpdateTransform();
        }



        public SceneObject Parent
        {
            get { return parent; }
        }

        public SceneObject()
        {
            
        }

        public int GetChildCount()
        {
            return children.Count;
        }

        public SceneObject GetChild(int index)
        {
            return children[index];
        }

        public void AddChild(SceneObject child)
        {
            Debug.Assert(child.parent == null);
            child.parent = this;
            children.Add(child);
        }

        public void RemoveChild(SceneObject child)
        {
            if(children.Remove(child) == true)
            {
                child.parent = null;
            }
        }

        ~SceneObject()
        {
            if(parent != null)
            {
                parent.RemoveChild(this);
            }
            foreach(SceneObject so in children)
            {
                so.parent = null;
            }
        }



        public virtual void OnUpdate(float deltaTime)
        {
            OnUpdate(deltaTime);

            foreach(SceneObject child in children)
            {
                child.OnUpdate(deltaTime);
            }
        }

        public virtual void OnDraw()
        {
            OnDraw();

            foreach(SceneObject child in children)
            {
                child.OnDraw();
            }
        }



        public void SetPosition(float x, float y)
        {
            localTransform.SetTranslation(x, y, 1);
            UpdateTransform();
        }

        public void SetRotate(float radians)
        {
            localTransform.SetRotateZ(radians);
            UpdateTransform();
        }

        public void SetScale(float width, float height)
        {
            localTransform.SetScaled(width, height, 1);
            UpdateTransform();
        }

        public void Translate(float x, float y)
        {
            localTransform.Translate(x, y, 1);
            UpdateTransform();
        }

        public void Rotate(float radians)
        {
            localTransform.RotateZ(radians);
            UpdateTransform();
        }

        public void Scale(float width, float height)
        {
            localTransform.Scale(width, height, 1);
            UpdateTransform();
        }
    }
}
