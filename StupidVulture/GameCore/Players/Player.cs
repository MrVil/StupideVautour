﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StupidVulture.GameCore.Cards;

namespace StupidVulture.GameCore.Players
{
    public abstract class Player {
        protected int score;
        protected Color color;
        protected List<PlayerCard> remainingCards; //List of the player's remaining PlayerCard
        protected PlayerCard currentPlayerCard; //PlayerCard currently played by the player
        private const int amountCard = 15;

        /// <summary>
        /// Public constructor 
        /// </summary>
        /// <param name="playerColor">Player's color</param>
        public Player(Color playerColor) {
            Color = playerColor;
            Score = 0;
            remainingCards = new List<PlayerCard>();
            for(ushort i=1;i<=amountCard;i++) {
                remainingCards.Add(new PlayerCard(Color, i));
            }
        }


        public int Score {
            get { return this.score; }
            set { this.score = value; }
        }

        public Color Color  {
            get { return color; }
            set { color = value; }
        }

        public List<PlayerCard> RemainingCards {
            get { return remainingCards; }
           
        }

        
        public PlayerCard CurrentPlayerCard {
            get { return currentPlayerCard; }
            set { currentPlayerCard = value; }
        }

        public abstract PlayerCard play(PointCard point);
        
    }
}
