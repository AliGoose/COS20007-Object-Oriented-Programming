using System;
using System.Collections.Generic;
using System.Text;

namespace TheMazeGameDLL
{
    public class CommandProcessor
    {
        private List<Command> _commands;
        private MoveCommand _move;
        private LookCommand _look;
        private PutCommand _put;
        private TakeCommand _take;

        public CommandProcessor()
        {
            _commands = new List<Command>();
            _move = new MoveCommand();
            _look = new LookCommand();
            _put = new PutCommand();
            _take = new TakeCommand();
            _commands.Add(_move);
            _commands.Add(_look);
            _commands.Add(_put);
            _commands.Add(_take);
        }

        public string Execute(Player p, string[] text)
        {
            if (_move.AreYou(text[0]) == true)
            {
                return _move.Execute(p, text);
            }
            else if (_look.AreYou(text[0]) == true)
            {
                return _look.Execute(p, text);
            }
            else if(_put.AreYou(text[0]) == true)
            {
                return _put.Execute(p, text);
            }
            else if (_take.AreYou(text[0]) == true)
            {
                return _take.Execute(p, text);
            }
            else if (text[0].ToLower() == "inventory" || text[0].ToLower() == "inv")
            {
                return p.FullDescription;
            }
            else
            {
                return "Invalid Command Input";
            }
        }


    }
}
