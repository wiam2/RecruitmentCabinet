using System;

using System.ComponentModel.DataAnnotations;



namespace AKL_project_backend.DTOS
{
    public class CondidatDto : UserDTO
    {
        public string CVPDF { get; set; }
        public int CVId { get; set; }

        public CVDTO Cv { get; set; }
    }
}
