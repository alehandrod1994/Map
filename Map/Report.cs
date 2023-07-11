using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace Map
{
	public class Report
	{
		private Excel.Application _app;
		private Excel.Workbook _book;
		private Excel.Worksheet _sheet;

		private ReportStatus _status;

		private int _currentRow;
		private int _maxRow;

		public ReportStatus ExportParkings(string newFileName, IProgress<int> progress)
		{
			if (!OpenConnection())
			{
				return _status;
			}

			var headers = new string[]
			{
				"Стоянка",
				"Камера",
				"Приоритет"
			};
			CreateHead(headers);
			PasteData(progress);
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

		private void PasteData(IProgress<int> progress)
		{
			_currentRow = 1;
			var parkings = Saver.Load<Parking>();
			var parkingsCameras = Saver.Load<ParkingCamera>();

			for (int i = 0; i < parkings.Count; i++)           
			{
				List<ParkingCamera> currentParkingCameras = parkingsCameras.Where(pc => pc.Parking.Number == parkings[i].Number).ToList();
				if (currentParkingCameras.Count > 0)
				{
					foreach (var item in currentParkingCameras)
					{
						AddRow(item.Parking.Number, item.Camera.Number.ToString(), Parser.GetValue(item.Rating));
					}

					int mergeStartIndex = _currentRow - (currentParkingCameras.Count - 1);
					MergeCells(mergeStartIndex, "A", _currentRow, "A");

					progress.Report(CalculateProgress(i + 1, parkings.Count));
				}
			}

			_maxRow = _currentRow;
		}

		private void AddRow(string parking, string camera, string rating)
		{
			_currentRow++;

			_sheet.Cells[_currentRow, 1] = parking;
			_sheet.Cells[_currentRow, 2] = camera;
			_sheet.Cells[_currentRow, 3] = rating;
		}


		private void FormatTable()
		{
			AutoFitColumn(1, "C", _maxRow, "C");
			DrawBorders(1, "A", _maxRow, "C");
			FillBackground(1, "A", 1, "C", 112, 173, 71);

			VerticalAlignment(1, "A", _maxRow, "A", Excel.XlVAlign.xlVAlignCenter);
			HorizontalAlignment(1, "A", _maxRow, "A", Excel.XlVAlign.xlVAlignCenter);
			HorizontalAlignment(1, "C", _maxRow, "C", Excel.XlVAlign.xlVAlignCenter);
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
		/// Выровнять по вертикали.
		/// </summary>
		/// <param name="startX"> Начальный номер строки. </param>
		/// <param name="startY"> Начальный номер столбца. </param>
		/// <param name="lastX"> Конечный номер строки. </param>
		/// <param name="lastY"> Конечный номер столбца. </param>
		/// <param name="valign"> Способ выравнивания. </param>
		private void VerticalAlignment(int startX, string startY, int lastX, string lastY, Excel.XlVAlign valign)
		{
			Excel.Range range;

			range = _sheet.Range[startY + startX + ":" + lastY + lastX];
			range.VerticalAlignment = valign;
		}

		/// <summary>
		/// Выровнять по горизонтали.
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
		/// Приводит значение из ячейки Excel к строке.
		/// </summary>
		/// <param name="i"> Номер строки. </param>
		/// <param name="j"> Номер столбца. </param>
		/// <returns> Результат приведения. </returns>
		private string ToString(int i, int j)
		{
			Excel.Range range = (Excel.Range)_sheet.Cells[i, j];
			return range.Value?.ToString() ?? "";
		}
	}
}
