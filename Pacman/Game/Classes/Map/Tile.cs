﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pacman.Characters.Interfaces;

namespace Pacman.Game.Classes.Map
{
    public abstract class Tile 
    {
        public Tile(int x, int y) { }
        public Vector2 Position;
        public ICollidable Member;
        abstract public Boolean CanEnter();
        abstract public void Collide();
        abstract public float GetDistance(Vector2 goal);

    }
}