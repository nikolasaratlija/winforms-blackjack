﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
	abstract class Hand
	{
		const int pointsToBust = 22;
		private List<PlayingCard> cardsInHand = new List<PlayingCard>();

		#region getters and setters 

		public bool IsBust { get; private set; } = false;
		public int Value { get; private set; } = 0;

		#endregion

		/// <summary>
		/// Draws a card then adds the value of the card.
		/// </summary>
		/// <param name="deck"></param>
		/// <returns>A PlayingCard object</returns>
		public PlayingCard Hit(PlayingCardDeck deck)
		{
			if (IsBust) return null;

			PlayingCard card = deck.DrawFirstCard();
			CalcValueOfHand(card);
			CalcIfHandBust();
			return card;
		}

		/// <summary>
		/// Calculates the value of a certain card and adds that number.
		/// </summary>
		/// <param name="card"></param>
		/// <returns>The value of the card</returns>
		private int CalcValueOfHand(PlayingCard playingCard)
		{
			cardsInHand.Add(playingCard);

			if (CalcIfHandBust(playingCard.value) && cardsInHand.Exists(c => c.value == 11))
				cardsInHand.Find(c => c.value == 11).value = 1;

			return Value = cardsInHand.Sum(c => c.value);
		}

		/// <summary>
		/// Calculates whether the hand would bust with its current amounted value.
		/// </summary>
		/// <returns>A bool</returns>
		private bool CalcIfHandBust()
		{
			return IsBust = CalcIfHandBust(0);
		}

		/// <summary>
		/// Calculates whether adding `int value` to `this.valueOfHand` would make this Hand bust
		/// </summary>
		/// <param name="value"></param>
		/// <returns>A bool</returns>
		private bool CalcIfHandBust(int value)
		{
			if (Value + value >= pointsToBust)
				return true;
			
			return false;
		}
	}
}
