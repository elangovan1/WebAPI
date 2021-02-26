using System.Collections.Generic;

namespace Ensek.Web.API.Reader
{
    public interface IFileReader<T>
    {
        IEnumerable<T> Reader(string fileName);
    }
}
