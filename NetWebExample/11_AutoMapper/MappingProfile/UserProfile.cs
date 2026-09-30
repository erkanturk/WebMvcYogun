using _11_AutoMapper.Dto;
using _11_AutoMapper.Models;
using AutoMapper;

namespace _11_AutoMapper.MappingProfile
{
    public class UserProfile:Profile
    {
        //Profile eşleşme (mapping) kurallarının toplandoğı sınıf.Program.cs te assembly taraması ile otomatik bulunur.
        public UserProfile()
        {
            //User => UserrDto
            //Aynı isimli property'ler (Id,Email) otomatik eşleşir: Farklı olanlar ForMember ile elle tanımlanır.
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            //Ters yön: UserDto User.FullName' parçalamak gerekir 
            
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split(' ', StringSplitOptions.None)[0]))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Contains(' ') ?
                src.FullName.Substring(src.FullName.IndexOf(' ')+1) : string.Empty));

        }
    }
}
