using System;
using Unity.Services.Analytics;
public class GameStartClick : Event
    {
        public GameStartClick() : base("GameStartClick")
        {
        }
        public bool started { set { SetParameter("started", value); } }
    }