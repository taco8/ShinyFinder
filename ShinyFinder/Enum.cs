using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyFinder
{
    public enum ButtonType : byte
    {
        RIGHT = 0,
        LEFT,
        UP,
        DOWN,
        A,
        B,
        X,
        Y,
        R,
        L,
        ZR,
        ZL,
        RSTICK,
        LSTICK,
        RCLICK,
        LCLICK,
        HOME,
        CAPTURE,
        PLUS,
        MINUS
    }

    public enum PokeProfiles : byte
    {
        BDSPシェイミ = 0,
        SSHレジ系,
    }


}
