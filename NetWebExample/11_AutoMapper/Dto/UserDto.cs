namespace _11_AutoMapper.Dto
{

    public class UserDto//Data Transfer Object
    {
        public int Id { get; set; }
        public string FullName { get; set; }//User'da FirstName LastName bu alanları  UserDto FirstName+LastName 
        public string Email { get; set; }
    }
}
