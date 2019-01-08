namespace CommandPattern
{
    class RemoteControl
    {
        private class NoCommand : ICommand { public void Execute() { } }  // empty method

        private ICommand[] onCommands;
        private ICommand[] offCommands;

        public RemoteControl()
        {
            onCommands = new ICommand[7];
            offCommands = new ICommand[7];

            ICommand noCommand = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                onCommands[i] = noCommand;
                offCommands[i] = noCommand;
            }
        }

        public void SetCommand(int slot, ICommand onCommand, ICommand offCommand)
        {
            onCommands[slot] = onCommand;
            offCommands[slot] = offCommand;
        }

        public void OnButtonWasPushed(int slot) => onCommands[slot].Execute();
        public void OffButtonWasPushed(int slot) => offCommands[slot].Execute();
    }
}
