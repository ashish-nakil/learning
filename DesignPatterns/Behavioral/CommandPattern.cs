using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral
{
    //Command Pattern
    // Useful Link :https://www.infoworld.com/article/3409800/how-to-use-the-command-design-pattern-in-c.html#:~:text=The%20intent%20of%20the%20command,passed%20to%20an%20invoker%20object.

    #region Interfaces


    /// <summary>
    /// Command
    /// </summary>
    public interface CommandClass
    {
        void Execute();
    }

    #endregion


    #region Models
    public class PlayStation
    {
        private CommandClass upCommand, downCommand, leftCommand, rightCommand;

        public PlayStation(CommandClass _upCommand, CommandClass _downCommand, CommandClass _leftCommand, CommandClass _rightCommand)
        {
            upCommand = _upCommand;
            downCommand = _downCommand;
            leftCommand = _leftCommand;
            rightCommand = _rightCommand;
        }

        public void ArrowUp() 
        {
            upCommand.Execute();
        }

        public void ArrowDown()
        {
            downCommand.Execute();
        }

        public void ArrowLeft()
        {
            leftCommand.Execute();
        }

        public void ArrowRight()
        {
            rightCommand.Execute();
        }

    }


    /// <summary>
    /// Receiver 
    /// </summary>
    public class Mario
    {
        private string name;

        public void setName(string Name)
        {
            this.name=Name;
        }

        public string getName()
        {
            return this.name;
        }


        public void MoveUp()
        {
            Console.WriteLine("Move UP");
        }

        public void MoveDown()
        {
            Console.WriteLine("Move Down");
        }

        public void MoveLeft()
        {
            Console.WriteLine("Move Left");
        }

        public void MoveRight()
        {
            Console.WriteLine("Move Right");
        }
    }


    /// <summary>
    /// ConcreteCommand
    /// </summary>
    public class MarioUpCommand : CommandClass
    {
        private Mario mario;
        public  MarioUpCommand(Mario _mario)
        {
            mario = _mario;
        }

        public void Execute()
        {
            mario.MoveUp();
        }
    }


    /// <summary>
    /// ConcreteCommand
    /// </summary>
    public class MarioDownCommand : CommandClass
    {
        private Mario mario;
        public MarioDownCommand(Mario _mario)
        {
            mario = _mario;
        }

        public void Execute()
        {
            mario.MoveDown();
        }
    }


    public class Invoker
    {
        public CommandClass command;

        public void setCommand(CommandClass _command)
        {
            command = _command;
        }

        public void Execute()
        {
            command.Execute();
        }
    
    }
    #endregion

    public class CommandPattern
    {
        public static void Call()
        {
            Mario marioObj = new Mario();
            marioObj.setName("Mario");

            //Client 
            MarioUpCommand marioUpCommand = new MarioUpCommand(marioObj);
            MarioDownCommand marioDownCommand = new MarioDownCommand(marioObj);
            
            //PlayStation playStation = new PlayStation(marioUpCommand, marioDownCommand,null,null);
            //playStation.ArrowUp();

            Invoker invoker = new Invoker();
            invoker.setCommand(marioUpCommand);

            invoker.Execute();

        }

    }

}
