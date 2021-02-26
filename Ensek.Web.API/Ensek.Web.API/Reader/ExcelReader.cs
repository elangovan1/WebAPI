using Ensek.Web.API.Entity;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Ensek.Web.API.Reader
{
    public class ExcelReader : IFileReader<MeterReading>
    {
        private List<MeterReading> _records;
        public IEnumerable<MeterReading> Reader(string fileName)
        {
            _records = new List<MeterReading>();

            if (!File.Exists(fileName))
                throw new FileNotFoundException($"The file not found. {fileName}");

            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                IExcelDataReader excelReader = ExcelReaderFactory.CreateReader(stream);
                var result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true                      
                    }
                });

                if(result==null || result.Tables.Count <=0 || result.Tables[0].Rows.Count <= 0)
                    throw new ArgumentException($"The file not found. {fileName}");

                foreach (DataRow item in result.Tables[0].Rows)
                {
                    _records.Add(new MeterReading
                    {
                        AccountId = Convert.ToInt32(item[0]),
                        NotedOn = Convert.ToDateTime(item[1]),
                        Value = Convert.ToString(item[2])
                    });
                }
            }

            return _records;
        }
    }
}
