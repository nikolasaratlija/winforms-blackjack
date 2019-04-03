﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualCardGame.Entities
{
	class PlayingDeck
	{
		public PlayingDeck()
		{
			int cardsPerSymbol = 13;
			int symbolsCount = 4; 

			// ln 17 - 33: creates 13 cards for each symbol and pushes them into a list
			for (int symbol = 0; symbol < symbolsCount; symbol++)
			{
				// loop starts at 1 because there's no card with a value lower than 1
				for (int value = 1; value <= cardsPerSymbol; value++)
				{
					// This case assigns an ace, jack, queen or king for the parameter 'value' to the right cards
					if (value == 1 || value > 10)
					{
						this.DeckList.Add(new PlayingCard((SpecialValue)value, (Symbol)symbol, true));
					}
					else
					{
						this.DeckList.Add(new PlayingCard(value, (Symbol)symbol, true));
					}
				}
			}
		}

		internal List<PlayingCard> DeckList { get; } = new List<PlayingCard>();
	}
}
