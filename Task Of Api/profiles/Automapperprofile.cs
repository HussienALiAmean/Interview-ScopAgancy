using AutoMapper;
using Task_Of_Api.DTO;
using Task_Of_Api.Model;
namespace Task_Of_Api.profiles
{
    public class Automapperprofile:Profile
    {
        public Automapperprofile()
        {
            CreateMap<InvoiceDetails,InvoiceDetailsDTO>().ReverseMap();
        }
    }
}
