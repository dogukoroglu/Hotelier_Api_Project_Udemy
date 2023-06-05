using System.ComponentModel.DataAnnotations;

namespace HotelierProject.WebUI.Dtos.ServiceDto
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Hizmet icon linki giriniz!")]
        public string ServiceIcon { get; set; }

        [Required(ErrorMessage = "Hizmet başlığı giriniz!")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
