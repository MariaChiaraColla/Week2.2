using System;
using System.Collections.Generic;
using System.Text;

namespace week2.Factory
{
    public interface IMovement
    {
        //proprietà
        double Importo { get; set; }
        DateTime DataMovimento { get; set; }

    }
}
