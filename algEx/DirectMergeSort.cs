using ClosedXML.Excel;

namespace algEx;

public class DirectMergeSort
{
    public void Run(string inputFilePath, int keyIndex)
    {
        var workbook = new XLWorkbook(inputFilePath);
        var worksheet = workbook.Worksheet(1);
        
        var rows = worksheet.RowsUsed().Skip(1).ToList();
        int n = rows.Count;
        int seriesLength = 1;
        int step = 1;
        
        var fileA = new XLWorkbook();
        var fileB = new XLWorkbook();
        var fileC = new XLWorkbook();
        
        fileA.Worksheets.Add("MergedData");
        fileB.Worksheets.Add("MergedData");
        fileC.Worksheets.Add("MergedData");

        string AFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), "A_" + Path.GetFileName(inputFilePath));
        string BFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), "B_" + Path.GetFileName(inputFilePath));
        string CFilePath = Path.Combine(Path.GetDirectoryName(inputFilePath), "C_" + Path.GetFileName(inputFilePath));
        fileA.SaveAs(AFilePath);
        fileB.SaveAs(BFilePath);
        fileC.SaveAs(CFilePath);
        
        for (int i = 0; i < n; i++)
        {
            CopyRowToWorksheet(worksheet.RowsUsed().ToList()[i + 1], fileA.Worksheet(1), i + 1, keyIndex);
        }
        fileA.Save();
        
        while (seriesLength < n)
        {
            fileB.Worksheet(1).Clear();
            fileC.Worksheet(1).Clear();

            int i = 0;
            int lB = 0, lC = 0;
            var rowsA = fileA.Worksheet(1).RowsUsed().ToList();
            int numRowsA = rowsA.Count;

            while (i < numRowsA)
            {
                for (int j = 0; j < seriesLength && i < numRowsA; j++, i++, lB++)
                {
                    CopyRowToWorksheet(rowsA[i], fileB.Worksheet(1), lB + 1, keyIndex);
                    fileB.Save();
                    
                    fileA.Worksheet(1).Row(i + 1).Clear();
                    fileA.Save();
                }
                for (int j = 0; j < seriesLength && i < numRowsA; j++, i++, lC++)
                {
                    CopyRowToWorksheet(rowsA[i], fileC.Worksheet(1), lC + 1, keyIndex);
                    fileC.Save();
                    
                    fileA.Worksheet(1).Row(i + 1).Clear();
                    fileA.Save();
                } 
            }
            
            fileA.Worksheet(1).Clear();
            fileA.Save();
            int bIndex = 0, cIndex = 0;

            var rowsB = fileB.Worksheet(1).RowsUsed().ToList();
            var rowsC = fileC.Worksheet(1).RowsUsed().ToList();

            int k = 0; 
            while (bIndex < rowsB.Count || cIndex < rowsC.Count)
            {
                int bEnd = Math.Min(bIndex + seriesLength, rowsB.Count);
                int cEnd = Math.Min(cIndex + seriesLength, rowsC.Count);
                
                while (bIndex < bEnd || cIndex < cEnd)
                {
                    if (bIndex < bEnd && (cIndex >= cEnd || CompareValues(rowsB[bIndex].Cell(keyIndex + 1).Value.ToString(), rowsC[cIndex].Cell(keyIndex + 1).Value.ToString()) <= 0))
                    {
                        CopyRowToWorksheet(rowsB[bIndex], fileA.Worksheet(1), k + 1, keyIndex);
                        bIndex++; 
                    }
                    else if (cIndex < cEnd)
                    {
                        CopyRowToWorksheet(rowsC[cIndex], fileA.Worksheet(1), k + 1, keyIndex);
                        cIndex++; 
                    }
                    k++;
                }
            }
            
            fileA.Save();
            seriesLength *= 2;
            step++;
        }
    }
    
    private int CompareValues(string value1, string value2)
    {
        if (double.TryParse(value1, out var num1) && double.TryParse(value2, out var num2))
        {
            return num1.CompareTo(num2);
        }
        return string.Compare(value1, value2, StringComparison.Ordinal);
    }
    
    private void CopyRowToWorksheet(IXLRow sourceRow, IXLWorksheet destWorksheet, int destRowIdx, int keyIndex)
    {
        for (int colIdx = 1; colIdx <= sourceRow.LastCellUsed().Address.ColumnNumber; colIdx++)
        {
            if (colIdx > 16384)
            {
                continue;
            }
            destWorksheet.Cell(destRowIdx, colIdx).Value = sourceRow.Cell(colIdx).Value;
        }
    }
}
    



