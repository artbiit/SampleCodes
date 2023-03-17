using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public class PositiveProgrammer : ProgrammerDecorator
    {
       public PositiveProgrammer(Programmer programmer) : base(programmer)
        {
            Descryption = "±‡¡§¿˚¿Œ";
        }
    }
}
