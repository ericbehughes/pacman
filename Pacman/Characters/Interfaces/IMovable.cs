using Microsoft.Xna.Framework;
using Pacman.Characters.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Interfaces
{
    public interface IMovable
    {
        Direction Direction { get; set; }
        Vector2 Position { get; set; }
        void Move();

    }
}
