
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AKL_project_backend.model
{
    public class Condidat : User
    {
      
        public string CVPDF { get; set; }
        public int CVId { get; set; }
        [JsonIgnore]
        public CV Cv { get; set; }

        public Condidat() { }
    }
}
