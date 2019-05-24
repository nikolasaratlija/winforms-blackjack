﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
	public class PlayingCard
	{
		public bool isFaceUp;

		#region getters and setters

		internal Suit Suit { get; }

		internal Value Value { get; }

		#endregion getters and setters

		internal PlayingCard(Value value, Suit symbol, bool isFaceUp)
		{
			this.Value = value;
			this.Suit = symbol;
			this.isFaceUp = isFaceUp;
		}		

		public void Flip()
		{
			this.isFaceUp = !this.isFaceUp;
		}
	}
}
