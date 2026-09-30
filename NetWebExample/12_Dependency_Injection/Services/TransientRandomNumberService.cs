namespace _12_Dependency_Injection.Services
{
    //Üç sınıf aynı kod farklı davranış yaratır (lifetime)
    public class TransientRandomNumberService:IRandomNumberService
    {
        //Sayı nesne oluştururken bir kez üretilir .Aynı sayıyı görüyorsak aynı nesnedir
        //Random.Shared:paylaşılan thread sade Random (new random() yerine güncel kullanım yapısıdır.)
        private readonly int _randomNumber = Random.Shared.Next(1, 1001);

        public int GetRandomNumber() => _randomNumber;
    }
}
