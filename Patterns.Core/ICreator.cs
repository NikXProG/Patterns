namespace Patterns.Core;

// two factory method :)

public interface ICreator<out T, in TM> where T : class
{

    T Create(TM model);
}


public interface ICreator<out T> where T : class
{
    T Create();
}

