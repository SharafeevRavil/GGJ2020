public interface IElectricBlock
{
    bool CheckRecursionActivated { get; }

    void EnsureDisabled(bool visited);

}