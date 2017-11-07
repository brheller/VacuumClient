//actually efficient model agent
/*namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        Room previousRoom;
        AgentAction MoveDirection;

        public Agent()
        {
            MoveDirection = AgentAction.MOVE_RIGHT;
        }

        public AgentAction DecideAction(Room room)
        {
            AgentAction Action = AgentAction.NONE;

            if (room.IsDirty)
            {
                Action = AgentAction.CLEAN;
            }
            else
            {
                if (previousRoom == room)
                {
                    Action = AgentAction.MOVE_DOWN;
                    if(MoveDirection == AgentAction.MOVE_RIGHT)
                    {
                        MoveDirection = AgentAction.MOVE_LEFT;
                    }
                    else if(MoveDirection == AgentAction.MOVE_LEFT)
                    {
                        MoveDirection = AgentAction.MOVE_RIGHT;
                    }
                }
                else
                {
                    previousRoom = room;   
                    Action = MoveDirection;
                }
            }
            return Action;
        }
    }
}*/

//purely stupid reflex agent
namespace IntelligentVacuum.Agent
{
    using System;
    using System.Collections.Generic;
    using Environments;

    public class Agent
    {
        public Agent()
        {
        }

        private AgentAction ChooseDirection(int x, int y)
        {
            AgentAction Direction = AgentAction.NONE;
            List<AgentAction> directions = new List<AgentAction>
                {AgentAction.MOVE_UP, AgentAction.MOVE_DOWN, AgentAction.MOVE_LEFT, AgentAction.MOVE_RIGHT};

            if (x == 0)
            {
                directions.Remove(AgentAction.MOVE_LEFT);
            }
            if (y == 0)
            {
                directions.Remove(AgentAction.MOVE_UP);
            }

            Direction = directions[new Random().Next(directions.Count)];

            return Direction;
        }
        public AgentAction DecideAction(Room room)
        {
            AgentAction Action = AgentAction.NONE;
            if (room.IsDirty)
            {
               Action = AgentAction.CLEAN;
            }
            else
            {
                Action = ChooseDirection(room.XAxis, room.YAxis);
            }
            return Action;
        }
    }
}