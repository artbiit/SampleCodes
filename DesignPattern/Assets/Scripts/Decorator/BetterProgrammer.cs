using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SampleCode{ 
public class BetterProgrammer : Programmer
{

        
        public BetterProgrammer()
        {
            Descryption = "소통잘하고 능동적인 프로그래머";
        }

        public override string Output()
        {
            return Descryption;
        }
    }
}