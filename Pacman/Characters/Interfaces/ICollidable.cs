using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Characters.Interfaces
{
    public delegate void CollisionEventHandler(ICollidable member);
    public interface ICollidable
    {
        event CollisionEventHandler CollisionEvent;

        int Points{ get; set; }
        void Collide();
    }
}
