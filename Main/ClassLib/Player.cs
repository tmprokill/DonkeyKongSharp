﻿namespace ClassLib;

public class Player : GameObject
{
    public Coordinates Position { get; set; }
    public override bool Transparent { get; set; } = false;
    public override char Symbol { get;} = 'P';
}