using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public class ProgrammerDecorator : Programmer
    {
        private Programmer programmer;

        public ProgrammerDecorator(Programmer programmer)
        {
            this.programmer = programmer;
        }

        public override string Output()
        {
            return $"{programmer.Output()} {Descryption}";
        }
    }
}
