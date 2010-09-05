using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word.Extensions;
using Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Globalization;

namespace ShomreiTorah.Billing.Events.Seating {
	static class WordParser {
		public static ParsedSeatingChart ParseChart(Document document) {
			return new ParsedSeatingChart(
				document.Tables.Items().Concat(
					document.Shapes.Items()
								   .SelectMany(AllShapes)
								   .Where(s => s.TextFrame.HasText != 0)
								   .SelectMany(s => s.TextFrame.TextRange.Tables.Items())
				).Select(ParseTable)
			);
		}
		static IEnumerable<Word.Shape> AllShapes(this Word.Shape shape) {
			if (shape.Type == MsoShapeType.msoGroup) {
				foreach (var child in shape.GroupItems.Items().SelectMany(AllShapes))
					yield return child;
			} else
				yield return shape;
		}

		static IEnumerable<Word.Shape> Items(this Word.GroupShapes g) {
			for (int i = 1, c = g.Count; i <= c; i++) 		//foreach won't work due to a bug in Word
				yield return g[i];
		}

		static SeatRow ParseTable(this Table table) {
			return new SeatRow(
				table.Rows[1].Cells.Items().Select(ParseSeatGroup).Where(s => s != null)
			);
		}
		static SeatGroup ParseSeatGroup(this Cell cell) {
			var text = cell.Range.Text.TrimEnd('\a', '\r', '\n', '\v', ' ', '\t');	//'\a' is end-of-cell

			if (String.IsNullOrEmpty(text))
				return null;
			var lines = text.Split(new[] { '\r', '\n', '\v' }, StringSplitOptions.RemoveEmptyEntries);
			if (lines.Length != 2)
				return null;

			//D Laks
			//4 Seats
			var seatCount = lines[1].Trim();
			return new SeatGroup(
				name: lines[0].Trim(),
				seatCount: int.Parse(seatCount.Remove(seatCount.IndexOf(' ')), CultureInfo.CurrentCulture),
				seatWidth: cell.Width / cell.Height
			);
		}
	}
}
