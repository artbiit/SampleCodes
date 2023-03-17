using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SampleCode
{
    public class StepUpProgrammer : ProgrammerDecorator
    {
        public StepUpProgrammer(Programmer programmer) : base(programmer)
        {
            Descryption = "성장하는";
        }
    }
}
