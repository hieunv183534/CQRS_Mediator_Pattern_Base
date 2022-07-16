using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace NOM.Domain._Base.Extentions
{
    public static class ExcelExtention
    {
        public static T CopySheet<T>(this T source, int sheetIndex) where T : class, new()
        {
            var result = new T();
            if (typeof(T) == typeof(HSSFWorkbook))
            {
                using (var memoryStream = new MemoryStream())
                {
                    (source as HSSFWorkbook).Write(memoryStream);
                    memoryStream.Position = 0;
                    dynamic data = new HSSFWorkbook(memoryStream);
                    int size = (data as HSSFWorkbook).Count;
                    for (int i = 0; i < sheetIndex; i++)
                    {
                        (data as HSSFWorkbook).RemoveSheetAt(0);
                    }
                    for (int i = size - sheetIndex - 1; i > 0; i--)
                    {
                        (data as HSSFWorkbook).RemoveSheetAt(i);
                    }
                    result = (T)data;
                }
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    (source as XSSFWorkbook).Write(memoryStream);
                    memoryStream.Position = 0;
                    dynamic data = new XSSFWorkbook(memoryStream);
                    int size = (data as XSSFWorkbook).Count;
                    for (int i = 0; i < sheetIndex; i++)
                    {
                        (data as XSSFWorkbook).RemoveSheetAt(0);
                    }
                    for (int i = size - sheetIndex - 1; i > 0; i--)
                    {
                        (data as XSSFWorkbook).RemoveSheetAt(i);
                    }
                    result = (T)data;
                }
            }
            return result;
        }

        public static T RemoveSheet<T>(this T source, int sheetIndex) where T : class, new()
        {
            var result = new T();
            if (typeof(T) == typeof(HSSFWorkbook))
            {
                using (var memoryStream = new MemoryStream())
                {
                    (source as HSSFWorkbook).Write(memoryStream);
                    memoryStream.Position = 0;
                    dynamic data = new HSSFWorkbook(memoryStream);
                    int size = (data as HSSFWorkbook).Count;
                    (data as HSSFWorkbook).RemoveSheetAt(sheetIndex);
                    result = (T)data;
                }
            }
            else
            {
                using (var memoryStream = new MemoryStream())
                {
                    (source as XSSFWorkbook).Write(memoryStream);
                    memoryStream.Position = 0;
                    dynamic data = new XSSFWorkbook(memoryStream);
                    int size = (data as XSSFWorkbook).Count;
                    (data as XSSFWorkbook).RemoveSheetAt(sheetIndex);
                    result = (T)data;
                }
            }
            return result;
        }
    }
}