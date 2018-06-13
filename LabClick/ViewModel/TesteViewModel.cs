using System;

namespace LabClick.ViewModel
{
    public class TesteViewModel
    {
        public int id { get; set; }
        public int id_exame { get; set; }
        public int id_clinica { get; set; }
        public int id_paciente { get; set; }
        public string imagem_teste { get; set; }
        public string status { get; set; }
        public Nullable<System.DateTime> data_inserido { get; set; }
    }
}