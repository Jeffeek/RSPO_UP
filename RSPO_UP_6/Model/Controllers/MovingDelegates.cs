using System.Threading.Tasks;

namespace RSPO_UP_6.Model.Controllers
{
    public delegate void EntityToMoveDirection(int currentRow, int currentColumn, MoveDirection direction);
    public delegate void EntityMovedTo(int currentRow, int currentColumn);
    public delegate Task CowMovedInDirection(MoveDirection direction);
}
