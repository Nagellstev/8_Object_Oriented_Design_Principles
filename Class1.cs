interface ICommand
{
    public void Execute();
    public void Undo();
}
// конкретная команда
class ConcreteCommand : ICommand
{
    Receiver receiver;
    public ConcreteCommand(Receiver r)
    {
        receiver = r;
    }
    public void Execute()
    {
        receiver.Operation();
    }

    public void Undo()
    {
        //
    }
}

// получатель команды
class Receiver
{
    public void Operation()
    { 

    }
}
// инициатор команды
class Invoker
{
    ICommand command;
    public void SetCommand(ICommand c)
    {
        command = c;
    }
    public void Run()
    {
        command.Execute();
    }
    public void Cancel()
    {
        command.Undo();
    }
}
class Client
{
    void Main()
    {
        Invoker invoker = new Invoker();
        Receiver receiver = new Receiver();
        ConcreteCommand command = new ConcreteCommand(receiver);
        invoker.SetCommand(command);
        invoker.Run();
    }
}