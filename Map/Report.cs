using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Map
{
	public class Report
	{
		private Excel.Application _app;
		private Excel.Workbook _book;
		private Excel.Worksheet _sheet;

		private ReportStatus _status;

		private int _maxRow;

		public ReportStatus ExportParkings(List<ParkingCamera> items, string newFileName, IProgress<int> progress)
		{
			if (!OpenConnection())
			{
				return _status;
			}

			var headers = new string[]
			{
				"Стоянка",
				"Камера",
				"Рейтинг"
			};
			CreateHead(headers);
			PasteData(items, progress);
			FormatTable();

			if (!Save(newFileName))
			{
				return _status;
			}
			
			CloseConnection();

			_status = ReportStatus.Success;
			return _status;
		}

		private bool OpenConnection()
		{
			_app = new Excel.Application();
			_book = null;

			try
			{
				_book = _app.Workbooks.Add();
			}
			catch
			{
				_status = ReportStatus.Failed;
				return false;
			}

			_app.DisplayAlerts = false;

			_sheet = (Excel.Worksheet)_book.Sheets[1];
			_sheet.Name = "Стоянки ВС";
			return true;
		}

		private void CreateHead(string[] headers)
		{
			for (int i = 1; i <= headers.Length; i++)
			{
				_sheet.Cells[1, i] = headers[i - 1];
			}
		}

		private void PasteData(List<ParkingCamera> items, IProgress<int> progress)
		{
			int startRow = 2;
			_maxRow = items.Count + 1;

			for (int i = startRow; i <= _maxRow; i++)
			{
				_sheet.Cells[i, 1] = items[i - startRow].Parking.Number;
				_sheet.Cells[i, 2] = items[i - startRow].Camera.Number.ToString();
				_sheet.Cells[i, 3] = Parser.GetValue(items[i - startRow].Rating);

				progress.Report(CalculateProgress(i, _maxRow));
			}
		}

		private void FormatTable()
		{
			DrawBorders(1, "A", _maxRow, "C");
			FillBackground(1, "A", 1, "C", 112, 173, 71);

			// TODO: Объединить ячейки.
			//for (int i = 2; i < _maxRow; i++)
			//{
			//	if (ToString(i, 1) == ToString(i + 1, 1))
			//	{
			//		MergeCells(i, "A", i + 1, "A");
			//	}
			//}

			// TODO: Выровнять стоянки по центру.
			HorizontalAlignment(1, "C", _maxRow, "C", Excel.XlVAlign.xlVAlignCenter);

			// TODO: Выполнить автоширину у столбцов.

		}

		private bool Save(string newFileName)
		{
			try
			{
				_book.SaveAs(newFileName);
			}
			catch
			{
				_status = ReportStatus.NotSave;
				return false;
			}

			try
			{
				_book.Close();
				_app.Quit();
			}
			catch { }

			return true;
		}

		private bool CloseConnection()
		{
			try
			{
				_book.Close();
				_app.Quit();
				return true;
			}
			catch
			{
				return false;
			}
		}

		private int CalculateProgress(int currentIndex, int maxCount)
		{
			return currentIndex * 100 / maxCount;
		}
	
		private void DrawBorders(int startX, string startY, int lastX, string lastY)
		{
			Excel.Range range;

			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlInsideHorizontal).LineStyle = Excel.XlLineStyle.xlContinuous;
			range.Borders.get_Item(Excel.XlBordersIndex.xlInsideVertical).LineStyle = Excel.XlLineStyle.xlContinuous;
		}

		private void FillBackground(int startX, string startY, int lastX, string lastY, int R, int G, int B)
		{
			Excel.Range range;

			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.Interior.Color = Color.FromArgb(R, G, B);
		}

		private void AutoFitColumn(int startX, string startY, int lastX, string lastY)
		{
			Excel.Range range;
			
			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.EntireColumn.AutoFit();
		}

		private void MergeCells(int startX, string startY, int lastX, string lastY)
		{
			Excel.Range range;

			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.Merge();
		}

		/// <summary>
		/// Горизонтальное выравнивание.
		/// </summary>
		/// <param name="startX"> Начальный номер строки. </param>
		/// <param name="startY"> Начальный номер столбца. </param>
		/// <param name="lastX"> Конечный номер строки. </param>
		/// <param name="lastY"> Конечный номер столбца. </param>
		/// <param name="valign"> Способ выравнивания. </param>
		private void HorizontalAlignment(int startX, string startY, int lastX, string lastY, Excel.XlVAlign valign)
		{
			Excel.Range range;

			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.HorizontalAlignment = valign;
		}

		/// <summary>
		/// Проверяет, равны ли значение в ячейке Excel и введённое значение.
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <param name="value"> Текст. </param>
		/// <returns> Возвращает true, если равны; в противном случае - false. </returns>
		private bool Equals(int i, int j, string value)
		{
			return ToString(i, j).Equals(value, StringComparison.CurrentCultureIgnoreCase);
		}

		/// <summary>
		/// Проверяет, содержит ли ячейка Excel введённую подстроку. 
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <param name="value"> Текст. </param>
		/// <returns> Возвращает true, если содержит; в противном случае - false. </returns>
		private bool Contains(int i, int j, string value)
		{
			return ToString(i, j).ToUpper().Contains(value.ToUpper());
		}

		/// <summary>
		/// Приводит значение из ячейки Excel к строке.
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <returns> Результат приведения. </returns>
		private string ToString(int i, int j)
		{
			Excel.Range rng = (Excel.Range)_sheet.Cells[i, j];
			return rng.Value?.ToString() ?? "";
		}
	}
}
