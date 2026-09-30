namespace _12_Dependency_Injection.Services
{
    //Interface sözleşmesi:Controllerlar somut sınıfı değil bu sözleşmeyi ister gevşek bağımlılık yapar testleri kolaylaştırır.
    public interface IRandomNumberService
    {
        int GetRandomNumber();//Gövdesiz

    }
}
