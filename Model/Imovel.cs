using System;
using System.Collections.Generic;

namespace Model
{
    public class Imovel
    {
        public int ID { get; set; }
        public string Endereco { get; set; }
        public int numenro { get; set; }
        public DateTime Data { get; set; }

        // public ICollection<Enrollment> Enrollments { get; set; }
    }
}
