using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SampleCode{ 
public class BetterProgrammer : Programmer
{

        
        public BetterProgrammer()
        {
            Descryption = "�������ϰ� �ɵ����� ���α׷���";
        }

        public override string Output()
        {
            return Descryption;
        }
    }
}