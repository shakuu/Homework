﻿using _02_Kitty.Engine.Contracts;

namespace _02_Kitty.Results.Contracts
{
    public interface IResult
    {
        bool EvaluateCell(IPathCell pathCell);
    }
}
