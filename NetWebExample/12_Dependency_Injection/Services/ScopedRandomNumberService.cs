namespace _12_Dependency_Injection.Services
{
    public class ScopedRandomNumberService:IRandomNumberService
    {
        private readonly int _randomNumber = Random.Shared.Next(1, 1001);

        public int GetRandomNumber() => _randomNumber;
       
    }
}
